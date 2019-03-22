using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class SchemaDefinitionPermission : Resource, ISchemaDefinitionPermission
    {
        public string Principal
        {
            get => GetStringProperty("principal");
            set => this["principal"] = value;
        }
        
        public string Action
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }
    }
}