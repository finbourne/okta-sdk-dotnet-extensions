using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk
{
    public interface IOktaLink : IResource
    {
        string Href { get; set;}
            
        string Type  { get; set;}
            
        string Name  { get; set;}
    }
}