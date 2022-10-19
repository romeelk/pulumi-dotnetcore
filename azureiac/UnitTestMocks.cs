// using System.Collections.Immutable;
// using System.Threading.Tasks;
// using Pulumi.Testing;

// namespace UnitTesting
// {
//     class Mocks : IMocks
//     {
//         public Task<(string id, object state)> NewResourceAsync(
//             string type, string name, ImmutableDictionary<string, object> inputs, string? provider, string? id)
//         {
//             var outputs = ImmutableDictionary.CreateBuilder<string, object>();

//             // Forward all input parameters as resource outputs, so that we could test them.
//             outputs.AddRange(inputs);

//             // <-- We'll customize the mocks here

//             // Default the resource ID to `{name}_id`.
//             id ??= $"{name}_id";
//             return Task.FromResult((id, (object)outputs));
//         }

//         public Task<object> CallAsync(string token, ImmutableDictionary<string, object> inputs, string? provider)
//         {
//             // We don't use this method in this particular test suite.
//             // Default to returning whatever we got as input.
//             return Task.FromResult((object)inputs);
//         }
//     }
// }