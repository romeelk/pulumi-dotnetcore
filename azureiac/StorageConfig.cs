using System;
using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

class StorageConfig
{
    public const string ResourceGroupName = "resourceGroupName";
    public const string StorageReplication = "storageReplication";
    public const string StorageAccountTier = "storageAccountTier";
}
