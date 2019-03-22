using System.Collections.Generic;
using System.Linq;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class SchemaDefinition : Resource, ISchemaDefinition
    {
        public string Id
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }

        public string Type
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        public IList<string> Required
        {
            get => GetArrayProperty<string>("required");
            set => this["required"] = value;
        }
        
        public Resource Properties
        {
            get => GetResourceProperty<Resource>("properties");
            set => this["properties"] = value;
        }
        
        public IDictionary<string, ISchemaDefinitionProperty> GetProperties()
        {
            var resource = Properties;
            return resource.GetData().Keys.ToDictionary(k => k,
                v => (ISchemaDefinitionProperty)resource.GetProperty<SchemaDefinitionProperty>(v));
        }
    }
}