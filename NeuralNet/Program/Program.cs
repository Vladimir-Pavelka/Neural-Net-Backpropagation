namespace Program
{
    using System;
    using System.Threading.Tasks;
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

            var learningProgressWindow = new SimpleChart { Text = "Learning Progress" };

            void ReportProgress(double value) =>
                learningProgressWindow.AddChartPoint(value);

            void Training() =>
                Backpropagation.Train(net, new TrainingConfiguration(0.1, 1024000, 0), trainingSet, ReportProgress);

            Task.Run((Action)Training);
            Application.Run(learningProgressWindow);
        }
    }
}
