using System;
using System.Collections.Generic;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;

namespace azurebuilder
{
    public class StackBuilder
    {
        private ResourceGroup? _resourceGroup;
        private StorageAccount? _storageAccount;

        public ResourceGroup? ResourceGroup { get => _resourceGroup; set => _resourceGroup = value; }
        public StorageAccount? StorageAccount { get => _storageAccount; set => _storageAccount = value; }

        public StackBuilder WithResourceGroup(string resourceGroupName, Dictionary<string,string> tags, string location = "uksouth")
        {
            ResourceGroup = new ResourceGroup(resourceGroupName, new ResourceGroupArgs(){ResourceGroupName = resourceGroupName,
                                                                                         Location = location, Tags = tags});
            return this; 
        }
        public StackBuilder WithStorageAccount(string storageAccountName, StorageAccountArgs args)
        {
            StorageAccount = new StorageAccount(storageAccountName, args);
            
            return this;
        }
    }
}