using System;
using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class Schema : Resource, ISchema
    {
        public string Id 
        { 
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        
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
        
        public string Name 
        { 
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        
        public DateTimeOffset? Created 
        { 
            get => GetDateTimeProperty("created");
            set => this["created"] = value;
        }
        
        public DateTimeOffset? LastUpdated 
        { 
            get => GetDateTimeProperty("lastUpdated");
            set => this["lastUpdated"] = value;
        }
        
        public string Type 
        { 
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        public IList<string> Schemas 
        { 
            get => GetArrayProperty<string>("schemas");
            set => this["schemas"] = value;
        }
        
        public bool? IsDefault 
        { 
            get => GetBooleanProperty("isDefault");
            set => this["isDefault"] = value;
        }
        
        
        public ISchemaDefinitionSet Definitions 
        { 
            get => GetResourceProperty<DefinitionSet>("definitions");
            set => this["definitions"] = value;
        }
    }
}