# Using Pulumi for IaC

One of the issues I have faced when working with IaC tools such as Terraform and ARM template
is testability. DSL languages are good tools for use across diverse teams of developers and operations engineers.
For operations it provides a desired state, declarative approach to Cloud infrastructure. However, in my 
opinion DSL will always miss the rich features of languages like python or C#.

## Pulumi infastructure as actual code!

Pulumi allows you to write code in your favourite language. It supporst languages
such as python, javascript, c# and more.

The obvious benefit is your team can use their language of choice to write IaC.

## Pre-requisites

In this example i am using my Mac OS. For further details on other os please visit:https://www.pulumi.com/docs/get-started/azure/begin/

to install pulumi on Mac:

```
brew install pulumi
```

I am using dotnet core so have already installed the dotnet core 3.0 runtime.

Make sure you have installed azure cli:https://www.pulumi.com/docs/intro/cloud-providers/azure/setup/

## Creating your first project

In this example repo i created a folder called pulumi-dotnecore. To create a new pulumi project run the following command:

```
pulumi new projectname
```

Note when you run this you wull be redirected to the Pulumi portal where you will have to sign up if you have not already.

## Pulumi structure

The Pulumi cli will create a dotnet console project with the following structure:

```
-azureiac
    -Program.cs
    -Pulumi.dev.yaml
    -Pulumi.yaml
    -StorageAccountStack.cs
    -StorageAccountConfig.cs
    -UnitTest.cs
```

## A word about state

As you are aware Terraform requires state management of the tfstate file. And if you are using ARM there is no state file as it is managed by the ARM deployment.
Pulumi gives you the perception that it is similar to ARM when using the Pulumi service. However, this is not entirely true.
There is no state management in terms of a state file if you use the Pulumi service. But Pulumi tracks state via a checkpoint. This defaults to automatic
state management when starting with the Pulumi service. However, if that does not fit your requirement you can defer to a json state file locally or use a remote backend. Further info can be found here:
https://www.pulumi.com/docs/intro/concepts/state/


## The Pulumi inner loop

To deploy the above code Pulumi cli offers a similar concept to Terraform plan and apply.
Instead of plan you use Pulumi preview. To apply the changes you then use pulumi plan.

```
pulumi preview
Previewing update (dev)

View Live: https://app.pulumi.com/Khan/azureiac/dev/previews/8178ef36-8fee-4b6a-8026-3b53d6c53703

     Type                         Name           Plan       
 +   pulumi:pulumi:Stack          azureiac-dev   create     
 +   ├─ azure:core:ResourceGroup  resourceGroup  create     
 +   └─ azure:storage:Account     storage        create     
 
Resources:
    + 3 to create
```

When you are happy then use pulumi up:

```
pulumi up
Previewing update (dev)

View Live: https://app.pulumi.com/Khan/azureiac/dev/previews/8ad865af-806f-476e-ae30-bc20c23da746

     Type                         Name           Plan       
 +   pulumi:pulumi:Stack          azureiac-dev   create     
 +   ├─ azure:core:ResourceGroup  resourceGroup  create     
 +   └─ azure:storage:Account     storage        create     
 
Resources:
    + 3 to create

Do you want to perform this update?  [Use arrows to move, enter to select, type to filter]
  yes
> no
  details
```

# Unit tests

# Gotchas

Pulumi does not have a way to Mock configuration values. When i run dotnet test i get the following error

```
 Error Message:
   Pulumi.RunException : Running program '/Users/dummy/..../pulumi-dotnetcore/azureiac/bin/Debug/netcoreapp3.1/testhost.dll' failed with an unhandled exception:
System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
 ---> Pulumi.Config+ConfigMissingException: Missing Required configuration variable 'project:storageReplication'
	please set a value using the command `pulumi config set project:storageReplication <value>`
```

This is complaining about the project settings set in Pulumi.dev.yaml:

```
config:
  azure:location: ukwest
  azureiac:resourceGroupName: rg-mvp-ukw-storage
  azureiac:storageReplication: LRS
  azureiac:storageAccountTier: Standard

```

The workaround for this is https://github.com/pulumi/pulumi/issues/4472

export the above values as env vars:

```
export PULUMI_CONFIG='
{
	"project:resourceGroupName": "rg-mvp-ukw-storage",
	"project:storageReplication": "LRS",
	"project:storageAccountTier": "Standard "
}'
```