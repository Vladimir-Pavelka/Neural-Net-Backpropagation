namespace Training
{
    using System.Collections;
    using System.Collections.Generic;

    public class TrainingSet : IReadOnlyCollection<TrainingSample>
    {
        private readonly IReadOnlyCollection<TrainingSample> _trainingSamples;

        public TrainingSet(IReadOnlyCollection<TrainingSample> trainingSamples)
        {
            _trainingSamples = trainingSamples;
        }

        public IEnumerator<TrainingSample> GetEnumerator() => _trainingSamples.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _trainingSamples.Count;
    }
}