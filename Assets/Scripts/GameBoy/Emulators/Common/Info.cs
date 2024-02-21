using System.Text;

namespace GameBoy.Emulators.Common
{
    public class Info
    {
        public string CartridgeType;
        public string CGBFlag = string.Empty;
        public string DestinationCode;
        public string Licensee;
        public string Manufacturer;
        public string RamSize;
        public string RomSize;
        public string RomVersion;
        public string SGBFlag = string.Empty;
        public string Title;

        public Info(in byte[] romData)
        {
            Title = GetTitle(romData);
            Manufacturer = GetManufacturer(romData);
            CartridgeType = GetCartridgeType(romData);
            RomSize = GetRomSize(romData);
            RamSize = GetRamSizeType(romData);
            DestinationCode = GetDestinationCode(romData);
            Licensee = GetLicensee(romData);
            RomVersion = GetRomVersion(romData);
        }

        public override string ToString() =>
            $"Title: {Title}\n" +
            $"Manufacturer: {Manufacturer}\n" +
            // $"CGBFlag: {CGBFlag}\n" +
            // $"SGBFlag: {SGBFlag}\n" +
            $"CartridgeType: {CartridgeType}\n" +
            $"RomSize: {RomSize}\n" +
            $"RamSize: {RamSize}\n" +
            $"Licensee: {Licensee}\n" +
            $"RomVersion: {RomVersion}\n";

        private static string GetTitle(in byte[] romData)
        {
            StringBuilder title = new();
            for (int i = (int)CartridgeHeader.Title; i <= (int)CartridgeHeader.TitleEnd; i++)
            {
                char character = (char)romData[i];
                if (character == 0)
                {
                    break;
                }

                title.Append(character);
            }

            return title.ToString();
        }

        private static string GetManufacturer(in byte[] romData)
        {
            StringBuilder manufacturer = new();
            for (int i = (int)CartridgeHeader.Manufacturer; i <= (int)CartridgeHeader.ManufacturerEnd; i++)
            {
                char character = (char)romData[i];
                if (character == 0)
                {
                    break;
                }

                manufacturer.Append(character);
            }

            return manufacturer.ToString();
        }

        private static string GetCartridgeType(in byte[] romData)
        {
            byte cartridgeType = romData[(int)CartridgeHeader.CartridgeType];
            switch (cartridgeType)
            {
                case 0x00: return "ROM ONLY";
                case 0x01: return "MBC1";
                case 0x02: return "MBC1+RAM";
                case 0x03: return "MBC1+RAM+BATTERY";
                case 0x05: return "MBC2";
                case 0x06: return "MBC2+BATTERY";
                case 0x08: return "ROM+RAM 1";
                case 0x09: return "ROM+RAM+BATTERY 1";
                case 0x0B: return "MMM01";
                case 0x0C: return "MMM01+RAM";
                case 0x0D: return "MMM01+RAM+BATTERY";
                case 0x0F: return "MBC3+TIMER+BATTERY";
                case 0x10: return "MBC3+TIMER+RAM+BATTERY 2";
                case 0x11: return "MBC3";
                case 0x12: return "MBC3+RAM 2";
                case 0x13: return "MBC3+RAM+BATTERY 2";
                case 0x19: return "MBC5";
                case 0x1A: return "MBC5+RAM";
                case 0x1B: return "MBC5+RAM+BATTERY";
                case 0x1C: return "MBC5+RUMBLE";
                case 0x1D: return "MBC5+RUMBLE+RAM";
                case 0x1E: return "MBC5+RUMBLE+RAM+BATTERY";
                case 0x20: return "MBC6";
                case 0x22: return "MBC7+SENSOR+RUMBLE+RAM+BATTERY";
                case 0xFC: return "POCKET CAMERA";
                case 0xFD: return "BANDAI TAMA5";
                case 0xFE: return "HuC3";
                case 0xFF: return "HuC1+RAM+BATTERY";
                default:   return "UNKNOWN";
            }
        }

        private static string GetRomSize(in byte[] romData)
        {
            byte romSize = romData[(int)CartridgeHeader.ROMSize];
            switch (romSize)
            {
                case 0x00: return "32KiB (no ROM banking)";
                case 0x01: return "64KiB (4 banks)";
                case 0x02: return "128KiB (8 banks)";
                case 0x03: return "256KiB (16 banks)";
                case 0x04: return "512KiB (32 banks)";
                case 0x05: return "1MiB (64 banks)";
                case 0x06: return "2MiB (128 banks)";
                case 0x07: return "4MiB (256 banks)";
                case 0x08: return "8MiB (512 banks)";
                case 0x52: return "1.1MiB (72 banks)";
                case 0x53: return "1.2MiB (80 banks)";
                case 0x54: return "1.5MiB (96 banks)";
                default:   return "UNKNOWN";
            }
        }

        private static string GetRamSizeType(in byte[] romData)
        {
            byte ramSize = romData[(int)CartridgeHeader.RAMSize];
            switch (ramSize)
            {
                case 0x00: return "No RAM";
                case 0x01: return "Unused";
                case 0x02: return "8 KB (1 bank)";
                case 0x03: return "32 KB (4 banks of 8KB each)";
                case 0x04: return "128 KB (16 banks of 8KB each)";
                case 0x05: return "64 KB (8 banks of 8KB each)";
                default:   return "Unknown";
            }
        }

        private static string GetDestinationCode(in byte[] romData)
        {
            byte destinationCode = romData[(int)CartridgeHeader.Destination];
            switch (destinationCode)
            {
                case 0x00: return "Japan (and possibly overseas)";
                case 0x01: return "Overseas only";
                default:   return "UNKNOWN";
            }
        }

        private static string GetLicensee(in byte[] romData)
        {
            byte licensee = romData[(int)CartridgeHeader.OldLicensee];
            switch (licensee)
            {
                case 0x00: return "None";
                case 0x01: return "Nintendo";
                case 0x08: return "Capcom";
                case 0x09: return "Hot-B";
                case 0x0A: return "Jaleco";
                case 0x0B: return "Coconuts Japan";
                case 0x0C: return "Elite Systems";
                case 0x13: return "EA (Electronic Arts)";
                case 0x18: return "Hudsonsoft";
                case 0x19: return "ITC Entertainment";
                case 0x1A: return "Yanoman";
                case 0x1D: return "Japan Clary";
                case 0x1F: return "Virgin Interactive";
                case 0x24: return "PCM Complete";
                case 0x25: return "San-X";
                case 0x28: return "Kotobuki Systems";
                case 0x29: return "Seta";
                case 0x30: return "Infogrames";
                case 0x31: return "Nintendo";
                case 0x32: return "Bandai";
                case 0x33: return GetNewLicensee(romData);
                case 0x34: return "Konami";
                case 0x35: return "HectorSoft";
                case 0x38: return "Capcom";
                case 0x39: return "Banpresto";
                case 0x3C: return ".Entertainment i";
                case 0x3E: return "Gremlin";
                case 0x41: return "Ubisoft";
                case 0x42: return "Atlus";
                case 0x44: return "Malibu";
                case 0x46: return "Angel";
                case 0x47: return "Spectrum Holoby";
                case 0x49: return "Irem";
                case 0x4A: return "Virgin Interactive";
                case 0x4D: return "Malibu";
                case 0x4F: return "U.S. Gold";
                case 0x50: return "Absolute";
                case 0x51: return "Acclaim";
                case 0x52: return "Activision";
                case 0x53: return "American Sammy";
                case 0x54: return "GameTek";
                case 0x55: return "Park Place";
                case 0x56: return "LJN";
                case 0x57: return "Matchbox";
                case 0x59: return "Milton Bradley";
                case 0x5A: return "Mindscape";
                case 0x5B: return "Romstar";
                case 0x5C: return "Naxat Soft";
                case 0x5D: return "Tradewest";
                case 0x60: return "Titus";
                case 0x61: return "Virgin Interactive";
                case 0x67: return "Ocean Interactive";
                case 0x69: return "EA (Electronic Arts)";
                case 0x6E: return "Elite Systems";
                case 0x6F: return "Electro Brain";
                case 0x70: return "Infogrames";
                case 0x71: return "Interplay";
                case 0x72: return "Broderbund";
                case 0x73: return "Sculptered Soft";
                case 0x75: return "The Sales Curve";
                case 0x78: return "t.hq";
                case 0x79: return "Accolade";
                case 0x7A: return "Triffix Entertainment";
                case 0x7C: return "Microprose";
                case 0x7F: return "Kemco";
                case 0x80: return "Misawa Entertainment";
                case 0x83: return "Lozc";
                case 0x86: return "Tokuma Shoten Intermedia";
                case 0x8B: return "Bullet-Proof Software";
                case 0x8C: return "Vic Tokai";
                case 0x8E: return "Ape";
                case 0x8F: return "I’Max";
                case 0x91: return "Chunsoft Co.";
                case 0x92: return "Video System";
                case 0x93: return "Tsubaraya Productions Co.";
                case 0x95: return "Varie Corporation";
                case 0x96: return "Yonezawa/S’Pal";
                case 0x97: return "Kaneko";
                case 0x99: return "Arc";
                case 0x9A: return "Nihon Bussan";
                case 0x9B: return "Tecmo";
                case 0x9C: return "Imagineer";
                case 0x9D: return "Banpresto";
                case 0x9F: return "Nova";
                case 0xA1: return "Hori Electric";
                case 0xA2: return "Bandai";
                case 0xA4: return "Konami";
                case 0xA6: return "Kawada";
                case 0xA7: return "Takara";
                case 0xA9: return "Technos Japan";
                case 0xAA: return "Broderbund";
                case 0xAC: return "Toei Animation";
                case 0xAD: return "Toho";
                case 0xAF: return "Namco";
                case 0xB0: return "acclaim";
                case 0xB1: return "ASCII or Nexsoft";
                case 0xB2: return "Bandai";
                case 0xB4: return "Square Enix";
                case 0xB6: return "HAL Laboratory";
                case 0xB7: return "SNK";
                case 0xB9: return "Pony Canyon";
                case 0xBA: return "Culture Brain";
                case 0xBB: return "Sunsoft";
                case 0xBD: return "Sony Imagesoft";
                case 0xBF: return "Sammy";
                case 0xC0: return "Taito";
                case 0xC2: return "Kemco";
                case 0xC3: return "Squaresoft";
                case 0xC4: return "Tokuma Shoten Intermedia";
                case 0xC5: return "Data East";
                case 0xC6: return "Tonkinhouse";
                case 0xC8: return "Koei";
                case 0xC9: return "UFL";
                case 0xCA: return "Ultra";
                case 0xCB: return "Vap";
                case 0xCC: return "Use Corporation";
                case 0xCD: return "Meldac";
                case 0xCE: return ".Pony Canyon or";
                case 0xCF: return "Angel";
                case 0xD0: return "Taito";
                case 0xD1: return "Sofel";
                case 0xD2: return "Quest";
                case 0xD3: return "Sigma Enterprises";
                case 0xD4: return "ASK Kodansha Co.";
                case 0xD6: return "Naxat Soft";
                case 0xD7: return "Copya System";
                case 0xD9: return "Banpresto";
                case 0xDA: return "Tomy";
                case 0xDB: return "LJN";
                case 0xDD: return "NCS";
                case 0xDE: return "Human";
                case 0xDF: return "Altron";
                case 0xE0: return "Jaleco";
                case 0xE1: return "Towa Chiki";
                case 0xE2: return "Yutaka";
                case 0xE3: return "Varie";
                case 0xE5: return "Epcoh";
                case 0xE7: return "Athena";
                case 0xE8: return "Asmik ACE Entertainment";
                case 0xE9: return "Natsume";
                case 0xEA: return "King Records";
                case 0xEB: return "Atlus";
                case 0xEC: return "Epic/Sony Records";
                case 0xEE: return "IGS";
                case 0xF0: return "A Wave";
                case 0xF3: return "Extreme Entertainment";
                case 0xFF: return "LJN";
                default:   return "UNKNOWN";
            }
        }

        private static string GetNewLicensee(in byte[] romData)
        {
            string newLicensee = new(new[]
            {
                (char)romData[(int)CartridgeHeader.NewLicensee],
                (char)romData[(int)CartridgeHeader.NewLicenseeEnd],
            });
            switch (newLicensee)
            {
                case "00": return "None";
                case "01": return "Nintendo R&D1";
                case "08": return "Capcom";
                case "13": return "Electronic Arts";
                case "18": return "Hudson Soft";
                case "19": return "b-ai";
                case "20": return "kss";
                case "22": return "pow";
                case "24": return "PCM Complete";
                case "25": return "san-x";
                case "28": return "Kemco Japan";
                case "29": return "seta";
                case "30": return "Viacom";
                case "31": return "Nintendo";
                case "32": return "Bandai";
                case "33": return "Ocean/Acclaim";
                case "34": return "Konami";
                case "35": return "Hector";
                case "37": return "Taito";
                case "38": return "Hudson";
                case "39": return "Banpresto";
                case "41": return "Ubi Soft";
                case "42": return "Atlus";
                case "44": return "Malibu";
                case "46": return "angel";
                case "47": return "Bullet-Proof";
                case "49": return "irem";
                case "50": return "Absolute";
                case "51": return "Acclaim";
                case "52": return "Activision";
                case "53": return "American sammy";
                case "54": return "Konami";
                case "55": return "Hi tech entertainment";
                case "56": return "LJN";
                case "57": return "Matchbox";
                case "58": return "Mattel";
                case "59": return "Milton Bradley";
                case "60": return "Titus";
                case "61": return "Virgin";
                case "64": return "LucasArts";
                case "67": return "Ocean";
                case "69": return "Electronic Arts";
                case "70": return "Infogrames";
                case "71": return "Interplay";
                case "72": return "Broderbund";
                case "73": return "sculptured";
                case "75": return "sci";
                case "78": return "THQ";
                case "79": return "Accolade";
                case "80": return "misawa";
                case "83": return "lozc";
                case "86": return "Tokuma Shoten Intermedia";
                case "87": return "Tsukuda Original";
                case "91": return "Chunsoft";
                case "92": return "Video system";
                case "93": return "Ocean/Acclaim";
                case "95": return "Varie";
                case "96": return "Yonezawa/s’pal";
                case "97": return "Kaneko";
                case "99": return "Pack in soft";
                case "9H": return "Bottom Up";
                case "A4": return "Konami (Yu-Gi-Oh!)";
                default:   return "UNKNOWN";
            }
        }

        private static string GetRomVersion(in byte[] romData)
        {
            byte romVersion = romData[(int)CartridgeHeader.MaskROMVersion];
            return romVersion.ToString();
        }
    }
}