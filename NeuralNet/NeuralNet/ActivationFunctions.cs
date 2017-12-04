namespace NeuralNet
{
    using System;

    public static class ActivationFunctions
    {
        public static double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

        public static double SigmoidDerived(double x)
        {
            var s = Sigmoid(x);
            return s * (1 - s);
        }
    }
}