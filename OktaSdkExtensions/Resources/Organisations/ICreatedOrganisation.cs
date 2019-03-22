using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface ICreatedOrganisation : IOrganisation, IResource
    {
        string Token { get; }
        string TokenType { get; }
    }
}