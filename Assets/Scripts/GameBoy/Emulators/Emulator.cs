using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameBoy.Emulators.Common;
using GameBoy.Emulators.Common.Opcodes;
using MyUtils;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GameBoy.Emulators
{
    public class Emulator : Singleton<Emulator>
    {
        public const string TEST_ROM_PATH1 =
            @"Assets/Resources/ROMs/Legend of Zelda, The - Link's Awakening (G) [!].gb";
        public const string TEST_ROM_PATH2 = @"Assets/Resources/ROMs/Pokemon Red-Blue 2-in-1 (Unl) [S].gb";
        public const string TEST_ROM_PATH3 = @"Assets/Resources/ROMs/Super Mario Land (JUE) (V1.1) [!].gb";
        public const string TEST_ROM_PATH4 = @"Assets/Resources/ROMs/Dr. Mario (JU) (V1.1).gb";

        [HideInInspector] public byte[] romData = Array.Empty<byte>();

        [SerializeField]
        private ulong clockCounter = 0;

        [SerializeField]
        private ushort programCounter = 0;

        // private async void Start()
        // {
        //     // var channel = GrpcChannelx.ForTarget(new GrpcChannelTarget("localhost", 5000, ChannelCredentials.Insecure));
        //     GrpcChannelx channel = GrpcChannelx.ForAddress("http://localhost:5000");
        //     IMyFirstService client = MagicOnionClient.Create<IMyFirstService>(channel);
        //
        //     Stopwatch sw = Stopwatch.StartNew();
        //     for (int i = 0; i < 1000; i++)
        //     {
        //         int left = Random.Range(1, 1000);
        //         int right = Random.Range(1, 1000);
        //         sw.Restart();
        //         int result = await client.SumAsync(left, right);
        //         sw.Stop();
        //         long microSeconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
        //         Debug.Log($"{left}+{right}={result} in {microSeconds} microSeconds");
        //     }
        // }

        [SerializeField]
        private bool StepMode = false;

        [SerializeField]
        private bool StepNext;

        public Cpu cpu = new();

        private bool isException = false;
        
        public  LinkedList<string> log = new();
        [SerializeField]
        public bool isLog = true;
        [SerializeField]
        public bool isOutput = false;

        protected override void Awake()
        {
            base.Awake();
            DebugOpcode = new HashSet<byte>();
            romData = File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH4));
            if (!Valid.CheckSum(romData, out string err))
            {
                Debug.LogError(err);
                return;
            }

            cpu.ProgramCounter = 0x100;
            cpu.RomData = romData;
            isException = false;

            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH1))).ToString());
            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH2))).ToString());
            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH3))).ToString());
            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH4))).ToString());
        }

        public void ReloadRom(string fullPath)
        {
            var data = File.ReadAllBytes(Path.GetFullPath(fullPath));
            if (!Valid.CheckSum(data, out string err))
            {
                Debug.LogError(err);
                return;
            }
            else
            {
                Debug.Log(new Info(data).ToString());
            }
            
            DebugOpcode = new HashSet<byte>();
            romData = data;
            cpu = new Cpu();
            cpu.ProgramCounter = 0x100;
            cpu.RomData = romData;
            isException = false;
            StepMode = false;
            StepNext = false;
            log.Clear();
        }

        public HashSet<byte> DebugOpcode = new();

        private void Update()
        {
            if (isOutput)
            {
                isOutput = false;
                const string path = @"C:\Users\Lenovo\Desktop\log2.txt";
                File.WriteAllLines(path, log);
            }
            
            if (cpu != null
             && !isException
             && cpu.RomData != null
             && cpu.RomData.Length > 0)
            {
                if (!StepMode)
                {
                    try
                    {
                        CpuOp.Step(cpu, Time.deltaTime, DebugOpcode);
                        clockCounter = cpu.ClockCounter;
                        programCounter = cpu.ProgramCounter;
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                        isException = true;
                        Debug.LogWarning($"pc:{cpu.ProgramCounter:X4}");
                        byte opcode1 = Op.Read(cpu, cpu.ProgramCounter);
                        Debug.LogWarning($"pc:{opcode1:X4}");
                        byte opcode2 = Op.Read(cpu, (ushort)(cpu.ProgramCounter + 1));
                        Debug.LogWarning($"pc:{opcode2:X4}");
                        byte opcode3 = Op.Read(cpu, (ushort)(cpu.ProgramCounter + 2));
                        Debug.LogWarning($"pc:{opcode3:X4}");
                        byte opcode4 = Op.Read(cpu, (ushort)(cpu.ProgramCounter + 3));
                        Debug.LogWarning($"pc:{opcode4:X4}");

                        if (DebugOpcode != null)
                        {
                            Debug.LogWarning(string.Join(',', DebugOpcode
                                                             .OrderBy(o => o)
                                                             .Select(o => o.ToString("X2"))
                                                             .ToArray()));
                        }
                    }
                }
                else
                {
                    if (StepNext)
                    {
                        if (DebugOpcode != null)
                        {
                            Debug.Log(string.Join(',', DebugOpcode
                                                      .OrderBy(o => o)
                                                      .Select(o => o.ToString("X2"))
                                                      .ToArray()));
                        }

                        StepNext = false;
                        try
                        {
                            byte opcode1 = Op.Read(cpu, cpu.ProgramCounter);
                            byte opcode2 = Op.Read(cpu, (ushort)(cpu.ProgramCounter + 1));
                            byte opcode3 = Op.Read(cpu, (ushort)(cpu.ProgramCounter + 2));
                            byte opcode4 = Op.Read(cpu, (ushort)(cpu.ProgramCounter + 3));
                            Debug.Log(
                                $"pc:{cpu.ProgramCounter:X4},opcode:{opcode1:X2},{opcode2:X2},{opcode3:X2},{opcode4:X2}");
                            CpuOp.StepByExecutor(cpu, DebugOpcode);
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
    }
}