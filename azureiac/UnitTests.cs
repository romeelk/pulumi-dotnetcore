using NUnit;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Pulumi;
using Pulumi.Azure.Core;
using System.Collections.Immutable;
using Pulumi.Testing;

namespace UnitTesting
{
    [TestFixture]
    public class StorageStackUnitTest
    {
        [Test]
        public async Task ResourceGroupShouldHaveEnvironmentTag()
        {
            var resources = await TestAsync();

            var resourceGroup = resources.OfType<ResourceGroup>().First();

            var tags = await resourceGroup.Tags.GetValueAsync();
            tags.Should().NotBeNull("Tags must be defined");
            tags.Should().ContainKey("Environment");
            tags.Should().ContainKey("Owner");
            tags.Should().HaveCount(2);
        }

        private static Task<ImmutableArray<Resource>> TestAsync()
        {
            return Deployment.TestAsync<StorageAccountStack>(new Mocks(), new TestOptions { IsPreview = false });
        }
    }
}
