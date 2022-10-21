using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi;
using Pulumi.Testing;
using Moq;

namespace Infrastructure.UnitTesting
{

    /// <summary>
    /// Helper methods to streamlines unit testing experience.
    /// </summary>
    public static class Testing
    {
        /// <summary>
        /// Run the tests for a given stack type.
        /// </summary>
        public static Task<ImmutableArray<Resource>> RunAsync<T>() where T : Stack, new()
        {
            var mocks = new Mock<IMocks>();
            mocks.Setup(m => m.NewResourceAsync(It.IsAny<MockResourceArgs>()))
                .ReturnsAsync((MockResourceArgs args) => (args.Id ?? "", args.Inputs));
            mocks.Setup(m => m.CallAsync(It.IsAny<MockCallArgs>()))
                .ReturnsAsync((MockCallArgs args) => args.Args);
            return Deployment.TestAsync<T>(mocks.Object, new TestOptions { IsPreview = false });
        }

        /// <summary>
        /// Extract the value from an output.
        /// </summary>
        public static Task<T> GetValueAsync<T>(this Output<T> output)
        {
            var tcs = new TaskCompletionSource<T>();
            output.Apply(v =>
            {
                tcs.SetResult(v);
                return v;
            });
            return tcs.Task;
        }
    }
}