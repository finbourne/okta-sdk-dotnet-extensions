using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Utils
{
    /// <summary>
    /// Extension methods to allow developers to ensure the existence of Okta resources
    /// </summary>
    public static  class EnsureResourceExtensions
    {
        
        
        /// <summary>
        /// Ensure that the user in the destination Okta tenant exists and exactly matches the provided one
        /// </summary>
        /// <param name="client">A configured Okta IUserClient</param>
        /// <param name="targetState">The target state of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public static async Task Ensure(this IUsersClient client, User targetState, CancellationToken cancellationToken)
        {
            var currentState = await GetIfExists(() => client.GetUserAsync(targetState.Profile.Login, cancellationToken));
            
            if (currentState.CurrentState != EntityState<IUser>.State.DoesNotExist)
            {
                //If it exists already, but doesn't match, then we need to override it
                await client.UpdateUserAsync(targetState, currentState.Entity.Id, cancellationToken);
            }
            else
            {
                await client.CreateUserAsync(targetState, 
                    activate:true, 
                    provider:false,  
                    nextLogin: null, //Don't prompt for password change
                    cancellationToken: cancellationToken);
            }
        }
        
        /// <summary>
        /// Ensure that the application in the destination okta tenant exists and exactly matches the provided one
        /// </summary>
        /// <param name="client"></param>
        /// <param name="targetState"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task EnsureApplication(this IOktaClient client, Application targetState, CancellationToken cancellationToken)
        {
            //Attempt to get the existing application by looking it up based on label
            var currentState = await GetIfExists(() =>
                client.GetAsync<Application>($"/api/v1/apps?q={Uri.EscapeDataString(targetState.Label)}",
                    cancellationToken));
                
            if (currentState.CurrentState != EntityState<Application>.State.DoesNotExist)
            {
                //If it exists already, but doesn't match, then we need to override it
                await client.Applications.UpdateApplicationAsync(targetState, currentState.Entity.Id, cancellationToken);
            }
            else
            {
                await client.Applications.CreateApplicationAsync(targetState, 
                    activate:true, 
                    cancellationToken: cancellationToken);
            }
        }

        //TODO Add authorization servers
        //TODO Add Auth server Policies
        //TODO Add User profiles (so we can add client)
        //TODO Add oauth2 scopes
        //TODO Add auth server rules
        //TODO Add CORS
        
        public static async Task<EntityState<T>> GetIfExists<T>(Func<Task<T>> getFunction)
        {
            try
            {
                return EntityState<T>.Exists(await getFunction());
            }
            catch (OktaApiException oie) when (oie.StatusCode == (int) HttpStatusCode.Forbidden)
            {
                return EntityState<T>.Exists();
            }
            catch (OktaApiException oie) when (oie.StatusCode == (int) HttpStatusCode.NotFound)
            {
                return EntityState<T>.DoesNotExist();
            }
            catch (AggregateException e) when (
                e.InnerExceptions.Count == 1 && e.InnerExceptions.Single() is OktaApiException oae
                                             && oae.StatusCode == (int) HttpStatusCode.NotFound)
            {

                return EntityState<T>.DoesNotExist();
            }
            catch (AggregateException e) when (
                e.InnerExceptions.Count == 1 && e.InnerExceptions.Single() is OktaApiException oae
                                             && oae.StatusCode == (int) HttpStatusCode.Forbidden)
            {

                return EntityState<T>.Exists();
            }
        }
        
        
        public static async Task<EntityState<T>> GetIfExists<T>(Func<Task<IEnumerable<T>>> getListFunction, Func<T, bool> selectionPredicate)
        {
            try
            {
                var list = (await getListFunction())
                    .Where(selectionPredicate)
                    .ToList();

                if (list.Any())
                {
                    return EntityState<T>.Exists(list.First());
                }
                return EntityState<T>.DoesNotExist();
                
            }
            catch (OktaApiException oie) when (oie.StatusCode == (int) HttpStatusCode.Forbidden)
            {
                return EntityState<T>.Exists();
            }
            catch (OktaApiException oie) when (oie.StatusCode == (int) HttpStatusCode.NotFound)
            {
                return EntityState<T>.DoesNotExist();
            }
            catch (AggregateException e) when (
                e.InnerExceptions.Count == 1 && e.InnerExceptions.Single() is OktaApiException oae
                                             && oae.StatusCode == (int) HttpStatusCode.NotFound)
            {

                return EntityState<T>.DoesNotExist();
            }
            catch (AggregateException e) when (
                e.InnerExceptions.Count == 1 && e.InnerExceptions.Single() is OktaApiException oae
                                             && oae.StatusCode == (int) HttpStatusCode.Forbidden)
            {

                return EntityState<T>.Exists();
            }
        }
    }
}