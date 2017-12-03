namespace NeuralNet
{
    using System.Collections.Generic;
    using System.Linq;

    public class NeuralNetwork
    {
        public IEnumerable<Neuron> HiddenLayer { get; }
        public IEnumerable<Neuron> OutputLayer { get; }

        public NeuralNetwork(int inputCount, int hiddenCount, int outputCount)
        {

            HiddenLayer = Enumerable.Range(0, hiddenCount).Select(_ => new Neuron(inputCount)).ToList();
            OutputLayer = Enumerable.Range(0, outputCount).Select(_ => new Neuron(hiddenCount)).ToList();
        }


        public double[] ForwardPass(double[] input)
        {
            var hiddenLayerOutput = HiddenLayer.Select(neuron => neuron.Evaluate(input)).ToArray();
            var outputLayerOutput = OutputLayer.Select(neuron => neuron.Evaluate(hiddenLayerOutput)).ToArray();

            return outputLayerOutput;
        }
    }
}