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
	/// Judge Model for TFModel
	/// </summary>
    public class Judge : TFModel
    {
        public Judge(ModelArgs? args) : base(args)
        {
        }

        public Judge(Shape inputShape, Activation outputActivation,
            OptimizerV2 optimizer, ILossFunc loss, string name, ModelArgs? args) :
            base(inputShape, keras.layers.Dense(1, activation: outputActivation), optimizer, loss, name, args)
        {
            AddLayer(keras.layers.Flatten(), -1);
            AddDifferntiatorLayer(tf.nn.relu);

        }

        public void AddDifferntiatorLayer(Activation activation, int filters=24,
            int kernelSize=3, int strides=2, string padding="same", int index=-2,
            bool withoutDropout=true, float dropoutRate=0.3f)
        {
            if (Math.Abs(index) > _modelLayers.Count - 1 || Math.Abs(index) < 1)
            {
                throw new OutOfRangeError($"The index: {index} is out of the range of layers in your current model with length: {_modelLayers.Count - 1}");
            }

            if(index > 0)
            {
                index = -(_modelLayers.Count - index);
            }

            AddLayer(keras.layers.Conv2D(filters, kernelSize, strides, padding, activation: activation), index);
            if (withoutDropout)
            {
                AddLayer(keras.layers.Dropout(dropoutRate), index);
            }
        }
    }
}
