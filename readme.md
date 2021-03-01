:warning: __This code is not yet planned to be actively maintained in this repo and could be removed without warning. If you're interested on using or working on this code please get in touch.__


# Extensions to the Okta.SDK
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ffinbourne%2Fokta-sdk-dotnet-extensions.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Ffinbourne%2Fokta-sdk-dotnet-extensions?ref=badge_shield)


This project contains our extensions to Okta's published .NET SDK. These were created in order to take advantage of features that Okta expose through their APIs but haven't yet included in their .NET SDK.

This work was produced without any consultation from Okta, and the code presented here is in no way associated with Okta other than the obvious (it uses their API, and extends their SDKs). We're just another Okta customer too impatient to wait for them to update their SDKs.

The extensions included in this package are not comprehensive and do not represent the whole breadth of Okta's API, simply those we needed to implement for our own purposes.

_NOTE: Some of the APIs used by these extensions are Okta's internal APIs (intended for exclusive use by their own website and applications). As such there is no guarantee that they won't break tomorrow or substantially change without warning._


## Specifications

This code is written for the .NET Standard 2.0 framework.

All of the integrations have been written in a style consistent with how the Okta SDK works currently.

## Usage

The additional functionality is wired in through extension methods on either the `IOktaClient` class (where the extension is a method call) or from the appropriate resource specific client (where the extension is an additional result/request shape (e.g. retrieving an Open Id Connect Application).

E.g. To create a trusted origin
```c#
var options = new CreateTrustedOriginOptions()
{
    Name = "Main Website Origin",
    Origin = "https://mywebsite.trusted.com",
    Scopes = new List<ITrustedOriginScope>()
    {
        new TrustedOriginScope(){ Type = "CORS"},
        new TrustedOriginScope(){ Type = "REDIRECT"}
    }
};

var trustedOrigin = await client.TrustedOrigins().CreateTrustedOrigin(options, CancellationToken.None);

```

As usage of the extensions is done through the existing SDK client, the configuration requirements and process are consistent with what they are for the base Okta .NET SDK. 


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ffinbourne%2Fokta-sdk-dotnet-extensions.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Ffinbourne%2Fokta-sdk-dotnet-extensions?ref=badge_large)