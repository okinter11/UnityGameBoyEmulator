#if MAGICONION_USE_GRPC_CCORE
using Grpc.Core;
#else
using Grpc.Net.Client;
#endif
using Cysharp.Net.Http;
using MagicOnion.Client;
using MagicOnion.Unity;
using MagicOnionService.Network.MagicOnionServer;
using MessagePack;
using MessagePack.Resolvers;
using UnityEngine;

namespace GameBoy.Network
{
    [MagicOnionClientGeneration(typeof(IMyFirstService))]
    internal partial class MagicOnionClientInitializer
    {
    }

    public class GrpcInit
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RegisterResolvers()
        {
            // NOTE: Currently, CompositeResolver doesn't work on Unity IL2CPP build. Use StaticCompositeResolver instead of it.
            StaticCompositeResolver.Instance.Register(
                MagicOnionClientInitializer.Resolver,
                GeneratedResolver.Instance,
                BuiltinResolver.Instance,
                PrimitiveObjectResolver.Instance
            );

            MessagePackSerializer.DefaultOptions = MessagePackSerializer.DefaultOptions
                                                                        .WithResolver(StaticCompositeResolver.Instance);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnRuntimeInitialize()
        {
            #if !MAGICONION_USE_GRPC_CCORE
            // Use Grpc.Net.Client instead of C-core gRPC library.
            GrpcChannelProviderHost.Initialize(
                new GrpcNetClientGrpcChannelProvider(() => new GrpcChannelOptions()
                {
                    HttpHandler = new YetAnotherHttpHandler()
                    {
                        Http2Only = true,
                    },
                }));
            #endif
            #if MAGICONION_USE_GRPC_CCORE
            // Initialize gRPC channel provider when the application is loaded.
            GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(new GrpcCCoreChannelOptions(new[]
            {
                // send keepalive ping every 5 second, default is 2 hours
                new ChannelOption("grpc.keepalive_time_ms", 5000),
                // keepalive ping time out after 5 seconds, default is 20 seconds
                new ChannelOption("grpc.keepalive_timeout_ms", 5 * 1000),
            })));

            // NOTE: If you want to use self-signed certificate for SSL/TLS connection
            //var cred = new SslCredentials(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "server.crt")));
            //GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(new GrpcCCoreChannelOptions(channelCredentials: cred)));
            #endif
        }
    }
}