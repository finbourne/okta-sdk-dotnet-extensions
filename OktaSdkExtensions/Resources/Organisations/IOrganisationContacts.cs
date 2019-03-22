namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationContacts
    {
        ILocation Organization { get; set; }
        IEndUserSupport Support { get; set; }
    }
}