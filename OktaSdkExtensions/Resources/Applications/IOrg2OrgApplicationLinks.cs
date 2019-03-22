using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplicationLinks : IResource
    {
        IOktaLink MetaData{ get; set;}

        IList<IOktaLink> AppLinks{ get; set;}
    }
}