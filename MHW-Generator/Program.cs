﻿using System;
using System.Collections.Generic;
using System.IO;
using MHW_Template;
using MHW_Template.Armors;
using MHW_Template.Items;
using MHW_Template.Weapons;
using MHW_Template.Weapons.Model;

namespace MHW_Generator {
    public static class Program {
        private const string ROOT_OUTPUT = @"..\..\..\Generated";

        [STAThread]
        public static void Main() {
            GenItem();
            GenBottleTable();
            GenArmUp();
            GenGem();
            GenSkillDat();
            GenArmor();
            GenMelee();
            GenRanged();
            GenSharpness();
            GenShellTable();
            GenNewLimitBreak();
        }

        private static void GenNewLimitBreak() {
            GenerateItemProps("MHW_Editor.Weapons", "NewLimitBreak", new MhwStructData {
                size = 38,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Id 1", 0, typeof(ushort)),
                    new MhwStructData.Entry("Id 2", 2, typeof(ushort)),
                    new MhwStructData.Entry("Needed Item Id to Unlock", 4, typeof(ushort)),
                    new MhwStructData.Entry("Activated 1", 6, typeof(sbyte), accessLevel: "protected"),
                    new MhwStructData.Entry("Activated 2", 7, typeof(sbyte), accessLevel: "protected"),
                    new MhwStructData.Entry("Activated 3", 8, typeof(sbyte), accessLevel: "protected"),
                    new MhwStructData.Entry("Activated 4", 9, typeof(sbyte), accessLevel: "protected"),
                    new MhwStructData.Entry("Mat 1", 14, typeof(ushort)),
                    new MhwStructData.Entry("Mat 1 Quantity", 16, typeof(byte)),
                    new MhwStructData.Entry("Mat 2", 17, typeof(ushort)),
                    new MhwStructData.Entry("Mat 2 Quantity", 19, typeof(byte)),
                    new MhwStructData.Entry("Mat 3", 20, typeof(ushort)),
                    new MhwStructData.Entry("Mat 3 Quantity", 22, typeof(byte)),
                    new MhwStructData.Entry("Mat 4", 23, typeof(ushort)),
                    new MhwStructData.Entry("Mat 4 Quantity", 24, typeof(byte)),
                    new MhwStructData.Entry("Id 3", 37, typeof(byte)),
                }
            });
        }

        private static void GenShellTable() {
            var types = new List<ShellTableTypes>() {
                new ShellTableTypes("Normal", 3),
                new ShellTableTypes("Pierce", 3),
                new ShellTableTypes("Spread", 3),
                new ShellTableTypes("Cluster", 3),
                new ShellTableTypes("Wyvern", 1),
                new ShellTableTypes("Sticky", 3),
                new ShellTableTypes("Slicing", 1),
                new ShellTableTypes("Flaming", 1),
                new ShellTableTypes("Water", 1),
                new ShellTableTypes("Freeze", 1),
                new ShellTableTypes("Thunder", 1),
                new ShellTableTypes("Dragon", 1),
                new ShellTableTypes("Poison", 2),
                new ShellTableTypes("Paralysis", 2),
                new ShellTableTypes("Sleep", 2),
                new ShellTableTypes("Exhaust", 2),
                new ShellTableTypes("Recover", 2),
                new ShellTableTypes("Demon", 1),
                new ShellTableTypes("Armor", 1),
                new ShellTableTypes("Unknown", 2),
                new ShellTableTypes("Tranq", 1)
            };

            var entries = new List<MhwStructData.Entry>();

            ulong x = 0;
            foreach (var type in types) {
                for (var i = 0; i < type.num; i++) {
                    if (type.name == "Unknown") {
                        x += 3;
                        continue;
                    }

                    var name = type.name;
                    if (type.num > 1) {
                        name += $" {i + 1}";
                    }

                    entries.Add(new MhwStructData.Entry($"{name} Mag Cnt", x++, typeof(byte), valueString: "value.Clamp((byte) 0, (byte) 10)"));
                    entries.Add(new MhwStructData.Entry($"{name} Rec Amnt", x++, typeof(byte)));
                    entries.Add(new MhwStructData.Entry($"{name} Rel Spd", x++, typeof(byte)));
                }
            }

            GenerateItemProps("MHW_Editor.Weapons", "ShellTable", new MhwStructData {
                size = 111,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = entries
            });
        }

        private static void GenSharpness() {
            GenerateItemProps("MHW_Editor.Weapons", "Sharpness", new MhwStructData {
                size = 18,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Id", 0, typeof(uint), true),
                    new MhwStructData.Entry("Red", 4, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                    new MhwStructData.Entry("Orange", 6, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                    new MhwStructData.Entry("Yellow", 8, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                    new MhwStructData.Entry("Green", 10, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                    new MhwStructData.Entry("Blue", 12, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                    new MhwStructData.Entry("White", 14, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                    new MhwStructData.Entry("Purple", 16, typeof(ushort), valueString: "value.Clamp((ushort) 0, (ushort) 400)"),
                }
            });
        }

        private static void GenRanged() {
            GenerateItemProps("MHW_Editor.Weapons", "Ranged", new MhwStructData {
                size = 69,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Index", 0, typeof(uint), true, accessLevel: "private"),
                    new MhwStructData.Entry("Id", 59, typeof(ushort), true),
                    new MhwStructData.Entry("Base Model Id", 6, typeof(short)),
                    new MhwStructData.Entry("Part 1 Id", 8, typeof(short)),
                    new MhwStructData.Entry("Part 2 Id", 10, typeof(short)),
                    new MhwStructData.Entry("Is Fixed Upgrade Raw", 14, typeof(byte), accessLevel: "protected"),
                    new MhwStructData.Entry("Muzzle Type", 16, typeof(byte), typeof(MuzzleType)),
                    new MhwStructData.Entry("Barrel Type", 17, typeof(byte), typeof(BarrelType)),
                    new MhwStructData.Entry("Magazine Type", 18, typeof(byte), typeof(MagazineType)),
                    new MhwStructData.Entry("Scope Type", 19, typeof(byte), typeof(ScopeType)),
                    new MhwStructData.Entry("Cost", 20, typeof(uint)),
                    new MhwStructData.Entry("Rarity", 24, typeof(byte)),
                    new MhwStructData.Entry("Damage", 25, typeof(ushort)),
                    new MhwStructData.Entry("Defense", 27, typeof(ushort)),
                    new MhwStructData.Entry("Affinity", 29, typeof(sbyte), valueString: "value.Clamp((sbyte) -100, (sbyte) 100)"),
                    new MhwStructData.Entry("Element", 30, typeof(byte), typeof(Element)),
                    new MhwStructData.Entry("Element Damage", 31, typeof(ushort)),
                    new MhwStructData.Entry("Hidden Element", 33, typeof(byte), typeof(Element)),
                    new MhwStructData.Entry("Hidden Element Damage", 34, typeof(ushort)),
                    new MhwStructData.Entry("Elderseal", 36, typeof(byte), typeof(Elderseal)),
                    new MhwStructData.Entry("Shell Type Id", 37, typeof(byte)),
                    new MhwStructData.Entry("Deviation", 39, typeof(byte), typeof(Deviation)),
                    new MhwStructData.Entry("Slot Count", 40, typeof(byte)),
                    new MhwStructData.Entry("Slot 1 Size", 41, typeof(byte)),
                    new MhwStructData.Entry("Slot 2 Size", 42, typeof(byte)),
                    new MhwStructData.Entry("Slot 3 Size", 43, typeof(byte)),
                    new MhwStructData.Entry("Special Ammo Type", 57, typeof(byte)),
                    new MhwStructData.Entry("Skill", 65, typeof(ushort)),
                    new MhwStructData.Entry("GMD Name Index", 61, typeof(ushort), accessLevel: "protected")
                }
            });
        }

        private static void GenMelee() {
            GenerateItemProps("MHW_Editor.Weapons", "Melee", new MhwStructData {
                size = 66,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Index", 0, typeof(uint), true, accessLevel: "private"),
                    new MhwStructData.Entry("Id", 56, typeof(ushort), true),
                    new MhwStructData.Entry("Base Model Id", 6, typeof(short)),
                    new MhwStructData.Entry("Part 1 Id", 8, typeof(short)),
                    new MhwStructData.Entry("Part 2 Id", 10, typeof(short)),
                    new MhwStructData.Entry("Is Fixed Upgrade Raw", 14, typeof(byte), accessLevel: "protected"),
                    new MhwStructData.Entry("Cost", 16, typeof(uint)),
                    new MhwStructData.Entry("Rarity", 20, typeof(byte)),
                    new MhwStructData.Entry("Sharpness Quality", 21, typeof(byte)),
                    new MhwStructData.Entry("Sharpness Amount", 22, typeof(byte)),
                    new MhwStructData.Entry("Damage", 23, typeof(ushort)),
                    new MhwStructData.Entry("Defense", 25, typeof(ushort)),
                    new MhwStructData.Entry("Affinity", 27, typeof(sbyte), valueString: "value.Clamp((sbyte) -100, (sbyte) 100)"),
                    new MhwStructData.Entry("Element", 28, typeof(byte), typeof(Element)),
                    new MhwStructData.Entry("Element Damage", 29, typeof(ushort)),
                    new MhwStructData.Entry("Hidden Element", 31, typeof(byte), typeof(Element)),
                    new MhwStructData.Entry("Hidden Element Damage", 32, typeof(ushort)),
                    new MhwStructData.Entry("Elderseal", 34, typeof(byte), typeof(Elderseal)),
                    new MhwStructData.Entry("Slot Count", 35, typeof(byte)),
                    new MhwStructData.Entry("Slot 1 Size", 36, typeof(byte)),
                    new MhwStructData.Entry("Slot 2 Size", 37, typeof(byte)),
                    new MhwStructData.Entry("Slot 3 Size", 38, typeof(byte)),
                    new MhwStructData.Entry("Skill", 62, typeof(ushort)),
                    new MhwStructData.Entry("GMD Name Index", 58, typeof(ushort), accessLevel: "protected")
                }
            });
        }

        private static void GenArmor() {
            GenerateItemProps("MHW_Editor.Armors", "Armor", new MhwStructData {
                size = 60,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Id", 0, typeof(uint), true),
                    new MhwStructData.Entry("Order", 4, typeof(ushort)),
                    new MhwStructData.Entry("Variant", 6, typeof(byte), typeof(Variant)),
                    new MhwStructData.Entry("Set Id", 7, typeof(ushort)),
                    new MhwStructData.Entry("Type", 9, typeof(byte), typeof(ArmorType)),
                    new MhwStructData.Entry("Equip Slot", 10, typeof(byte), typeof(EquipSlot)),
                    new MhwStructData.Entry("Defense", 11, typeof(ushort)),
                    new MhwStructData.Entry("Rarity", 20, typeof(byte)),
                    new MhwStructData.Entry("Cost", 21, typeof(uint)),
                    new MhwStructData.Entry("Fire Res", 25, typeof(sbyte)),
                    new MhwStructData.Entry("Water Res", 26, typeof(sbyte)),
                    new MhwStructData.Entry("Ice Res", 27, typeof(sbyte)),
                    new MhwStructData.Entry("Thunder Res", 28, typeof(sbyte)),
                    new MhwStructData.Entry("Dragon Res", 29, typeof(sbyte)),
                    new MhwStructData.Entry("Slot Count", 30, typeof(byte)),
                    new MhwStructData.Entry("Slot 1 Size", 31, typeof(byte)),
                    new MhwStructData.Entry("Slot 2 Size", 32, typeof(byte)),
                    new MhwStructData.Entry("Slot 3 Size", 33, typeof(byte)),
                    new MhwStructData.Entry("Set Skill 1", 34, typeof(ushort)),
                    new MhwStructData.Entry("Set Skill 1 Level", 36, typeof(byte)),
                    new MhwStructData.Entry("Set Skill 2", 37, typeof(ushort)),
                    new MhwStructData.Entry("Set Skill 2 Level", 39, typeof(byte)),
                    new MhwStructData.Entry("Skill 1", 40, typeof(ushort)),
                    new MhwStructData.Entry("Skill 1 Level", 42, typeof(byte)),
                    new MhwStructData.Entry("Skill 2", 43, typeof(ushort)),
                    new MhwStructData.Entry("Skill 2 Level", 45, typeof(byte)),
                    new MhwStructData.Entry("Skill 3", 46, typeof(ushort)),
                    new MhwStructData.Entry("Skill 3 Level", 48, typeof(byte)),
                    new MhwStructData.Entry("Gender", 49, typeof(byte), typeof(Gender)),
                    new MhwStructData.Entry("Set Group", 53, typeof(ushort)),
                    new MhwStructData.Entry("Is Permanent Raw", 59, typeof(byte), accessLevel: "protected"),
                    new MhwStructData.Entry("GMD Name Index", 55, typeof(ushort), accessLevel: "protected")
                }
            });
        }

        private static void GenSkillDat() {
            GenerateItemProps("MHW_Editor.Gems", "SkillDat", new MhwStructData {
                size = 19,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Id", 0, typeof(ushort), true),
                    new MhwStructData.Entry("Level", 2, typeof(byte), true),
                    new MhwStructData.Entry("Param 1", 3, typeof(ushort)),
                    new MhwStructData.Entry("Param 2", 5, typeof(ushort)),
                    new MhwStructData.Entry("Param 3", 7, typeof(ushort)),
                    new MhwStructData.Entry("Param 4", 9, typeof(ushort)),
                    new MhwStructData.Entry("Param 5", 11, typeof(ushort)),
                    new MhwStructData.Entry("Param 6", 13, typeof(ushort)),
                    new MhwStructData.Entry("Param 7", 15, typeof(ushort)),
                    new MhwStructData.Entry("Param 8", 17, typeof(ushort))
                }
            });
        }

        private static void GenGem() {
            GenerateItemProps("MHW_Editor.Gems", "Gem", new MhwStructData {
                size = 28,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Index", 4, typeof(ushort), true, accessLevel: "private"),
                    new MhwStructData.Entry("Id", 0, typeof(ushort), true),
                    new MhwStructData.Entry("Size", 8, typeof(byte)),
                    new MhwStructData.Entry("Skill 1", 12, typeof(ushort)),
                    new MhwStructData.Entry("Skill 1 Level", 16, typeof(byte)),
                    new MhwStructData.Entry("Skill 2", 20, typeof(ushort)),
                    new MhwStructData.Entry("Skill 2 Level", 24, typeof(byte))
                }
            });
        }

        private static void GenArmUp() {
            GenerateItemProps("MHW_Editor.Items", "ArmUp", new MhwStructData {
                size = 22,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Unk1", 0, typeof(short)),
                    new MhwStructData.Entry("Unk2", 2, typeof(short)),
                    new MhwStructData.Entry("Unk3", 4, typeof(short)),
                    new MhwStructData.Entry("Unk4", 6, typeof(short)),
                    new MhwStructData.Entry("Unk5", 8, typeof(short)),
                    new MhwStructData.Entry("Unk6", 10, typeof(short)),
                    new MhwStructData.Entry("Unk7", 12, typeof(short)),
                    new MhwStructData.Entry("Unk8", 14, typeof(short)),
                    new MhwStructData.Entry("Unk9", 16, typeof(short)),
                    new MhwStructData.Entry("Unk10", 18, typeof(short)),
                    new MhwStructData.Entry("Unk11", 20, typeof(short)),
                }
            });
        }

        private static void GenBottleTable() {
            GenerateItemProps("MHW_Editor.Items", "BottleTable", new MhwStructData {
                size = 6,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Close Range", 0, typeof(byte), typeof(CoatingType)),
                    new MhwStructData.Entry("Power", 1, typeof(byte), typeof(CoatingType)),
                    new MhwStructData.Entry("Paralysis", 2, typeof(byte), typeof(CoatingType)),
                    new MhwStructData.Entry("Poison", 3, typeof(byte), typeof(CoatingType)),
                    new MhwStructData.Entry("Sleep", 4, typeof(byte), typeof(CoatingType)),
                    new MhwStructData.Entry("Blast", 5, typeof(byte), typeof(CoatingType))
                }
            });
        }

        private static void GenItem() {
            GenerateItemProps("MHW_Editor.Items", "Item", new MhwStructData {
                size = 32,
                offsetInitial = 10,
                entryCountOffset = 6,
                entries = new List<MhwStructData.Entry> {
                    new MhwStructData.Entry("Id", 0, typeof(uint), true),
                    new MhwStructData.Entry("Sub Type", 4, typeof(byte), typeof(ItemSubType)),
                    new MhwStructData.Entry("Type", 5, typeof(uint), typeof(ItemType)),
                    new MhwStructData.Entry("Rarity", 9, typeof(byte)),
                    new MhwStructData.Entry("Carry Limit", 10, typeof(byte)),
                    new MhwStructData.Entry("Unknown Limit", 11, typeof(byte)),
                    new MhwStructData.Entry("Sort Order", 12, typeof(ushort)),
                    new MhwStructData.Entry("Flags", 14, typeof(uint)),
                    new MhwStructData.Entry("Icon Id", 18, typeof(uint)),
                    new MhwStructData.Entry("Icon Color Id", 22, typeof(ushort)),
                    new MhwStructData.Entry("Sell Price", 24, typeof(uint)),
                    new MhwStructData.Entry("Buy Price", 28, typeof(uint))
                }
            });
        }

        public static void GenerateItemProps(string @namespace, string className, MhwStructData structData) {
            var itemTemplate = new ItemTemplate {
                Session = new Dictionary<string, object> {
                    {"_namespace", @namespace},
                    {"className", className},
                    {"structData", structData}
                }
            };
            itemTemplate.Initialize();
            var dir = $"{ROOT_OUTPUT}\\{@namespace.Replace(".", "\\")}";
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText($"{dir}\\{className}.cs", itemTemplate.TransformText());
        }
    }
}