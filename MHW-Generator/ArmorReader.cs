﻿using System.Collections.Generic;
using System.IO;
using MHW_Editor.Armors;

namespace MHW_Generator {
    public static class ArmorReader {
        public static List<Armor> GetArmor() {
            // ReSharper disable once StringLiteralTypo
            const string targetFile = @"V:\MHW\IB\chunk_combined\common\equip\armor.am_dat";
            var armors = new List<Armor>();

            using (var dat = new BinaryReader(new FileStream(targetFile, FileMode.Open, FileAccess.Read))) {
                dat.BaseStream.Seek(6, SeekOrigin.Begin);
                var count = dat.ReadUInt32();

                dat.BaseStream.Seek(10, SeekOrigin.Begin);

                for (var i = 0; i < count; i++) {
                    var position = dat.BaseStream.Position;
                    var buff = dat.ReadBytes((int) Armor.StructSize);

                    armors.Add(new Armor(buff, (ulong) position));
                }
            }

            return armors;
        }
    }
}