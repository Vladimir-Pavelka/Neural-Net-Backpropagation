namespace Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using NeuralNet;
    using Training;
    using Charting;

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var net = new NeuralNetwork(2, 3, 1, ActivationFunctions.Sigmoid);
            var trainingSet = PopularProblems.Xor;
            var trainingProgress = new List<double>();
            Backpropagation.Train(net, new TrainingConfiguration(0.1, 100000, 0), trainingSet, trainingProgress);

            //trainingProgress = Enumerable.Range(0, 1001)
            //    .Select(x => (double)x)
            //    .Select(x => x / 1000)
            //    .Select(x => ErrorFunctions.TotalError(new[] { x }, new[] { 0.0 }))
            //    .ToList();

            var learningProgressWindow = new LearningProgress();
            learningProgressWindow.SetChartSeries(trainingProgress);
            Application.Run(learningProgressWindow);
        }
    }
}
