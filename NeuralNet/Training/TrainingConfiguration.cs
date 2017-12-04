namespace Training
{
    public partial class Backpropagation
    {
        public class TrainingConfiguration
        {
            public double LearningRate { get; }
            public double MaxEpoch { get; }

            public TrainingConfiguration(double learningRate, double maxEpoch)
            {
                LearningRate = learningRate;
                MaxEpoch = maxEpoch;
            }
        }
    }
}