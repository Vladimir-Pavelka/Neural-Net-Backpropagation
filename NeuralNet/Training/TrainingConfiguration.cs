namespace Training
{
    public class TrainingConfiguration
    {
        public double LearningRate { get; }
        public int MaxEpoch { get; }
        public double StopError { get; }

        public TrainingConfiguration(double learningRate, int maxEpoch, double stopError)
        {
            LearningRate = learningRate;
            MaxEpoch = maxEpoch;
            StopError = stopError;
        }
    }
}