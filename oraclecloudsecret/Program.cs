using System;
using System.Threading.Tasks;

using Oci.Common;
using Oci.Common.Auth;
using System.Text.Json;
using Oci.SecretsService;
using Oci.SecretsService.Models;

namespace oraclecloudsecret
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private static int DefaultKeyLength = 32;

        static async Task Main(string[] args)
        {
            logger.Info("Initializing example");

            var provider = new ConfigFileAuthenticationDetailsProvider("DEFAULT");

            try
            {
                Console.WriteLine("Initializing ....");
                await GetSecret();
            }
            catch (Exception e)
            {
                logger.Error($"Failed to perform operations on Vault: {e}");
            }
            finally
            {


            }

            logger.Info("End example");
        }


        public static async Task GetSecret()
        {

            // Create a default authentication provider that uses the DEFAULT
            // profile in the configuration file.
            // Refer to <see href="https://docs.cloud.oracle.com/en-us/iaas/Content/API/Concepts/sdkconfig.htm#SDK_and_CLI_Configuration_File>the public documentation</see> on how to prepare a configuration file. 
            var provider = new ConfigFileAuthenticationDetailsProvider("DEFAULT");
            try
            {
                var getSecretBundleRequest = new Oci.SecretsService.Requests.GetSecretBundleRequest
                {

                    //TODO: Need to repelace this OCID with your configurations
                    SecretId = "ocid1.vaultsecret.oc1.ap-mumbai-1.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                };

                using (var client = new SecretsClient(provider, new ClientConfiguration()))
                {
                    var response = await client.GetSecretBundle(getSecretBundleRequest);
                    // Retrieve value from the response.
                    Base64SecretBundleContentDetails secretIdValue = (Base64SecretBundleContentDetails)response.SecretBundle.SecretBundleContent;
                    Console.WriteLine(JsonSerializer.Serialize(secretIdValue));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"GetSecret Failed with {e.Message}");
                throw e;
            }
        }
    }

}
