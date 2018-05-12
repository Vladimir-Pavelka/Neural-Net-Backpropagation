namespace Tests
{
    using System.Linq;
    using NeuralNet;

    public class NeuralNetTestSetup
    {
        public static NeuralNetwork GetConfiguredNet()
        {
            var net = new NeuralNetwork(2, 2, 2, ActivationFunctions.Sigmoid);

            net.HiddenLayer.First().Weights[0] = 0.15;
            net.HiddenLayer.First().Weights[1] = 0.20;
            net.HiddenLayer.First().Bias = 0.35;
            net.HiddenLayer.Last().Weights[0] = 0.25;
            net.HiddenLayer.Last().Weights[1] = 0.30;
            net.HiddenLayer.Last().Bias = 0.35;

            net.OutputLayer.First().Weights[0] = 0.40;
            net.OutputLayer.First().Weights[1] = 0.45;
            net.OutputLayer.First().Bias = 0.60;
            net.OutputLayer.Last().Weights[0] = 0.50;
            net.OutputLayer.Last().Weights[1] = 0.55;
            net.OutputLayer.Last().Bias = 0.60;

            return net;
        }
    }
}