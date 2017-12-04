namespace Training
{
    public class TrainingSample
    {
        public double[] Input { get; }
        public double[] Ideal { get; }

        public TrainingSample(double[] input, double[] ideal)
        {
            Input = input;
            Ideal = ideal;
        }
    }
}