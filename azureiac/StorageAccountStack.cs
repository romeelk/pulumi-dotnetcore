using System;
using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

class StorageAccountStack : Stack
{
    public StorageAccountStack()
    {
        var config = new Config();

        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup(config.Require("resourceGroup"));

        Console.WriteLine($"Storage resourceGroup: {config.Require("resourceGroup")}");

        // Create an Azure Storage Account
        var storageAccount = new Account("storage", new AccountArgs
        {
            ResourceGroupName = resourceGroup.Name,
            AccountReplicationType = "LRS",
            AccountTier = "Standard"
        });

        // Export the connection string for the storage account
        this.ConnectionString = storageAccount.PrimaryConnectionString;
    }

    [Output]
    public Output<string> ConnectionString { get; set; }
}
