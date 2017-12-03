namespace Tests
{
    using FluentAssertions;
    using Training;
    using Xunit;

    public class BackpropagationTests
    {
        [Fact]
        public void When_TotalError_Invoked_Then_Result_Is_Correct()
        {
            var totalError = Backpropagation.TotalError(new[] { 0.01, 0.99 }, new[] { 0.75136507, 0.772928465 });

            totalError.Should().BeApproximately(0.298371109, 0.000001);
        }
    }
}