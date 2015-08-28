/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.Composition;
using System.Web.Mvc;
using IdentityServer.Helper;
using IdentityServer.Repositories;

namespace IdentityServer.Protocols.FederationMetadata
{
    public class FederationMetadataController : Controller
    {
        public FederationMetadataController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public FederationMetadataController(IConfigurationRepository configurationRepository,
            ICacheRepository cacheRepository)
        {
            ConfigurationRepository = configurationRepository;
            CacheRepository = cacheRepository;
        }

        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        [Import]
        public ICacheRepository CacheRepository { get; set; }

        public ActionResult Generate()
        {
            if (ConfigurationRepository.FederationMetadata.Enabled)
            {
                return Cache.ReturnFromCache<ActionResult>(CacheRepository, Constants.CacheKeys.WSFedMetadata, 1, () =>
                {
                    var host = ConfigurationRepository.Global.PublicHostName;
                    if (string.IsNullOrWhiteSpace(host))
                    {
                        host = HttpContext.Request.Headers["Host"];
                    }
                    var endpoints = Endpoints.Create(
                        host,
                        HttpContext.Request.ApplicationPath,
                        ConfigurationRepository.Global.HttpPort,
                        ConfigurationRepository.Global.HttpsPort);

                    return new ContentResult
                    {
                        Content = new WSFederationMetadataGenerator(endpoints).Generate(),
                        ContentType = "text/xml"
                    };
                });
            }
            return new HttpNotFoundResult();
        }

        public ActionResult GenerateRPMetadata()
        {
            if (ConfigurationRepository.FederationMetadata.Enabled)
            {
                return Cache.ReturnFromCache<ActionResult>(CacheRepository, Constants.CacheKeys.WSFedRPMetadata, 1,
                    () =>
                    {
                        var host = ConfigurationRepository.Global.PublicHostName;
                        if (string.IsNullOrWhiteSpace(host))
                        {
                            host = HttpContext.Request.Headers["Host"];
                        }
                        var endpoints = Endpoints.Create(
                            host,
                            HttpContext.Request.ApplicationPath,
                            ConfigurationRepository.Global.HttpPort,
                            ConfigurationRepository.Global.HttpsPort);

                        return new ContentResult
                        {
                            Content = new WSFederationMetadataGenerator(endpoints).GenerateRelyingPartyMetadata(),
                            ContentType = "text/xml"
                        };
                    });
            }
            return new HttpNotFoundResult();
        }

        public ActionResult GenerateAZMetadata()
        {
            if (ConfigurationRepository.FederationMetadata.Enabled)
            {
                return Cache.ReturnFromCache<ActionResult>(CacheRepository, Constants.CacheKeys.WSFedAZMetadata, 1,
                    () =>
                    {
                        var host = ConfigurationRepository.Global.PublicHostName;
                        if (string.IsNullOrWhiteSpace(host))
                        {
                            host = HttpContext.Request.Headers["Host"];
                        }
                        var endpoints = Endpoints.Create(
                            host,
                            HttpContext.Request.ApplicationPath,
                            ConfigurationRepository.Global.HttpPort,
                            ConfigurationRepository.Global.HttpsPort);

                        return new ContentResult
                        {
                            Content = new WSFederationMetadataGenerator(endpoints).GenerateAzRelyingPartyMetadata(),
                            ContentType = "text/xml"
                        };
                    });
            }
            return new HttpNotFoundResult();
        }
    }
}