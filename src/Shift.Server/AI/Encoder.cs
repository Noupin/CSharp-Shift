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
	/// Encoder Model for TFModel
	/// </summary>
    public class Encoder : TFModel
    {
        public int encodingLayers = 0;

        public Encoder(ModelArgs? args) : base(args)
        {
        }

        public Encoder(Shape inputShape, Activation outputActivation, int outputDimension,
            OptimizerV2 optimizer, ILossFunc loss, string name, ModelArgs? args) :
            base(inputShape, keras.layers.Dense(outputDimension, activation: outputActivation), optimizer, loss, name, args)
        {

            AddLayer(keras.layers.Flatten(), -1);
        }
    }
}
