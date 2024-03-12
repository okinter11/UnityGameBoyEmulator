using System;
using GameBoy.Emulators.Common.Opcodes;

namespace GameBoy.Emulators.Common.Cpus
{
    public class Ppu
    {
        public enum Mode : byte
        {
            HBLANK  = 0, // 0b00
            VBLANK  = 1, // 0b01
            OAM     = 2, // 0b10
            DRAWING = 3, // 0b11
        }

        //! 0xFF47 - BGP (BG palette data).
        public byte bgp;
        //! 0xFF46 - DMA value.
        public byte dma;

        //! 0xFF40 - LCD control.
        public byte lcdc;
        //! 0xFF41 - LCD status.
        public byte lcds;
        public uint lineCycles;
        //! 0xFF44 - LY LCD Y coordinate [Read Only].
        public byte ly;
        //! 0xFF45 - LYC LCD Y Compare.
        public byte lyc;
        //! 0xFF48 - OBP0 (OBJ0 palette data).
        public byte obp0;
        //! 0xFF49 - OBP1 (OBJ1 palette data).
        public byte obp1;
        //! 0xFF43 - SCX.
        public byte scroll_x;
        //! 0xFF42 - SCY.
        public byte scroll_y;
        //! 0xFF4B - WX (Window X position plus 7).
        public byte wx;
        //! 0xFF4A - WY (Window Y position plus 7).
        public byte wy;

        public Ppu()
        {
            lcdc = 0x91;
            lcds = 0x00;
            scroll_y = 0x00;
            scroll_x = 0x00;
            ly = 0x00;
            lyc = 0x00;
            dma = 0x00;
            bgp = 0xFC;
            obp0 = 0xFF;
            obp1 = 0xFF;
            wy = 0x00;
            wx = 0x00;
            CurrentMode = Mode.OAM;
            lineCycles = 0;
        }

        #region Method

        public static void PpuTick(Cpu cpu)
        {
            if (!cpu.Ppu.Enabled)
            {
                return;
            }

            cpu.Ppu.lineCycles += 1;
            switch (cpu.Ppu.CurrentMode)
            {
                case Mode.OAM:
                    TickOam(cpu);
                    return;
                case Mode.DRAWING:
                    TickDraw(cpu);
                    return;
                case Mode.HBLANK:
                    TickHblank(cpu);
                    return;
                case Mode.VBLANK:
                    TickVblank(cpu);
                    return;
                default:
                    throw new Exception("Invalid mode");
            }
        }

        public static void TickOam(Cpu cpu)
        {
            // TODO
            if (cpu.Ppu.lineCycles >= 80)
            {
                cpu.Ppu.CurrentMode = Mode.DRAWING;
            }
        }

        public static void TickDraw(Cpu cpu)
        {
            // TODO
            if (cpu.Ppu.lineCycles >= 369)
            {
                cpu.Ppu.CurrentMode = Mode.HBLANK;
                if (cpu.Ppu.HBlankIntEnabled)
                {
                    cpu._intFlags |= CpuOp.INT_LCD_STAT;
                }
            }
        }

        public static void TickHblank(Cpu cpu)
        {
            // TODO
            if (cpu.Ppu.lineCycles >= CYCLES_PER_LINE)
            {
                cpu.Ppu.ly += 1;
                if (cpu.Ppu.ly == cpu.Ppu.lyc)
                {
                    cpu.Ppu.SetLycFlag();
                    if (cpu.Ppu.LycIntEnabled)
                    {
                        cpu._intFlags |= CpuOp.INT_LCD_STAT;
                    }
                }
                else
                {
                    cpu.Ppu.ResetLycFlag();
                }

                if (cpu.Ppu.ly >= SCREEN_HEIGHT)
                {
                    cpu.Ppu.CurrentMode = Mode.VBLANK;
                    cpu._intFlags |= CpuOp.INT_VBLANK;
                    if (cpu.Ppu.VBlankIntEnabled)
                    {
                        cpu._intFlags |= CpuOp.INT_LCD_STAT;
                    }
                }
                else
                {
                    cpu.Ppu.CurrentMode = Mode.OAM;
                    if (cpu.Ppu.OamIntEnabled)
                    {
                        cpu._intFlags |= CpuOp.INT_LCD_STAT;
                    }
                }

                cpu.Ppu.lineCycles = 0;
            }
        }

        public static void TickVblank(Cpu cpu)
        {
            if (cpu.Ppu.lineCycles >= CYCLES_PER_LINE)
            {
                cpu.Ppu.ly += 1;
                if (cpu.Ppu.ly == cpu.Ppu.lyc)
                {
                    cpu.Ppu.SetLycFlag();
                    if (cpu.Ppu.LycIntEnabled)
                    {
                        cpu._intFlags |= CpuOp.INT_LCD_STAT;
                    }
                }
                else
                {
                    cpu.Ppu.ResetLycFlag();
                }

                if (cpu.Ppu.ly >= LINES_PER_FRAME)
                {
                    cpu.Ppu.CurrentMode = Mode.OAM;
                    cpu.Ppu.ly = 0;
                    if (cpu.Ppu.OamIntEnabled)
                    {
                        cpu._intFlags |= CpuOp.INT_LCD_STAT;
                    }
                }

                cpu.Ppu.lineCycles = 0;
            }
        }

        public bool Enabled => (lcdc & (1 << 7)) != 0;
        public Mode CurrentMode
        {
            get => (Mode)(lcds & 0x03);
            set
            {
                lcds &= 0xFC;
                lcds |= (byte)value;
            }
        }

        public void SetLycFlag()     => lcds |= 1 << 2;
        public void ResetLycFlag()   => lcds = (byte)(lcds & ~(1 << 2));
        public bool HBlankIntEnabled => (lcds & (1 << 3)) != 0;
        public bool VBlankIntEnabled => (lcds & (1 << 4)) != 0;
        public bool OamIntEnabled    => (lcds & (1 << 5)) != 0;
        public bool LycIntEnabled    => (lcds & (1 << 6)) != 0;

        #endregion

        #region Graphics

        public const ushort LINES_PER_FRAME = 154;
        public const ushort CYCLES_PER_LINE = 456;
        public const ushort SCREEN_WIDTH    = 160;
        public const ushort SCREEN_HEIGHT   = 144;

        #endregion
    }
}