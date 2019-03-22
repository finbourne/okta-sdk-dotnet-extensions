using System.Collections.Generic;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class SchemaDefinitionProperty : Resource, ISchemaDefinitionProperty
    {
        public string Title
        {
            get => GetStringProperty("title");
            set => this["title"] = value;
        }
        
        public string Description
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        public string Type
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        public bool? Required
        {
            get => GetBooleanProperty("required");
            set => this["required"] = value;
        }
        
        public string Mutability
        {
            get => GetStringProperty("mutability");
            set => this["mutability"] = value;
        }
        
        public int? MaxLength
        {
            get => GetIntegerProperty("maxLength");
            set => this["maxLength"] = value;
        }
        
        
        public int? MinLength
        {
            get => GetIntegerProperty("minLength");
            set => this["minLength"] = value;
        }
        
        public string Scope
        {
            get => GetStringProperty("scope");
            set => this["scope"] = value;
        }
    
        public IList<string> Enum
        {
            get => GetArrayProperty<string>("enum");
            set => this["enum"] = value;
        }
        
        public IList<ISchemaDefinitionPermission> Permissions
        {
            get => GetArrayProperty<SchemaDefinitionPermission>("permissions")
                .CastToList<SchemaDefinitionPermission, ISchemaDefinitionPermission>();
            set => this["permissions"] = value;
        }
        
        public ISchemaDefinitionMaster Master
        {
            get => GetResourceProperty<SchemaDefinitionMaster>("master");
            set => this["master"] = value;
        }
    }
}