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