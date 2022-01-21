using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Losses;
using Tensorflow.Keras.Optimizers;
using static Tensorflow.KerasApi;
using Shape = Tensorflow.Shape;

namespace Shift.Server.AI
{
    /// <summary>
	/// Base TensorFlow Model for TFModel
	/// </summary>
    public class TFModel : Model
    {
        private List<ILayer> ModelLayers = new List<ILayer>();
        private ILossFunc Loss;
        private OptimizerV2 Optimizer;
        private Shape InputShape;
        private string ModelName;

        public TFModel(Shape inputShape, ILayer outputLayer, OptimizerV2 optimizer,
            ILossFunc loss, string name, ModelArgs? args) : base(args)
        {
            InputShape = inputShape;
            Optimizer = optimizer;
            Loss = loss;
            ModelName = name;

            ModelLayers.Add(keras.layers.InputLayer(InputShape));
            ModelLayers.Add(outputLayer);
        }

        public TFModel(ModelArgs? args) : base(args)
        {
            InputShape = new Shape(128, 128, 3);
            Optimizer = new Adam();
            Loss = new MeanSquaredLogarithmicError();
            ModelName = "TFModel";

            ModelLayers.Add(keras.layers.InputLayer(InputShape));
            ModelLayers.Add(keras.layers.Dense(10));
        }


        protected override Tensors Call(Tensors inputs, Tensor state = null, bool? training = null)
        {
            var connectedLayers = inputs;

            foreach (var layer in ModelLayers.Skip(1))
            {
                connectedLayers = layer.Apply(connectedLayers);
            }

            return connectedLayers;
        }

        public Tensors Inference(Tensor tensor)
        {
            return Call(tensor);
        }

        public Tensor TrainStep(Tensors x, Tensors y)
        {

            var tape = new Tensorflow.Gradients.GradientTape();

            var logits = Call(x, training: true);
            var lossValue = Loss.Call(y, logits);

            var grads = tape.gradient(lossValue, trainable_weights);
            var zipped = Enumerable.Zip(grads, trainable_weights);
            Optimizer.apply_gradients((IEnumerable<(Tensor, ResourceVariable)>)zipped);

            return lossValue;
        }

    }
}
