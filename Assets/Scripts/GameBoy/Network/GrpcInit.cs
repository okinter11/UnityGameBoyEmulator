using System;
using Cysharp.Net.Http;
using Grpc.Net.Client;
using MagicOnion.Unity;
using UnityEngine;

namespace GameBoy.Network
{
    public class GrpcInit : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnRuntimeInitialize()
        {
            // Initialize gRPC channel provider when the application is loaded.
            GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(() => new GrpcChannelOptions()
            {
                HttpHandler = new YetAnotherHttpHandler()
                {
                    Http2Only = true,
                },
                DisposeHttpClient = true,
            }));
        }
    }
}