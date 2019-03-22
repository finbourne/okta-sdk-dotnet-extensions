using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Utils
{
    public static class ResourceExtensions
    {
        /// <summary>
        /// Compare two resource objects, all the way down.
        /// </summary>
        public static bool DeepEquals(this IResource left, IResource right)
        {
            var leftPairs = left.GetData();
            var rightPairs = right.GetData();

            return DeepEquals(leftPairs, rightPairs);
        }
        
        private static bool DeepEquals(IDictionary<string,object> leftPairs, IDictionary<string,object> rightPairs)
        {
            bool finalResult = false;
            bool firstTime = true;
            var leftMutual = leftPairs.Where(k => rightPairs.ContainsKey(k.Key));
            foreach (var leftP in leftMutual)
            {
                object leftHandSide = leftP.Value;
                object rightHandSide = rightPairs[leftP.Key];

                if (leftHandSide is Resource leftResource && rightHandSide is Resource rightResource)
                {
                    finalResult = (firstTime || finalResult) && DeepEquals(leftResource, rightResource);
                }
                else if (leftHandSide is IDictionary<string,object> leftDictionary && rightHandSide is IDictionary<string,object> rightDictionary)
                {
                    finalResult = (firstTime || finalResult) && DeepEquals(leftDictionary, rightDictionary);
                }
                else if (
                    leftHandSide.GetType().IsGenericType 
                    && leftHandSide.GetType().GetGenericTypeDefinition() == typeof(List<>).GetGenericTypeDefinition()
                    )
                {
                    var leftItems = ((IList) leftHandSide) as IEnumerable;
                    var rightItems = ((IList) rightHandSide) as IEnumerable;

                    if (rightItems == null)
                    {
                        return false;
                    }

                    var leftE = leftItems.GetEnumerator();
                    var rightE = rightItems.GetEnumerator();

                    bool compare = false;
                    bool firstCompare = true;
                    while (leftE.MoveNext())
                    {
                        if (!rightE.MoveNext())
                        {
                            return false;
                        }

                        if (leftE.Current is Resource lr && rightE.Current is Resource rr)
                        {
                            compare = (firstCompare || compare) && DeepEquals(lr, rr);
                        }
                        else
                        {
                            compare = (firstCompare || compare) && leftE.Current.Equals(rightE.Current);
                        }

                        if (firstCompare)
                        {
                            firstCompare = false;
                        }
                    }

                    finalResult = (firstTime || finalResult) && compare;
                }
                else
                {
                    finalResult = (firstTime || finalResult) && leftHandSide.Equals(rightHandSide);
                }

                if (firstTime)
                {
                    firstTime = false;
                }
            }

            return finalResult;
        }

        public static TOutput CloneTo<TOriginal, TOutput>(this TOriginal original)
            where TOriginal : IResource
            where TOutput : Resource, new()
        {
            return ConverterResource.CloneTo<TOutput>(original);
        }
            
        
    }
}