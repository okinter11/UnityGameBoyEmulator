using System;
using System.IO;
using UnityEngine;

namespace Emulator
{
    public class GameBoyEmulator : MonoBehaviour
    {
        public const string TEST_ROM_PATH = @"Assets/Resources/ROMs/Legend of Zelda, The - Link's Awakening (G) [!].gb";
        public const string TEST_ROM_PATH2 = @"Assets/Resources/ROMs/Pokemon Red-Blue 2-in-1 (Unl) [S].gb";
        [HideInInspector] public byte[] romData = Array.Empty<byte>();

        private void Awake()
        {
            romData = File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH));
            if (!GameBoyEmulatorCheckSum.CheckSum(romData, out string err))
            {
                Debug.LogError(err);
            }

            Debug.Log(new GameBoyEmulatorInfo(romData).ToString());
            Debug.Log(new GameBoyEmulatorInfo(File.ReadAllBytes(Path.GetFullPath(TEST_ROM_PATH2))).ToString());
        }
    }
}