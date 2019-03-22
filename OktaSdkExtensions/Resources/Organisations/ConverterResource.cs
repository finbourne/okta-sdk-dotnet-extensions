using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    internal class ConverterResource : Resource
    {
        /// <summary>
        /// Convert one resource to another (as all resources are just dictionaries of string to objects
        /// </summary>
        /// <param name="resource"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ConvertTo<T>(IResource resource)
            where T : Resource, new()
        {
            return new ConverterResource().Convert<T>(resource);
        }
        
        private T Convert<T>(IResource resource)
            where T : Resource, new()
        {
            this.SetProperty("_inner_", resource);
            return GetResourceProperty<T>("_inner_");
        }

        public static T CloneTo<T>(IResource resource)
            where T : Resource, new()
        {
            var result = new Resource();
            foreach (var property in resource.GetData())
            {
                result.SetProperty(property.Key, property.Value);
            }

            return ConvertTo<T>(result);
        }
    }
}