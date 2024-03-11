using System;
using System.Diagnostics;
using System.IO;
using GameBoy.Emulators.Common;
using GameBoy.Emulators.Common.Opcodes;
using MagicOnion;
using MagicOnion.Client;
using MagicOnionService.Network.MagicOnionServer;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace GameBoy.Emulators
{
    public class Emulator : MonoBehaviour
    {
        public const string TEST_ROM_PATH = @"Assets/Resources/ROMs/Legend of Zelda, The - Link's Awakening (G) [!].gb";
        public const string TEST_ROM_PATH2 = @"Assets/Resources/ROMs/Pokemon Red-Blue 2-in-1 (Unl) [S].gb";
        public const string TEST_ROM_PATH3 = @"Assets/Resources/ROMs/Super Mario Land (JUE) (V1.1) [!].gb";
        [HideInInspector] public byte[] romData = Array.Empty<byte>();

        [SerializeField]
        private ulong clockCounter = 0;

        [SerializeField]
        private ushort programCounter = 0;

        private Cpu cpu = new();

        private bool isException = false;

        private void Awake()
        {
            romData = File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH3));
            if (!Valid.CheckSum(romData, out string err))
            {
                Debug.LogError(err);
                return;
            }

            cpu.ProgramCounter = 0x100;
            cpu.RomData = romData;
            isException = false;

            Debug.Log(new Info(romData).ToString());
            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH2))).ToString());
            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH))).ToString());
        }

        private async void Start()
        {
            // var channel = GrpcChannelx.ForTarget(new GrpcChannelTarget("localhost", 5000, ChannelCredentials.Insecure));
            GrpcChannelx channel = GrpcChannelx.ForAddress("http://localhost:5000");
            IMyFirstService client = MagicOnionClient.Create<IMyFirstService>(channel);

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                int left = Random.Range(1, 1000);
                int right = Random.Range(1, 1000);
                sw.Restart();
                int result = await client.SumAsync(left, right);
                sw.Stop();
                long microSeconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
                Debug.Log($"{left}+{right}={result} in {microSeconds} microSeconds");
            }
        }

        private void Update()
        {
            if (cpu != null
             && !isException
             && cpu.RomData != null
             && cpu.RomData.Length > 0)
            {
                try
                {
                    CpuOp.Step(cpu, Time.deltaTime);
                    clockCounter = cpu.ClockCounter;
                    programCounter = cpu.ProgramCounter;
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    isException = true;
                }
            }
        }
    }
}