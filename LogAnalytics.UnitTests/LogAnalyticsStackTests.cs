using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Infrastructure.UnitTesting;
using LogAnalyticsStack;
using Pulumi.AzureNative;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.OperationalInsights;
using System.Linq;

namespace LogAnalytics.UnitTests;

[TestClass]
public class LogAnalyticsStackTests
{
    [TestMethod]
    public async Task TestLogAnalyticsWorkspaceResourceGroupHaveTags()
    {
        //Arrange
        var expectedTagCount = 2; 
        // Check if tags are present on the law resource group
        var resources = await Testing.RunAsync<LogAnalyticsStack.LogAnalytics>();

        var rgInstance = resources.OfType<ResourceGroup>().FirstOrDefault();

        //Act
        Assert.IsNotNull(rgInstance);
        var tags = await Testing.GetValueAsync(rgInstance.Tags);

    
        //Assert
        Assert.AreEqual(expectedTagCount, tags.Count);
    }

    [TestMethod]
    public async Task LogAnalyticsWorkspaceRetentionPeriodShouldBeValid()
    {
        //Arrange
        var expectedRetentionIndays = 730; 
        // Check if tags are present on the law resource group
        var resources = await Testing.RunAsync<LogAnalyticsStack.LogAnalytics>();

        //Act
        var workspaceInstance = resources.OfType<Workspace>().FirstOrDefault();

        var actualRetentionInDays = await Testing.GetValueAsync(workspaceInstance.RetentionInDays);

        Assert.AreEqual(expectedRetentionIndays, actualRetentionInDays);
    }
}