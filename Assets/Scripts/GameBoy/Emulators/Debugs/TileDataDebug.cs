using System;
using GameBoy.Emulators.Common.Opcodes;
using UnityEngine;

namespace GameBoy.Emulators.Debugs
{
    public class TileDataDebug : MonoBehaviour
    {
        public SpriteRenderer _SpriteRenderer;
        public Sprite         _Sprite;
        public Texture2D      _Texture;

        public Emulator _Emulator;

        private void Start()
        {
            _SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (_SpriteRenderer)
            {
                _Emulator = GetComponentInChildren<Emulator>();
                _Texture = new Texture2D(16 * 8, 24 * 8);
                Color[] pixels = _Texture.GetPixels();
                Array.Fill(pixels, Color.black);
                _Texture.SetPixels(pixels);
                _Texture.name = "图块数据";
                _Texture.Apply();
                _Sprite = Sprite.Create(_Texture, new Rect(0, 0, 16 * 8, 24 * 8), new Vector2(0.5f, 0.5f));
                _Sprite.name = "图块数据精灵";
                _SpriteRenderer.sprite = _Sprite;
            }
        }

        private void Update()
        {
            if (_Emulator && _Texture)
            {
                // Update Texture Data
                int numPixelBytes = _Texture.width * _Texture.height * 4;
                int rowPitch = _Texture.width * 4;
                for (int y = 0; y < _Texture.height / 8; ++y)
                {
                    for (int x = 0; x < _Texture.width / 8; ++x)
                    {
                        int tileIndex = y * _Texture.width / 8 + x;
                        int tileColorBegin = y * rowPitch * 8 + x * 8 * 4;
                        for (int line = 0; line < 8; line++)
                        {
                            byte l = Op.Read(_Emulator.cpu, (ushort)(0x8000 + tileIndex * 16 + line * 2));
                            byte h = Op.Read(_Emulator.cpu, (ushort)(0x8000 + tileIndex * 16 + line * 2 + 1));
                            Color32[] colors = DecodeTileLine(l, h);
                            for (int i = 0; i < 8; i++)
                            {
                                _Texture.SetPixel(x * 8 + i, y * 8 + line, colors[i]);
                            }
                        }
                    }
                }

                _Texture.Apply();
            }
        }

        private static Color32[] DecodeTileLine(byte l, byte h)
        {
            Color32[] result = new Color32[8];
            for (int b = 7; b >= 0; b--)
            {
                byte lo = (l & (1 << b)) == 0 ? (byte)0 : (byte)1;
                byte hi = (h & (1 << b)) == 0 ? (byte)0 : (byte)2;
                byte color = (byte)(lo | hi);
                switch (color)
                {
                    case 0:
                        result[7 - b] = new Color32(255, 255, 255, 255);
                        break;
                    case 1:
                        result[7 - b] = new Color32(192, 192, 192, 255);
                        break;
                    case 2:
                        result[7 - b] = new Color32(96, 96, 96, 255);
                        break;
                    case 3:
                        result[7 - b] = new Color32(0, 0, 0, 255);
                        break;
                }
            }

            return result;
        }
    }
}