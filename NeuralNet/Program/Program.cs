namespace Program
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Threading;
    using NeuralNet;
    using Training;
    using Charting;

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var net = new NeuralNetwork(2, 2, 1, ActivationFunctions.Sigmoid);
            var trainingSet = PopularProblems.Xor;
            var trainCfg = new TrainingConfiguration { LearningRate = 0.1, MaxEpoch = 1024000 };

            //Method1(net, trainingSet, trainCfg);
            var stopwatch = Stopwatch.StartNew();
            Method2(net, trainingSet, trainCfg);
            var elapsedMs = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void Method1(NeuralNetwork net, TrainingSet trainSet, TrainingConfiguration cfg)
        {
            var chartWindow = new SimpleChart();

            Task.Run(() =>
                Backpropagation.Train(net, cfg, trainSet, x => chartWindow.AddChartPoint(x))
            );

            Application.Run(chartWindow);
        }

        private static void Method2(NeuralNetwork net, TrainingSet trainSet, TrainingConfiguration cfg)
        {
            SimpleChart chartWindow = null;

            var chartThread = new Thread(() =>
            {
                chartWindow = new SimpleChart();
                chartWindow.FormClosed += (s, args) => Thread.CurrentThread.Abort();
                chartWindow.Show();
                Dispatcher.Run();
            });
            chartThread.SetApartmentState(ApartmentState.STA);
            chartThread.Start();
            while (chartWindow == null) Thread.Sleep(10);

            var dispatcher = Dispatcher.FromThread(chartThread);
            //dispatcher.Invoke(() => chartWindow.MinValueAxisY = 0.1);
            //dispatcher.Invoke(() => chartWindow.PointCountAxisX = 300);
            //dispatcher.Invoke(() => chartWindow.Text = "Yogo");
            
            Backpropagation.Train(net, cfg, trainSet,
                x => chartWindow.AddChartPoint(x));
        }
    }
}
