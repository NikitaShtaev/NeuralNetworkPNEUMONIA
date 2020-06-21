using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace NeuralNetworkClasses
{
    [DataContract]
    public class NeuralNetwork
    {
        [DataMember]
        public Topology Topology { get; set; }
        [DataMember]
        public Layer FirstLayer { get; set; }
        [DataMember]
        public Layer[] InnerLayers { get; set; }
        [DataMember]
        public Layer OutputLayer { get; set; }
        [DataMember]
        private int FirstLayerCount { get; set; }
        private int InnerLayersCount { get; set; }
        public NeuralNetwork() {}
        public NeuralNetwork(Topology topology)
        {
            Topology = topology;
            FirstLayer = new Layer(topology.FirstLayerNeurons);
            FirstLayerCount = topology.FirstLayerNeurons;
            InnerLayersCount = topology.InnerLayersCount;
            for (int i = 0; i < InnerLayersCount; i++)
            {
                if (i == 0)
                {
                    InnerLayers[i] = new Layer(FirstLayerCount / (i + 1), FirstLayer);
                }
                else
                {
                    InnerLayers[i] = new Layer(FirstLayerCount / (i + 1), InnerLayers[i - 1]);
                }
            }
            OutputLayer = new Layer(topology.OutputsLayerNeurons, InnerLayers[InnerLayers.Length-1]);
        }

        private double Sigmoid(double value)
        {
            double result = 0;
            result = 1 / (1 + Math.Pow(Math.E, -value));
            return result;
        }
        public void WriteDownNetwork(string path, NeuralNetwork neuralnetwork)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(NeuralNetwork));
            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, neuralnetwork);
            }
        }
        public NeuralNetwork ReadNetwork(string path)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(NeuralNetwork));
            var result = new NeuralNetwork();
            using (var file = new FileStream(path, FileMode.Open))
            {
                result = jsonFormatter.ReadObject(file) as NeuralNetwork;
            }
            return result;
        }

    }
}
