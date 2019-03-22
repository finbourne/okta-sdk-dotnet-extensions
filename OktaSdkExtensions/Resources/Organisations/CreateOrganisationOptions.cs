using System;
using Newtonsoft.Json;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class CreateOrganisationOptions : Resource
    {
        /// <summary>
        /// The sub domain of the org to be created
        /// </summary>
        [JsonProperty(PropertyName = "subdomain")]
        public string SubDomain
        {
            get => GetStringProperty("subdomain");
            set => this["subdomain"] = value;
        }

        /// <summary>
        /// The display name of the new organisation
        /// </summary>
        public string Name
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }

        /// <summary>
        /// The website of the company that owns the new org
        /// </summary>
        public string Website
        {
            get => GetStringProperty("website");
            set => this["website"] = value;
        }

        /// <summary>
        /// The Okta licence level of the org
        /// </summary>
        public string Edition
        {
            get => GetStringProperty("edition");
            set => this["edition"] = value;
        }

        /// <summary>
        /// Any licensing provisions related to the new org
        /// </summary>
        public IOrganisationLicensing Licensing
        {
            get => GetResourceProperty<OrganisationLicensing>("licensing");
            set => this["licensing"] = value;
        }

        /// <summary>
        /// The details of the user admin of the new org
        /// </summary>
        public IUser Admin
        {
            get => GetResourceProperty<User>("admin");
            set => this["admin"] = value;
        }

        public CreateOrganisationOptions(string subDomain, string name, string website, string edition, OrganisationLicensing licensing, User admin)
        {
            //Validate the parameters locally where appropriate
            IsPopulated(subDomain,nameof(subDomain));
            IsPopulated(name,nameof(name));
            IsPopulated(website,nameof(website));
            IsPopulated(edition,nameof(edition));

            IsNotNull(admin,$"{nameof(admin)}");
            IsNotNull(admin.Profile,$"{nameof(admin)}.{nameof(admin.Profile)}");
            IsPopulated(admin.Profile.Login,$"{nameof(admin)}.{nameof(admin.Profile)}.{nameof(admin.Profile.Login)}");
            IsPopulated(admin.Profile.FirstName,$"{nameof(admin)}.{nameof(admin.Profile)}.{nameof(admin.Profile.FirstName)}");
            IsPopulated(admin.Profile.LastName,$"{nameof(admin)}.{nameof(admin.Profile)}.{nameof(admin.Profile.LastName)}");
            IsPopulated(admin.Profile.Email,$"{nameof(admin)}.{nameof(admin.Profile)}.{nameof(admin.Profile.Email)}");
            
            IsNotNull(admin.Credentials,$"{nameof(admin)}.{nameof(admin.Credentials)}");
            IsPopulated(admin.Credentials.RecoveryQuestion.Question,$"{nameof(admin)}.{nameof(admin.Credentials)}.{nameof(admin.Credentials.RecoveryQuestion)}.{nameof(admin.Credentials.RecoveryQuestion.Question)}");
            IsPopulated(admin.Credentials.RecoveryQuestion.Answer,$"{nameof(admin)}.{nameof(admin.Credentials)}.{nameof(admin.Credentials.RecoveryQuestion)}.{nameof(admin.Credentials.RecoveryQuestion.Answer)}");
            IsNotNull(admin.Credentials.Password,$"{nameof(admin)}.{nameof(admin.Credentials.Password)}");
            IsPopulated(admin.Credentials.Password.Value,$"{nameof(admin)}.{nameof(admin.Credentials)}.{nameof(admin.Credentials.Password)}.{nameof(admin.Credentials.Password.Value)}");
            
            SubDomain = subDomain;
            Name = name;
            Website = website;
            Edition = edition;
            Admin = admin;
            Licensing = licensing ?? throw new ArgumentNullException(nameof(licensing));
            
            /* Local functions */
            /* Ensure that the provided string parameter has a non-whitespace non-zero length value */
            void IsPopulated(string parameter, string parameterName)
            {
                if (string.IsNullOrWhiteSpace(parameter))
                {
                    throw new ArgumentException("Value cannot be null or whitespace.", parameterName);
                }   
            }
            
            /* Ensure that the provided object parameter is not null */
            void IsNotNull(object parameter, string parameterName)
            {
                if (parameter == null)
                {
                    throw new ArgumentNullException(parameterName);
                }                
            }
        }

        public UpdateOrganisationOptions ToUpdateOptions() =>
            ConverterResource.ConvertTo<UpdateOrganisationOptions>(this);
    }
}