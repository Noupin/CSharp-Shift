using Keras.Models;
using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Losses;
using Tensorflow.Keras.Optimizers;
using Tensorflow.ModelSaving;
using Tensorflow.NumPy;
using static Tensorflow.Binding;
using static Tensorflow.KerasApi;
using Model = Tensorflow.Keras.Engine.Model;
using Shape = Tensorflow.Shape;

namespace Shift.Server.AI
{
    /// <summary>
	/// Base TensorFlow Model for TFModel
	/// </summary>
    public class TFModel : Model
    {
        private List<ILayer> _modelLayers = new List<ILayer>();
        private ILossFunc _loss;
        private OptimizerV2 _optimizer;
        private Shape _inputShape;
        private string _modelName;

        public TFModel(Shape inputShape, ILayer outputLayer, OptimizerV2 optimizer,
            ILossFunc loss, string name, ModelArgs? args) : base(args)
        {
            _inputShape = inputShape;
            _optimizer = optimizer;
            _loss = loss;
            _modelName = name;

            _modelLayers.Add(keras.layers.InputLayer(_inputShape));
            _modelLayers.Add(outputLayer);
        }

        public TFModel(ModelArgs? args) : base(args)
        {
            _inputShape = new Shape(128, 128, 3);
            _optimizer = new Adam();
            _loss = new MeanSquaredLogarithmicError();
            _modelName = "TFModel";

            _modelLayers.Add(keras.layers.InputLayer(_inputShape));
            _modelLayers.Add(keras.layers.Dense(10));
        }

        protected override Tensors Call(Tensors inputs, Tensor state = null, bool? training = null)
        {
            var connectedLayers = inputs;

            foreach (var layer in _modelLayers.Skip(1))
            {
                connectedLayers = layer.Apply(connectedLayers);
            }

            return connectedLayers;
        }

        public Tensors Inference(Tensor tensor)
        {
            return Call(tensor, training: false);
        }

        public Tensor TrainStep(Tensors x, Tensors y)
        {

            var tape = new Tensorflow.Gradients.GradientTape();

            var logits = Call(x, training: true);
            var lossValue = _loss.Call(y, logits);

            var grads = tape.gradient(lossValue, trainable_weights);
            var zipped = Enumerable.Zip(grads, trainable_weights);
            //May fail
            _optimizer.apply_gradients((IEnumerable<(Tensor, ResourceVariable)>)zipped);

            return lossValue;
        }

        public Tensor TestStep(Tensor x, Tensor y)
        {
            return Call(x, training: false);
        }

        /// <summary>
        /// Trains the model based on the datasets given.
        /// </summary>
        /// <param name="xTrainData"></param>
        /// <param name="yTrainData"></param>
        /// <param name="xTestData"></param>
        /// <param name="yTestData"></param>
        /// <param name="epochs"></param>
        /// <param name="silent"></param>
        public void Train(IDatasetV2 xTrainData, IDatasetV2? yTrainData,
            IDatasetV2? xTestData, IDatasetV2? yTestData,
            int epochs = 1, bool silent = true)
        {
            var trainDataset = yTrainData is not null ? Enumerable.Zip(xTrainData, yTrainData) : Enumerable.Zip(xTrainData, xTrainData);

            IDatasetV2? testDataset = null;
            if (xTestData is not null && yTestData is not null)
            {
                testDataset = tf.data.Dataset.zip(xTestData, yTestData);
            }
            else if (xTestData is not null)
            {
                testDataset = tf.data.Dataset.zip(xTestData, xTestData);
            }

            for (int epoch = 0; epoch < epochs; epoch++)
            {
                var epochStart = DateTime.Now;
                Tensor reducedLoss = new Tensor();

                for (int step = 0; step < trainDataset.Count(); step++)
                {
                    var (xBatchTrain, yBatchTrain) = trainDataset.ElementAt(0);
                    var lossValue = TrainStep(xBatchTrain, yBatchTrain);
                    reducedLoss = tf.reduce_mean(tf.abs(lossValue));
                    if (!silent)
                    {
                        Console.WriteLine($"Loss for batch {step + 1}: {reducedLoss}");
                    }

                    if (testDataset is not null)
                    {
                        foreach (var (xBatchTest, yBatchTest) in testDataset)
                        {
                            TestStep(xBatchTest, yBatchTest);
                        }
                    }
                }

                if (!silent)
                {
                    Console.WriteLine($"Epoch: {epoch + 1},  Loss: {reducedLoss}, in {DateTime.Now - epochStart} sec");
                }
            }
        }

        /// <summary>
        /// Adds layer to the _modelLayers for compile-time.
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="index"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddLayer(ILayer layer, int index = -1)
        {
            if (Math.Abs(index) > _modelLayers.Count)
            {
                throw new ArgumentException($"Index: {index} is out of range of the current Model Layers.");
            }

            _modelLayers.Insert(index, layer);
        }

        /// <summary>
        /// Save method for TFModel allowing for additional logic in the future.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="overwrite"></param>
        /// <param name="include_optimizer"></param>
        /// <param name="save_format"></param>
        /// <param name="options"></param>
        public void Save(string filepath, bool overwrite = true, bool include_optimizer = true, string save_format = "tf", SaveOptions options = null)
        {
            save(filepath, overwrite, include_optimizer, save_format, options);
        }

        public void Load(string filepath, bool compile = true, bool hasInputLayer = false, Shape? inputShape = null)
        {
            if (inputShape is not null)
            {
                _inputShape = inputShape;
            }

            var baseShape = new Shape(1);
            var testTensor = np.zeros(_inputShape, dtype: np.float32).reshape(baseShape.concatenate(_inputShape));

            var model = BaseModel.LoadModel(filepath);

            if (!hasInputLayer)
            {
                _modelLayers = new List<ILayer>();
                _modelLayers.Add(keras.layers.InputLayer(_inputShape));
                //ERROR
                _modelLayers.Concat((IEnumerable<ILayer>)model.ToPython().GetAttr("layers"));

            }

            try
            {
                Call(testTensor);
            }
            catch
            {
                throw new TypeError("The model loaded in has a dynamic input shape(a value of none). Please specify an inputShape to load this model.");
            }



        }

        public void CompileModel(OptimizerV2? optimizer, ILossFunc? loss)
        {
            if (optimizer is not null)
            {
                _optimizer = optimizer;
            }
            if (loss is not null)
            {
                _loss = loss;
            }

            compile(optimizer: _optimizer, loss: _loss);
        }
    }
}
