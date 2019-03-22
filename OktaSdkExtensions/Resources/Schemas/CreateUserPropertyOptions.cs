using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class CreateUserPropertyOptions : Resource 
    {
        public ISchemaCustomDefinitionSet Definitions
        {
            get => GetResourceProperty<SchemaCustomDefinitionSet>("definitions");
            set => this["definitions"] = value;
        }
    }
}