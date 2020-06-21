using System;
using System.Runtime.Serialization;

namespace NeuralNetworkClasses
{
    [DataContract]
    public class Neuron
    {
        [DataMember]
        public double[] Weights { get; set; }
        [DataMember]
        public double Output { get; set; }
        [DataMember]
        private int CountWeight { get; set; }
        public Neuron(int count)
        {
            Weights = new double[count];
            CountWeight = count;
            SetRandomWeights();
        }
        public Neuron()
        {
            Weights = new double[1];
            Output = 0;
            CountWeight = 1;
        }
        private void SetRandomWeights()
        {
            var rnd = new Random();
            for (int i = 0; i < CountWeight; i++)
            {
                Weights[i] = rnd.NextDouble();
            }
        }
        public Neuron(double[] inputsWeight)
        {
            Weights = new double[inputsWeight.Length];
            Weights = inputsWeight;
            CountWeight = inputsWeight.Length;
            //TODO: recieve weights from JSON.
        }
        public double CalculateOutput(double[] comingSignals)
        {
            Output = 0;
            if (comingSignals.Length != CountWeight)
            {
                throw new Exception("Not valid count of weights");
            }
            else
            {
                for (int i = 0; i < CountWeight; i++)
                {
                    Output += Weights[i] * comingSignals[i];
                }
            }
            return Output;
        }
        public override string ToString()
        {
            return $"[{Output}]";
        }
    }
}
