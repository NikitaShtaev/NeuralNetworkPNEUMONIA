using System;
using System.Runtime.Serialization;

namespace NeuralNetworkClasses
{
    [DataContract]
    public class Layer
    {
        [DataMember]
        public Layer PreviousLayer { get; set; }
        [DataMember]
        public Neuron[] Neurons { get; set; }
        [DataMember]
        public int Size { get; set; }
        public Layer(int size, Layer previousLayer)
        {
            PreviousLayer = previousLayer;
            Size = size;
            CreateNeurons();
        }
        public Layer(int size)
        {
            PreviousLayer = null;
            Size = size;
            CreateNeuronsForFirstLayer();
        }

        private void CreateNeuronsForFirstLayer()
        {
            for (int i = 0; i < Size; i++)
            {
                Neurons[i] = new Neuron(1);
            }
        }

        private void CreateNeurons()
        {
            for (int i = 0; i < Size; i++)
            {
                Neurons[i] = new Neuron(PreviousLayer.Size);
            }
        }
        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < Size; i++)
            {
                result += $"NO.{i + 1}: {Neurons[i]}\n";
            }
            return result;
        }
    }
}
