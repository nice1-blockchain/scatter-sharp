using EosSharp.Unity3D;
using Newtonsoft.Json;
using ScatterSharp.Core;
using ScatterSharp.Core.Api;
using ScatterSharp.Core.Storage;
using ScatterSharp.EosProvider;
using ScatterSharp.UnitTests;
using ScatterSharp.Unity3D;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using EosSharp.Core.Api.v1;
using EosSharp.Core.Exceptions;
using System.Threading.Tasks;
using UnityEngine.UI;
using Network = ScatterSharp.Core.Api.Network;

/// <summary>
/// The test scatter script.
/// </summary>

public class ScatterScript : MonoBehaviour
{
    [SerializeField] Text textUIDebug;

    /// <summary>
    /// Pushes the transaction.
    /// </summary>
    public async void PushTransaction()
    {
        try
        {
            ScatterSharp.Core.Api.Network network = new ScatterSharp.Core.Api.Network()
            {
                blockchain = ScatterConstants.Blockchains.EOSIO,
                host = "jungle3.cryptolions.io",
                port = 443,
                chainId = "2a02a0053e5a8cf73a56ba0fda11e4d92e0238a4a2aa74fccf46d5a910746840"
            };

            var fileStorage = new FileStorageProvider(Application.persistentDataPath + "/scatterapp.dat");
            using (var scatter = new Scatter(new ScatterConfigurator()
            {
                AppName = "UNITY-PC-SCATTER",
                Network = network,
                StorageProvider = fileStorage
            }, this))
            {
                await scatter.Connect();

                await scatter.GetIdentity(new IdentityRequiredFields()
                {
                    accounts = new List<ScatterSharp.Core.Api.Network>()
                {
                    network
                },
                    location = new List<LocationFields>(),
                    personal = new List<PersonalFields>()
                });

                var eos = new Eos(new EosSharp.Core.EosConfigurator()
                {
                    ChainId = network.chainId,
                    HttpEndpoint = network.GetHttpEndpoint(),
                    SignProvider = new ScatterSignatureProvider(scatter)
                });

                var account = scatter.Identity.accounts.First();

                var result = await eos.CreateTransaction(new EosSharp.Core.Api.v1.Transaction()
                {
                    actions = new List<EosSharp.Core.Api.v1.Action>()
                {
                    new EosSharp.Core.Api.v1.Action()
                    {
                        account = "eosio.token",
                        authorization =  new List<PermissionLevel>()
                        {
                            new PermissionLevel() { actor = account.name, permission = account.authority }
                        },
                        name = "transfer",
                        data = new Dictionary<string, object>()
                        {
                            { "from", account.name },
                            { "to", "eosio" },
                            { "quantity", "0.0001 EOS" },
                            { "memo", "Unity3D WEBGL hello crypto world!" }
                        }
                    }
                }
                });
                print(result);
                textUIDebug.text = "Transaction: " + result + "\n";

                /*GetTransactionResponse resultGetTransaction = await eos.GetTransaction(result);
                textUIDebug.text = "---------------------------\n" +
                    "Id: " + resultGetTransaction.id + "\n" +
                    "DateTime:  " + resultGetTransaction.block_time + "\n" +
                    "DetailedTransaction-> Transaction Receipt -> cpu usage " + resultGetTransaction.trx.receipt.cpu_usage_us + "\n" +
                    "block_num: " + resultGetTransaction.block_num + "\n" +
                    "last_irreversible_block: " + resultGetTransaction.last_irreversible_block;*/
     
                

            }
        }
        catch (ApiErrorException ex)
        {
            print(JsonConvert.SerializeObject(ex.error));
        }
        catch (ApiException ex)
        {
            print(ex.Content);
        }
        catch (Exception ex)
        {
            print(JsonConvert.SerializeObject(ex));
        }
    }

    /// <summary>
    /// Tests the all unit tests.
    /// </summary>
    public async void TestAllUnitTests()
    {
        var scatterUnitTests = new ScatterUnitTests(this);
        await scatterUnitTests.TestAll();
        textUIDebug.text = " TestAllUnitTests ";
    }

    /// <summary>
    /// Gets the account.
    /// </summary>
    /// <returns>A Task.</returns>
    public async void GetAccount()
    {
        try
        {
            ScatterSharp.Core.Api.Network network = new ScatterSharp.Core.Api.Network()
            {
                blockchain = ScatterConstants.Blockchains.EOSIO,
                host = "jungle3.cryptolions.io",
                port = 443,
                chainId = "2a02a0053e5a8cf73a56ba0fda11e4d92e0238a4a2aa74fccf46d5a910746840"
            };

            var fileStorage = new FileStorageProvider(Application.persistentDataPath + "/scatterapp.dat");
            using (var scatter = new Scatter(new ScatterConfigurator()
            {
                AppName = "UNITY-PC-SCATTER",
                Network = network,
                StorageProvider = fileStorage
            }, this))
            {
                await scatter.Connect();

                await scatter.GetIdentity(new IdentityRequiredFields()
                {
                    accounts = new List<ScatterSharp.Core.Api.Network>()
                {
                    network
                },
                    location = new List<LocationFields>(),
                    personal = new List<PersonalFields>()
                });

                var eos = new Eos(new EosSharp.Core.EosConfigurator()
                {
                    ChainId = network.chainId,
                    HttpEndpoint = network.GetHttpEndpoint(),
                    SignProvider = new ScatterSignatureProvider(scatter)
                });

                var account = scatter.Identity.accounts.First();

                // DEBUG 
                Debug.Log("Identity\n");
                print(scatter.Identity.hash);
                print(scatter.Identity.publicKey);
                print(scatter.Identity.name);
                print(scatter.Identity.kyc);

                Debug.Log("Account\n");
                print(account.name);
                print(account.authority);
                print(account.publicKey);
                print(account.blockchain);
                print(account.isHardware);
                print(account.chainId);

                // TEXT
                textUIDebug.text = "Identity \n" +
                    "Hash: " + scatter.Identity.hash + " \n" +
                    "PublicKey: " + scatter.Identity.publicKey + " \n" +
                    "Name: " + scatter.Identity.name + " \n" +
                    "KYC: " + scatter.Identity.kyc + " \n" +
                    " ----------------------------------- \n" +
                    "Account \n" +
                    "Name: " + account.name + " \n" +
                    "Authority: " + account.authority + " \n" +
                    "PublicKey: " + account.publicKey + " \n" +
                    "Blockchain: " + account.blockchain + "\n" +
                    "isHardware: " + account.isHardware + "\n" +
                    "chainId: " + account.chainId + "\n";
            }
        }
        catch (ApiErrorException ex)
        {
            print(JsonConvert.SerializeObject(ex.error));
            
        }
        catch (ApiException ex)
        {
            print(ex.Content);
           
        }
        catch (Exception ex)
        {
            print(JsonConvert.SerializeObject(ex));
           
        }
    }

}
