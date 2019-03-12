namespace Training
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NeuralNet;

    public class Backpropagation
    {
        public static void Train(NeuralNetwork net, TrainingConfiguration config, TrainingSet trainingSet, Action<double> reportProgress)
        {
            Enumerable.Range(0, config.MaxEpoch)
                .ForEach(epochNo =>
                {
                    PerformTrainingEpoch(net, config, trainingSet);
                    var currentTotalError = ErrorFunctions.TotalError(net, trainingSet);
                    reportProgress(currentTotalError);
                });
        }

        private static void PerformTrainingEpoch(NeuralNetwork net, TrainingConfiguration config, TrainingSet trainingSet)
        {
            trainingSet.ForEach(sample =>
            {
                var netOutput = net.ForwardPass(sample.Input);
                var outputDeltas = netOutput.Zip(sample.Ideal, (actual, ideal) => OutputDelta(ideal, actual)).ToList();
                var outputWeightsAdjustments = outputDeltas
                    .Select(d => net.HiddenLayer.Select(h => h.LastOutput).Select(h => OutputWeightDelta(d, h)));

                var outputDeltaPairs = net.OutputLayer.Zip(outputDeltas, (output, oDelta) => new { output, oDelta });
                var outputWeightedDeltaSums = net.HiddenLayer
                    .Select((_, idx) => outputDeltaPairs
                        .Select(outputDeltaPair => outputDeltaPair.output.Weights[idx] * outputDeltaPair.oDelta)
                        .Sum());

                var hiddenDeltaPairs = net.HiddenLayer.Select(h => h.LastOutput)
                    .Zip(outputWeightedDeltaSums, (h, delta) => new { HiddenOutput = h, Delta = delta });

                var hiddenWeightsAdjustments =
                    hiddenDeltaPairs.Select(hd => sample.Input.Select(i => HiddenWeightDelta(hd.Delta, hd.HiddenOutput, i)));

                UpdateWeights(outputWeightsAdjustments, hiddenWeightsAdjustments, net, config);
            });
        }

        private static double OutputDelta(double idealOutput, double actualOutput) =>
            (actualOutput - idealOutput) * actualOutput * (1 - actualOutput);

        private static double OutputWeightDelta(double delta, double input) => delta * input;

        private static double HiddenWeightDelta(double outputWeightedDeltaSum, double hiddenOutput, double input) =>
            outputWeightedDeltaSum * hiddenOutput * (1 - hiddenOutput) * input;

        private static void UpdateWeights(IEnumerable<IEnumerable<double>> outputWeightsAdjustments, IEnumerable<IEnumerable<double>> hiddenWeightsAdjustments, NeuralNetwork net, TrainingConfiguration config)
        {
            net.OutputLayer.Zip(outputWeightsAdjustments, (o, deltas) => new { o, deltas })
                .ForEach(od => od.o.Weights = CalculateNewWeights(od.o.Weights, od.deltas, config.LearningRate));

            net.HiddenLayer.Zip(hiddenWeightsAdjustments, (h, deltas) => new { h, deltas })
                .ForEach(od => od.h.Weights = CalculateNewWeights(od.h.Weights, od.deltas, config.LearningRate));
        }

        private static double[] CalculateNewWeights(IEnumerable<double> oldWeights, IEnumerable<double> deltas, double learningRate) =>
            oldWeights.Zip(deltas, (o, n) => o - learningRate * n).ToArray();
    }
}