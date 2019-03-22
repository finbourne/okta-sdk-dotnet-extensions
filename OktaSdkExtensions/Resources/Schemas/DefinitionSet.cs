namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class DefinitionSet : SchemaCustomDefinitionSet, ISchemaDefinitionSet
    {
        public ISchemaDefinition Base
        {
            get => GetResourceProperty<SchemaDefinition>("base");
            set => this["base"] = value;
        }        
    }
}