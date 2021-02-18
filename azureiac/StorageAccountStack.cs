using System;
using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;
using System.Collections.Generic;

class StorageAccountStack : Stack
{
    public StorageAccountStack()
    {
        var config = new Config();

        var tags = new Dictionary<string,string>{
            {"Environment","Development"},
            {"Owner","Romeel"},
            };
        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup("resourceGroup",
            new Pulumi.Azure.Core.ResourceGroupArgs
            {
                Location = "UKSouth", 
                Name = config.Require(StorageConfig.ResourceGroupName), //override auto-naming??,
                Tags = tags
            });
        // Create an Azure Storage Account
        var storageAccount = new Account("storage", new AccountArgs
        {
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            AccountReplicationType = config.Require(StorageConfig.StorageReplication),
            AccountTier = config.Require(StorageConfig.StorageAccountTier),
            EnableHttpsTrafficOnly = true,
            Tags = tags
        });

        // Export the connection string for the storage account
        this.ConnectionString = storageAccount.PrimaryConnectionString;
        this.StorageUri = storageAccount.PrimaryBlobEndpoint;

    }

    [Output]
    public Output<string> StorageUri { get; set; }

    [Output]
    public Output<string> ConnectionString { get; set; }
}
