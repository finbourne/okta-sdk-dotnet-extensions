using System.Collections.Generic;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplicationLinks : Resource, IOrg2OrgApplicationLinks 
    {
        public IOktaLink MetaData
        {
            get => GetResourceProperty<OktaLink>("metadata");
            set => this["metadata"] = value;
        }

        public IList<IOktaLink> AppLinks
        {
            get => GetArrayProperty<OktaLink>("appLinks")
                .CastToList<OktaLink, IOktaLink>();
            set => this["appLinks"] = value;
        }   
    }
}