namespace GameBoy.Emulators.Common
{
    public sealed class Rom
    {
        #region Rom Header Map

        public const ushort MAP_ENTRY_POINT         = 0x100;
        public const ushort MAP_ENTRY_POINT_END     = 0x103;
        public const ushort MAP_LOGO_TOP_START      = 0x104;
        public const ushort MAP_LOGO_TOP_END        = 0x11b;
        public const ushort MAP_LOGO_BOTTOM_START   = 0x11c;
        public const ushort MAP_LOGO_BOTTOM_END     = 0x133;
        public const ushort MAP_TITLE_START         = 0x134;
        public const ushort MAP_TITLE_END           = 0x143;
        public const ushort MAP_MANUFACTURER_START  = 0x13F;
        public const ushort MAP_MANUFACTURER_END    = 0X142;
        public const ushort MAP_CGB_FLAG            = 0X143;
        public const ushort MAP_NEW_LICENSEE        = 0X144;
        public const ushort MAP_NEW_LICENSEE_END    = 0X145;
        public const ushort MAP_SGB_FLAG            = 0X146;
        public const ushort MAP_CARTRIDGE_TYPE      = 0X147;
        public const ushort MAP_ROM_SIZE            = 0X148;
        public const ushort MAP_RAM_SIZE            = 0X149;
        public const ushort MAP_DESTINATION         = 0X14A;
        public const ushort MAP_OLD_LICENSEE        = 0X14B;
        public const ushort MAP_MASK_ROM_VERSION    = 0X14C;
        public const ushort MAP_HEADER_CHECKSUM     = 0X14D;
        public const ushort MAP_GLOBAL_CHECKSUM     = 0X14E;
        public const ushort MAP_GLOBAL_CHECKSUM_END = 0X14F;

        #endregion
    }
}