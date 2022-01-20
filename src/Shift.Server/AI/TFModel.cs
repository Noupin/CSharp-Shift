using static Tensorflow.Binding;
using static Tensorflow.KerasApi;
using Tensorflow;
using Tensorflow.NumPy;



namespace Shift.Server.AI
{
    /// <summary>
	/// Base TensorFlow Model for TFModel
	/// </summary>
    public class TFModel
    {
        private IEnumerable<Tensorflow.Keras.ILayer> ModelLayers;

        public TFModel()
        {
        }

    }
}
