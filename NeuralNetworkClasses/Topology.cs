using System.Runtime.Serialization;

namespace NeuralNetworkClasses
{
    [DataContract]
    public class Topology
    {
        [DataMember]
        public int FirstLayerNeurons { get; set; }
        [DataMember]
        public int InnerLayersCount { get; set; }
        [DataMember]
        public int OutputsLayerNeurons { get; set; }
        public Topology(int firstLayerNeurons, int innerLayersCount, int outputsLayersNeurons)
        {
           //TODO: check data in class TOPOLOGY.
            FirstLayerNeurons = firstLayerNeurons;
            InnerLayersCount = innerLayersCount;
            OutputsLayerNeurons = outputsLayersNeurons;
        }
        public Topology()
        {
            FirstLayerNeurons = 0;
            InnerLayersCount = 0;
            OutputsLayerNeurons = 0;
        }
    }
}
