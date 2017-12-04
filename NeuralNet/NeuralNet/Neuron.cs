namespace NeuralNet
{
    using System;
    using System.Linq;

    public class Neuron
    {
        private readonly Func<double, double> _activationFunc;
        public double[] Weights { get; }
        public double Bias { get; set; }
        public double[] LastInput { get; private set; }
        public double LastOutput { get; private set; }

        public Neuron(int inputCount, Func<double, double> activationFunc)
        {
            _activationFunc = activationFunc;
            Weights = InitialValues(inputCount);
            Bias = InitialValue();
        }

        public double Evaluate(double[] input)
        {
            var dotProduct = input.Zip(Weights, (inputValue, weight) => inputValue * weight).Sum();
            return _activationFunc(dotProduct + Bias);
        }

        private static double[] InitialValues(int count) => Enumerable.Range(0, count).Select(_ => InitialValue()).ToArray();
        private static double InitialValue() => 0.5;
    }
}