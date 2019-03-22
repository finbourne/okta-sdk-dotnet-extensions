using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Finbourne.Extensions.Okta.Sdk.Utils;
using NUnit.Framework;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    public class ResourceExtensionsTests
    {
        [Test]
        public void CanDoADeepEquals()
        {
            var user1 = new User()
            {
                Profile = new UserProfile()
                {
                    Email = "TestEmail",
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    Login = "TestLogin",
                    MobilePhone = "TestMobilePhone",
                    SecondEmail = "TestSecondEmail"
                },
                Credentials = new UserCredentials()
                {
                    Emails = new List<IEmailAddress>
                    {
                        new EmailAddress() {["address"] = "test address"}

                    }
                }
            };

            var user2 = new User()
            {
                Profile = new UserProfile()
                {
                    Email = "TestEmail",
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    Login = "TestLogin",
                    MobilePhone = "TestMobilePhone",
                    SecondEmail = "TestSecondEmail"
                },
                Credentials = new UserCredentials()
                {
                    Emails = new List<IEmailAddress>
                    {
                        new EmailAddress() {["address"] = "test address"}

                    }
                }
            };

            
            var user3 = new User()
            {
                Profile = new UserProfile()
                {
                    Email = "TestEmail",
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    Login = "TestLogin",
                    MobilePhone = "TestMobilePhone",
                    SecondEmail = "TestSecondEmail"
                },
                Credentials = new UserCredentials()
                {
                    Emails = new List<IEmailAddress>
                    {
                        //Additional character on email address
                        new EmailAddress() {["address"] = "test address2"}
                    }
                }
            };
            Assert.IsTrue(user1.DeepEquals((IUser)user1));
            Assert.IsFalse(user1.DeepEquals((IUser)user3));
        }
    }

    
    
    
}