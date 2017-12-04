namespace Training
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet;

    public partial class Backpropagation
    {
        private readonly Func<double, double> _activationFunc;
        private readonly Func<double, double> _activationFuncDerived;

        public Backpropagation(Func<double, double> activationFunc, Func<double, double> activationFuncDerived)
        {
            _activationFunc = activationFunc;
            _activationFuncDerived = activationFuncDerived;
        }

        public static double TotalError(double[] ideal, double[] actual)
            => ideal.Zip(actual, (i, a) => i - a)
                .Select(diff => 0.5 * diff * diff)
                .Sum();

        public static void Train(NeuralNetwork network, TrainingConfiguration configuration, TrainingSet trainingSet)
        {

        }

        private double OutputDelta(double ideal, double actual, double input) => (actual - ideal) * actual * (1 - actual) * input;
        private double HiddenDelta() => 0;
    }
}