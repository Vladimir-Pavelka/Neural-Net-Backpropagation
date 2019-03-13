namespace Program
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Threading;
    using NeuralNet;
    using SimpleChart;
    using Training;

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var net = new NeuralNetwork(2, 2, 1, ActivationFunctions.Sigmoid);
            var trainingCfg = new TrainingConfiguration { LearningRate = 0.1, MaxEpoch = 512000 };
            var trainingSet = PopularProblems.Xor;

            var chartWindow = SimpleChart.LaunchInNewThread();
            chartWindow.Title = "Learning progress";

            Backpropagation.Train(net, trainingCfg, trainingSet, chartWindow.AddPoint);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
