namespace NeuralNet
{
    using System;
    using System.Linq;

    public class Neuron
    {
        private readonly Func<double, double> _activationFunc;
        private static readonly Random Random = new Random();
        public double[] Weights { get; set; }
        public double Bias { get; set; }
        public double[] LastInput { get; private set; }
        public double LastOutput { get; private set; }

        public Neuron(int inputCount, Func<double, double> activationFunc)
        {
            _activationFunc = activationFunc;
            Weights = InitialWeightValues(inputCount);
            Bias = InitialValue();
        }

        public double Evaluate(double[] input)
        {
            var dotProduct = input.Zip(Weights, (inputValue, weight) => inputValue * weight).Sum();
            var output = _activationFunc(dotProduct + Bias);

            LastInput = input;
            LastOutput = output;

            return output;
        }

        private static double[] InitialWeightValues(int count) => Enumerable.Range(0, count).Select(_ => InitialValue()).ToArray();
        private static double InitialValue() => Random.NextDouble();
    }
}