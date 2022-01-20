using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Losses;
using Tensorflow.Keras.Optimizers;
using static Tensorflow.KerasApi;

namespace Shift.Server.AI
{
    /// <summary>
	/// Base TensorFlow Model for TFModel
	/// </summary>
    public class TFModel : Model
    {
        private List<ILayer> ModelLayers = new List<ILayer>();
        private ILossFunc Loss;
        private IOptimizer Optimizer;
        private Shape InputShape;
        private string ModelName;

        public TFModel(Shape inputShape, ILayer outputLayer, IOptimizer optimizer,
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

    }
}
