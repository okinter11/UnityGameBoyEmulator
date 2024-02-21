using System;
using System.IO;
using GameBoy.Emulators.Common;
using GameBoy.Emulators.Common.Opcodes;
using UnityEngine;

namespace GameBoy.Emulators
{
    public class Emulator : MonoBehaviour
    {
        public const string TEST_ROM_PATH = @"Assets/Resources/ROMs/Legend of Zelda, The - Link's Awakening (G) [!].gb";
        public const string TEST_ROM_PATH2 = @"Assets/Resources/ROMs/Pokemon Red-Blue 2-in-1 (Unl) [S].gb";
        [HideInInspector] public byte[] romData = Array.Empty<byte>();

        private Cpu cpu = new Cpu();
        private void Awake()
        {
            romData = File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH));
            if (!Valid.CheckSum(romData, out string err))
            {
                Debug.LogError(err);
            }

            Debug.Log(new Info(romData).ToString());
            Debug.Log(new Info(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH2))).ToString());

            cpu.RomData = romData;
            cpu.ProgramCounter = 0x100;
            for (int i = 0; i < 10; i++)
            {
                CpuOp.Step(cpu);
            }
        }
    }
}