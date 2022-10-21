using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi;
using Pulumi.AzureNative;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.OperationalInsights;
using Pulumi.AzureNative.OperationalInsights.Inputs;
using System.Collections.Generic;

namespace LogAnalyticsStack
{
    public class LogAnalytics : Stack
    {
        public LogAnalytics()
        {
            var rgTags = new Dictionary<string, string>(){
                            {"costCenter","finance"},
                              {"location","uk"}};
            var lawResourceGroup = "uks-law-rg";
            var lawLocation = "uksouth";
            // Create an Azure Resource Group
            var resourceGroup = new ResourceGroup(lawResourceGroup, new()
            {
                Location = lawLocation,
                ResourceGroupName = lawLocation,
                Tags = rgTags
            }); ;

            var workspace = new Workspace("workspace", new()
            {
                Location = lawResourceGroup,
                ResourceGroupName = lawResourceGroup,
                RetentionInDays = 30,
                Sku = new WorkspaceSkuArgs
                {
                    Name = "PerGB2018",
                },
                Tags =
                {
                    { "tag1", "val1" },
                },
                WorkspaceName = "testworkpace",
            });
        }
    }

}