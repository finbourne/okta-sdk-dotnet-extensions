namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchemaDefinitionSet : ISchemaCustomDefinitionSet
    {
        ISchemaDefinition Base { get; set; }
    }
}