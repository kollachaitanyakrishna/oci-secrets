## Read secrets from OCI Vault

### OCI vault feature

### Secrets
Used to store any cryptographic information like passwords, key-phrases, senstive data.

Sample code 
```
    using (var client = new SecretsClient(provider, new ClientConfiguration()))
    {
        var response = await client.GetSecretBundle(getSecretBundleRequest);
        // Retrieve value from the response.
        Base64SecretBundleContentDetails secretIdValue = (Base64SecretBundleContentDetails)response.SecretBundle.SecretBundleContent;
        Console.WriteLine(JsonSerializer.Serialize(secretIdValue));
    }
```

Pre-requesite to use this sample
1) Install visual code, [link](https://code.visualstudio.com/)
2) clone the repo
3) Add below packages
```
dotnet add package OCI.DotNetSDK.Core
dotnet add package OCI.DotNetSDK.Identity
dotnet add package OCI.DotNetSDK.Secrets
```
4) Create a vault, key, secret in OCI. 
5) Configure the OCI .net SDK [link](https://docs.oracle.com/en-us/iaas/Content/API/SDKDocs/dotnetsdkgettingstarted.htm#Configure)
    
    note: config region and vault region should be same.
How to run?

```
dotnet run
```

Reference sample code:
https://docs.oracle.com/en-us/iaas/tools/dot-net-examples/32.1.0/secrets/GetSecretBundle.cs.html