namespace Training
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TrainingSet : IEnumerable<TrainingSample>
    {
        private readonly IReadOnlyCollection<TrainingSample> _trainingSamples;

        public TrainingSet(IEnumerable<TrainingSample> trainingSamples)
        {
            _trainingSamples = trainingSamples.ToList();
        }

        public IEnumerator<TrainingSample> GetEnumerator() => _trainingSamples.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}