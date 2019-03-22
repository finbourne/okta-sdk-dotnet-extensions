using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;

namespace Finbourne.Extensions.Okta.Sdk.Utils
{
    public static class Saml2MessageParser
    {

        public static EntityDescriptorDetails ParseEntityDescriptor(string xml)
        {
            var xmlDocument = new XmlDocument()
            {
                PreserveWhitespace = true,
                XmlResolver = null,
            };
            xmlDocument.LoadXml(xml);

            var entityId = xmlDocument.DocumentElement?.GetAttribute("entityID") ?? throw new ArgumentException("The provided xml does not contain a valid EntityDescriptor with a valid and populated entityID attribute");

            var cert = xmlDocument.GetElementsByTagName("X509Certificate", "http://www.w3.org/2000/09/xmldsig#")
                .Item(0)?.FirstChild?.Value
                .Replace(Environment.NewLine,"") ?? throw new ArgumentException("The provided xml does not contain a valid EntityDescriptor root node"); 

            var ssoBindings = xmlDocument.GetElementsByTagName("SingleSignOnService", "urn:oasis:names:tc:SAML:2.0:metadata")
                .Cast<XmlNode>()
                .Where(x => x.Attributes != null)
                .ToDictionary(x => x.Attributes["Binding"].Value, x => x.Attributes["Location"].Value);

            var postSsoBinding = ssoBindings["urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST"];
            var postRedirectBinding = ssoBindings["urn:oasis:names:tc:SAML:2.0:bindings:HTTP-Redirect"];
            
            return new EntityDescriptorDetails(entityId, cert, postSsoBinding, postRedirectBinding);

        } 

        public class EntityDescriptorDetails
        {
            public string EntityId { get; }
            public string X509Certificate { get; }
            public string HttpPostSsoLocation { get; }
            public string HttpRedirectSsoLocation { get; }

            internal EntityDescriptorDetails(string entityId, string x509Certificate, string httpPostSsoLocation, string httpRedirectSsoLocation)
            {
                EntityId = entityId;
                X509Certificate = x509Certificate;
                HttpPostSsoLocation = httpPostSsoLocation;
                HttpRedirectSsoLocation = httpRedirectSsoLocation;
            }
        }
    }
}