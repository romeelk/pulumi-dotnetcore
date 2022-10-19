using Pulumi;
using Pulumi.Azure.Core;

class StorageAccountStack : Stack
{
    public StorageAccountStack()
    {
        var resourceGroup = new ResourceGroup("adasdasd", new ResourceGroupArgs { Location = "uksouth" });
    }

    public StorageAccountStack WithResourceGroup(string resourceGroupName)
    {
        var resourceGroup = new ResourceGroup("adasdasd", new ResourceGroupArgs { Location = "uksouth" });

        return this;
    }

    [Output("staticEndpoint")]
    public Output<string> StaticEndpoint { get; set; }

    [Output("cdnEndpoint")]
    public Output<string> CdnEndpoint { get; set; }
}
