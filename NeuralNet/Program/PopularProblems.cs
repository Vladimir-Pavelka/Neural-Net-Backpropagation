namespace Program
{
    using Training;

    public class PopularProblems
    {
        public static readonly TrainingSet Xor =
            new TrainingSet(new[]
            {
                new TrainingSample(new[] {0d, 0}, new[] {0d}),
                new TrainingSample(new[] {0d, 1}, new[] {1d}),
                new TrainingSample(new[] {1d, 0}, new[] {1d}),
                new TrainingSample(new[] {1d, 1}, new[] {0d})
            });
    }
}