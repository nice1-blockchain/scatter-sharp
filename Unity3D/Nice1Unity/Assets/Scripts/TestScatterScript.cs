﻿using EosSharp.Unity3D;
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

public class TestScatterScript : MonoBehaviour
{
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

    public async void TestAllUnitTests()
    {
        var scatterUnitTests = new ScatterUnitTests(this);
        await scatterUnitTests.TestAll();
    }

    public async Task<IdentityAccount> GetAccount()
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

                return account;
            }
        }
        catch (ApiErrorException ex)
        {
            print(JsonConvert.SerializeObject(ex.error));
            return null;
        }
        catch (ApiException ex)
        {
            print(ex.Content);
            return null;
        }
        catch (Exception ex)
        {
            print(JsonConvert.SerializeObject(ex));
            return null;
        }
    }

}
