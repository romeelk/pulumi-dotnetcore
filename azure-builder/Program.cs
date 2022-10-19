using azurebuilder;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;
using System;
using System.Collections.Generic;

return await Pulumi.Deployment.RunAsync(() =>
{
    var random = new Random();
    var number = random.Next(100);
    var storageAccntName = $"pulumistg{number}";
    var resourceGroupName = "pulumi-rg";
    var storageAccntArgs = new StorageAccountArgs
    {
        AccountName = storageAccntName,
        ResourceGroupName = resourceGroupName,
        Sku = new SkuArgs
        {
            Name = SkuName.Standard_LRS
        },
        Kind = Kind.StorageV2
    };
    var rgTags = new Dictionary<string, string>(){
        {"costCenter","finance"},
        {"location","UK"}
    };
    var stack = new StackBuilder()
    .WithResourceGroup(resourceGroupName, rgTags)
    .WithStorageAccount(storageAccntName, storageAccntArgs);
});