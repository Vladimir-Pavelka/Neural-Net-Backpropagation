namespace NeuralNet
{
    using System;
    using System.Linq;

    public class Neuron
    {
        public double[] Weights { get; }
        public double Bias { get; set; }

        public Neuron(int inputCount)
        {
            Weights = InitialValues(inputCount);
            Bias = InitialValue();
        }

        public double Evaluate(double[] input)
        {
            var dotProduct = input.Zip(Weights, (inputValue, weight) => inputValue * weight).Sum();
            return Sigmoid(dotProduct + Bias);
        }

        private static double[] InitialValues(int count) => Enumerable.Range(0, count).Select(_ => InitialValue()).ToArray();
        private static double InitialValue() => 0.5;

        private static double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

        private static double SigmoidDerived(double x)
        {
            var s = Sigmoid(x);
            return s * (1 - s);
        }
    }
}