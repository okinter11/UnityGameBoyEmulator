namespace Emulator
{
    // https://gbdev.io/pandocs/The_Cartridge_Header.html
    public enum CartridgeHeader : ushort
    {
        // 0x100 - 0x103 Entry Point
        EntryPoint    = 0x100,
        EntryPointEnd = 0x103,
        // 0x104 - 0x133 Nintendo Logo
        LogoTopStart    = 0x104,
        LogoTopEnd      = 0x11b,
        LogoBottomStart = 0x11c,
        LogoBottomEnd   = 0x133,
        // 0x134 - 0x143 Title
        Title    = 0x134,
        TitleEnd = 0x143,
        // 0x13F - 0x142 Manufacturer Code
        Manufacturer    = 0x13F,
        ManufacturerEnd = 0x142,
        // 0x143 CGB Flag
        CGBFlag = 0x143,
        // 0x144 - 0x145 New Licensee Code
        NewLicensee    = 0x144,
        NewLicenseeEnd = 0x145,
        // 0x146 SGB Flag
        SGBFlag = 0x146,
        // 0x147 Cartridge Type
        CartridgeType = 0x147,
        // 0x148 ROM Size
        ROMSize = 0x148,
        // 0x149 RAM Size
        RAMSize = 0x149,
        // 0x14A Destination Code
        Destination = 0x14A,
        // 0x14B Old Licensee Code
        OldLicensee = 0x14B,
        // 0x14C Mask ROM Version number
        MaskROMVersion = 0x14C,
        // 0x14D Header Checksum
        HeaderChecksum = 0x14D,
        // 0x14E - 0x14F Global Checksum
        GlobalChecksum    = 0x14E,
        GlobalChecksumEnd = 0x14F,
    }
}