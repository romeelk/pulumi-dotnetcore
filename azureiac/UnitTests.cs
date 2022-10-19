// using NUnit;
// using NUnit.Framework;
// using System.Linq;
// using System.Threading.Tasks;
// using FluentAssertions;
// using Pulumi;
// using Pulumi.Azure.Core;
// using System.Collections.Immutable;
// using Pulumi.Testing;
// using System.Text.RegularExpressions;

// namespace UnitTesting
// {
//     [TestFixture]
//     public class StorageStackUnitTest
//     {
//         [Test]
//         public async Task ResourceGroupShouldHaveTwoTags()
//         {
//             var resources = await TestAsync();

//             var resourceGroup = resources.OfType<ResourceGroup>().First();

//             var tags = await resourceGroup.Tags.GetValueAsync();
    
//             tags.Should().HaveCount(2);
//         }

//         [Test]
//         public async Task ResourceGroupShouldMatchPattern()
//         {
//             var resources = await TestAsync();

//             var resourceGroup = resources.OfType<ResourceGroup>().First();

//             var regex = new Regex(@"^rg-\w{3}-\w{3}-storage$");
//             var result = await resourceGroup.Name.GetValueAsync();
//             var match = regex.Match(result);
//             match.Success.Should().Be(true);
//         }
//         private static Task<ImmutableArray<Resource>> TestAsync()
//         {
//             return Deployment.TestAsync<StorageAccountStack>(new Mocks(), new TestOptions { IsPreview = false });
//         }
//     }
// }
