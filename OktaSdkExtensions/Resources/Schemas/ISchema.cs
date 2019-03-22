using System;
using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchema : IResource
    {
        string Id { get; set; }
        
        string Title  { get; set; }
        
        string Description  { get; set; }
        
        string Name  { get; set; }
        
        DateTimeOffset? Created  { get; set; }
        
        DateTimeOffset? LastUpdated  { get; set; }
        
        string Type  { get; set; }
        
        IList<string> Schemas { get; set; } 
        
        bool? IsDefault { get; set; } 
        
        ISchemaDefinitionSet Definitions { get; set; } 
        
    }
}