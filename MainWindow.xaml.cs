﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using JetBrains.Annotations;
using MHW_Editor.Armors;
using MHW_Editor.Assets;
using MHW_Editor.Gems;
using MHW_Editor.Items;
using MHW_Editor.Models;
using MHW_Editor.Skills;
using MHW_Editor.Weapons;
using MHW_Template;
using MHW_Template.Weapons;
using Microsoft.Win32;

namespace MHW_Editor {
    public partial class MainWindow {
#if DEBUG
        private const bool ENABLE_CHEAT_BUTTONS = true;
        private const bool SHOW_RAW_BYTES = true;
#else
        private const bool ENABLE_CHEAT_BUTTONS = false;
        private const bool SHOW_RAW_BYTES = false;
#endif
        private static readonly string[] FILE_TYPES = {
            "*.wp_dat",
            "*.wp_dat_g",
            "*.am_dat",
            "*.sgpa",
            "*.itm",
            "*.bbtbl",
            "*.arm_up",
            "*.kire",
            "*.skl_dat",
            "*.shl_tbl",
            "*.new_lbr",
            "*.wep_wsd",
            "*.wep_wsl",
            "*.wep_glan",
            "*.wep_saxe",
            "*.skl_pt_dat",
            "*.ask"
        };

        private readonly ObservableCollection<dynamic> items = new ObservableCollection<dynamic>();
        private string targetFile;
        private Type targetFileType;

        public static string locale = "eng";
        public string Locale {
            get => locale;
            set {
                locale = value;
                foreach (MhwItem item in items) {
                    item.OnPropertyChanged(nameof(IMhwItem.Name));
                    item.OnPropertyChanged(nameof(SkillDat.Name_And_Id));
                    item.OnPropertyChanged(nameof(SkillDat.Description));
                }
            }
        }

        [CanBeNull]
        private CancellationTokenSource savedTimer;

        public MainWindow() {
            InitializeComponent();

            cbx_localization.ItemsSource = Global.LANGUAGE_NAME_LOOKUP;

            dg_items.AutoGeneratingColumn += Dg_items_AutoGeneratingColumn;
            dg_items.AutoGeneratedColumns += Dg_items_AutoGeneratedColumns;
            dg_items.GotFocus += Dg_items_GotFocus;
            dg_items.Sorting += Dg_items_Sorting;

            btn_open.Click += Btn_open_Click;
            btn_save.Click += Btn_save_Click;
            btn_slot_cheat.Click += Btn_slot_cheat_Click;
            btn_set_bonus_cheat.Click += Btn_set_bonus_cheat_Click;
            btn_skill_level_cheat.Click += Btn_skill_level_cheat_Click;
            btn_zenny_cheat.Click += Btn_zenny_cheat_Click;
            btn_damage_cheat.Click += Btn_damage_cheat_Click;
            btn_enable_all_coatings_cheat.Click += Btn_enable_all_coatings_cheat_Click;
            btn_max_sharpness_cheat.Click += Btn_max_sharpness_cheat_Click;
            btn_sort_jewel_order_by_name.Click += Btn_sort_jewel_order_by_name_Click;

            Width = SystemParameters.MaximizedPrimaryScreenWidth * 0.8;
            Height = SystemParameters.MaximizedPrimaryScreenHeight * 0.5;
        }

        private void Dg_items_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            Debug.Assert(e.PropertyName != null, "e.PropertyName != null");

            switch (e.PropertyName) {
                case nameof(IMhwItem.Bytes):
                case nameof(IMhwItem.Changed):
                    e.Cancel = true;
                    break;
                case nameof(MhwItem.Raw_Data):
                    e.Cancel = !SHOW_RAW_BYTES;
                    break;
                case nameof(Ranged.Muzzle_Type):
                case nameof(Ranged.Barrel_Type):
                case nameof(Ranged.Magazine_Type):
                case nameof(Ranged.Scope_Type):
                case nameof(Ranged.Shell_Type_Id):
                case nameof(Ranged.Deviation):
                    e.Cancel = targetFileType.Is(typeof(Bow));
                    break;
                case nameof(IMhwItem.Name):
                    e.Cancel = targetFileType.Is(typeof(BottleTable),
                                                 typeof(ArmUp),
                                                 typeof(Sharpness),
                                                 typeof(ShellTable),
                                                 typeof(SkillDat),
                                                 typeof(NewLimitBreak),
                                                 typeof(WeaponWSword),
                                                 typeof(WeaponWhistle),
                                                 typeof(WeaponGunLance),
                                                 typeof(SkillPointData),
                                                 typeof(ASkill));
                    break;
                case nameof(SkillDat.Id):
                    e.Cancel = targetFileType.Is(typeof(SkillDat));
                    break;
                default:
                    e.Cancel = e.PropertyName.EndsWith("Raw") || e.PropertyName.EndsWith("___");
                    break;
            }

            if (e.Cancel) return;

            switch (e.PropertyName) {
                case nameof(Armor.Set_Skill_1):
                case nameof(Armor.Set_Skill_2):
                case nameof(Armor.Skill_1):
                case nameof(Armor.Skill_2):
                case nameof(Armor.Skill_3):
                case nameof(Melee.Skill): {
                    var cb = new DataGridComboBoxColumn {
                        Header = e.Column.Header,
                        ItemsSource = DataHelper.skillData[locale],
                        SelectedValueBinding = new Binding(e.PropertyName),
                        SelectedValuePath = "Key",
                        DisplayMemberPath = "Value",
                        CanUserSort = true
                    };
                    e.Column = cb;
                    break;
                }
                case nameof(SkillDat.Name_And_Id):
                    e.Column.Header = "Name/ID";
                    e.Column.CanUserSort = true;
                    break;
            }

            // TODO: Fix enum value display at some point.
        }

        private void Dg_items_AutoGeneratedColumns(object sender, EventArgs e) {
            if (dg_items.Columns.FirstOrDefault(x => x.Header.ToString() == "Name") != null) {
                dg_items.Columns.FindColumn(nameof(IMhwItem.Name)).DisplayIndex = 0;
            }

            if (targetFileType.Is(typeof(Armor))) {
                var setGroupIndex = dg_items.Columns.FindColumn(nameof(Armor.Set_Group)).DisplayIndex;
                dg_items.Columns.FindColumn(nameof(Armor.Is_Permanent)).DisplayIndex = setGroupIndex + 1;
            }

            if (targetFileType.Is(typeof(Melee))) {
                var part2Index = dg_items.Columns.FindColumn(nameof(Melee.Part_2_Id)).DisplayIndex;
                dg_items.Columns.FindColumn(nameof(Melee.Is_Fixed_Upgrade)).DisplayIndex = part2Index + 1;

                var rarityIndex = dg_items.Columns.FindColumn(nameof(Melee.Rarity)).DisplayIndex;
                dg_items.Columns.FindColumn(nameof(Melee.Sharpness_Quality)).DisplayIndex = rarityIndex + 1;
                dg_items.Columns.FindColumn(nameof(Melee.Sharpness_Amount)).DisplayIndex = rarityIndex + 2;
            }

            if (targetFileType.Is(typeof(Ranged))) {
                var part2Index = dg_items.Columns.FindColumn(nameof(Melee.Part_2_Id)).DisplayIndex;
                dg_items.Columns.FindColumn(nameof(Ranged.Is_Fixed_Upgrade)).DisplayIndex = part2Index + 1;

                var slotSize3Index = dg_items.Columns.FindColumn(nameof(Ranged.Slot_3_Size)).DisplayIndex;
                dg_items.Columns.FindColumn(nameof(Ranged.Special_Ammo_Type)).DisplayIndex = slotSize3Index + 1;
            }

            if (targetFileType.Is(typeof(BottleTable), typeof(ShellTable))) {
                dg_items.Columns.FindColumn(nameof(BottleTable.Index)).DisplayIndex = 0;
            }

            if (targetFileType.Is(typeof(SkillDat))) {
                dg_items.Columns.FindColumn(nameof(SkillDat.Description)).DisplayIndex = dg_items.Columns.Count - 1;
            }

            if (targetFileType.Is(typeof(Item))) {
                var sortOrderIndex = dg_items.Columns.FindColumn(nameof(Item.Sort_Order)).DisplayIndex;
                dg_items.Columns.FindColumn(nameof(Item.Flags)).DisplayIndex = sortOrderIndex + 1;
                dg_items.Columns.FindColumn(nameof(Item.Is_Infinite_Use)).DisplayIndex = sortOrderIndex + 2;
                dg_items.Columns.FindColumn(nameof(Item.Is_Account_Item)).DisplayIndex = sortOrderIndex + 3;
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
#pragma warning disable 162
            if (SHOW_RAW_BYTES) {
                dg_items.Columns.FindColumn(nameof(MhwItem.Raw_Data)).DisplayIndex = dg_items.Columns.Count - 1;
            }
#pragma warning restore 162

            foreach (var column in dg_items.Columns) {
                switch (column.Header.ToString()) {
                    case nameof(Armor.Set_Id):
                        column.Header = "Set (Layered) Id";
                        break;
                }

                if (column.Header.ToString().Contains("Hidden_Element")) {
                    column.Header = column.Header.ToString().Replace("Hidden_Element", "Element (Hidden)");
                }

                column.Header = ((string) column.Header).Replace("_", " ");
            }
        }

        private void Dg_items_GotFocus(object sender, RoutedEventArgs e) {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell)) {
                // Starts the Edit on the row;
                dg_items.BeginEdit(e);
            }
        }

        private void Dg_items_Sorting(object sender, DataGridSortingEventArgs e) {
            if (targetFileType.Is(typeof(SkillDat)) && (string) e.Column.Header == "Name/ID") {
                var column = (DataGridTextColumn) e.Column;
                var direction = (column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
                SkillDatSorter.INSTANCE.direction = direction;
                column.SortDirection = direction;

                var listColView = (ListCollectionView) dg_items.ItemsSource;
                listColView.CustomSort = SkillDatSorter.INSTANCE;

                e.Handled = true;
            }
        }

        private void Btn_open_Click(object sender, RoutedEventArgs e) {
            var target = Open();
            if (string.IsNullOrEmpty(target)) return;
            Load(target);

            dg_items.ItemsSource = null;
            dg_items.ItemsSource = new ListCollectionView(items);
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;
            Save();
        }

        private void Btn_slot_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(IWeapon), typeof(Armor))) return;

            foreach (ISlots item in items) {
                item.Slot_Count = 3;
                item.Slot_1_Size = 4;
                item.Slot_2_Size = 4;
                item.Slot_3_Size = 4;

                ((MhwItem) item).OnPropertyChanged();
            }
        }

        private void Btn_set_bonus_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(Armor))) return;

            foreach (Armor item in items) {
                if (item.Set_Skill_1_Level > 0) {
                    item.Set_Skill_1_Level = 5;
                }

                item.OnPropertyChanged();
            }
        }

        private void Btn_skill_level_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(Gem), typeof(Armor))) return;

            foreach (var item in items) {
                switch (item) {
                    case Gem _: {
                        Gem gem = item;

                        gem.Skill_1_Level = 10;

                        if (gem.Skill_2_Level > 0) {
                            gem.Skill_2_Level = 10;
                        }

                        break;
                    }
                    case Armor _: {
                        Armor armor = item;

                        if (armor.Skill_1_Level > 0) {
                            armor.Skill_1_Level = 10;
                        }

                        if (armor.Skill_2_Level > 0) {
                            armor.Skill_2_Level = 10;
                        }

                        if (armor.Skill_3_Level > 0) {
                            armor.Skill_3_Level = 10;
                        }

                        break;
                    }
                }

                item.OnPropertyChanged();
            }
        }

        private void Btn_zenny_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(Item), typeof(Armor), typeof(IWeapon))) return;

            foreach (var item in items) {
                switch (item) {
                    case Item _: {
                        Item itm = item;

                        if (itm.Buy_Price > 0) {
                            itm.Buy_Price = 1;
                        }

                        break;
                    }
                    case Armor _: {
                        Armor armor = item;

                        if (armor.Cost > 0) {
                            armor.Cost = 1;
                        }

                        break;
                    }
                    case IWeapon _: {
                        IWeapon weapon = item;

                        if (weapon.Cost > 0) {
                            weapon.Cost = 1;
                        }

                        break;
                    }
                }

                item.OnPropertyChanged();
            }
        }

        private void Btn_damage_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(IWeapon))) return;

            foreach (IWeapon item in items) {
                if (item.Damage > 0) {
                    item.Damage = 5000;
                }

                ((MhwItem) item).OnPropertyChanged();
            }
        }

        private void Btn_enable_all_coatings_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(BottleTable))) return;

            foreach (BottleTable item in items) {
                item.Close_Range = CoatingType.On;
                item.Power = CoatingType.On;
                item.Paralysis = CoatingType.On;
                item.Poison = CoatingType.On;
                item.Sleep = CoatingType.On;
                item.Blast = CoatingType.On;

                item.OnPropertyChanged();
            }
        }

        private void Btn_max_sharpness_cheat_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(Sharpness), typeof(Melee))) return;

            foreach (var item in items) {
                switch (item) {
                    case Sharpness _: {
                        Sharpness sharpness = item;

                        sharpness.Red = 10;
                        sharpness.Orange = 10;
                        sharpness.Yellow = 10;
                        sharpness.Green = 10;
                        sharpness.Blue = 10;
                        sharpness.White = 10;
                        sharpness.Purple = 400;

                        break;
                    }
                    case Melee _: {
                        Melee weapon = item;

                        if (weapon.Sharpness_Amount > 0) {
                            weapon.Sharpness_Amount = 5;
                        }

                        break;
                    }
                }

                item.OnPropertyChanged();
            }
        }

        private void Btn_sort_jewel_order_by_name_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!targetFileType.Is(typeof(Item))) return;

            var rawList = new List<GemData>();
            for (var i = 0; i < items.Count; i++) {
                Item item = items[i];
                if (item.Name.Contains(" Jewel")) {
                    rawList.Add(new GemData {index = i, itemName = item.Name, sortOrder = item.Sort_Order});
                }
            }

            var sortedSortIndexes = new List<GemData>(rawList);
            sortedSortIndexes.Sort((g1, g2) => g1.sortOrder.CompareTo(g2.sortOrder));
            var sortedGemNameIndexes = new List<GemData>(rawList);
            sortedGemNameIndexes.Sort((g1, g2) => string.Compare(g1.itemName, g2.itemName, StringComparison.Ordinal));

            for (var i = 0; i < sortedSortIndexes.Count; i++) {
                var index = sortedGemNameIndexes[i].index;
                var newSortIndex = sortedSortIndexes[i].sortOrder;
                Item item = items[index];
                item.Sort_Order = newSortIndex;
            }
        }

        private string Open() {
            var ofdResult = new OpenFileDialog {
                Filter = $"MHW Data Files (See mod description for full list.)|{string.Join(";", FILE_TYPES)}",
                Multiselect = false
            };
            ofdResult.ShowDialog();

            return ofdResult.FileName;
        }

        private void Load(string target) {
            targetFile = target;
            targetFileType = GetFileType();
            items.Clear();
            Title = Path.GetFileName(targetFile);

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
            var initialOffset = (ulong) targetFileType.GetField(nameof(Armor.InitialOffset), flags).GetValue(null);
            var structSize = (uint) targetFileType.GetField(nameof(Armor.StructSize), flags).GetValue(null);
            var entryCountOffset = (long) targetFileType.GetField(nameof(Armor.EntryCountOffset), flags).GetValue(null);

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
#pragma warning disable 162
            if (ENABLE_CHEAT_BUTTONS) {
                btn_slot_cheat.Visibility = targetFileType.Is(typeof(Armor), typeof(IWeapon)) ? Visibility.Visible : Visibility.Collapsed;
                btn_skill_level_cheat.Visibility = targetFileType.Is(typeof(Armor), typeof(Gem)) ? Visibility.Visible : Visibility.Collapsed;
                btn_set_bonus_cheat.Visibility = targetFileType.Is(typeof(Armor)) ? Visibility.Visible : Visibility.Collapsed;
                btn_zenny_cheat.Visibility = targetFileType.Is(typeof(Armor), typeof(Item), typeof(IWeapon)) ? Visibility.Visible : Visibility.Collapsed;
                btn_damage_cheat.Visibility = targetFileType.Is(typeof(IWeapon)) ? Visibility.Visible : Visibility.Collapsed;
                btn_enable_all_coatings_cheat.Visibility = targetFileType.Is(typeof(BottleTable)) ? Visibility.Visible : Visibility.Collapsed;
                btn_max_sharpness_cheat.Visibility = targetFileType.Is(typeof(Sharpness), typeof(Melee)) ? Visibility.Visible : Visibility.Collapsed;
            }
#pragma warning restore 162

            btn_sort_jewel_order_by_name.Visibility = targetFileType.Is(typeof(Item)) ? Visibility.Visible : Visibility.Collapsed;

            var weaponFilename = Path.GetFileNameWithoutExtension(targetFile);

            using (var dat = new BinaryReader(new FileStream(targetFile, FileMode.Open, FileAccess.Read))) {
                if (entryCountOffset >= 0) {
                    ReadStructsAsKnownLength(dat, structSize, initialOffset, weaponFilename, entryCountOffset);
                } else {
                    ReadStructsAsUnknownLength(dat, structSize, initialOffset, weaponFilename);
                }
            }
        }

        private void ReadStructsAsKnownLength(BinaryReader dat, uint structSize, ulong initialOffset, string weaponFilename, long entryCountOffset) {
            dat.BaseStream.Seek(entryCountOffset, SeekOrigin.Begin);
            var count = dat.ReadInt32();

            dat.BaseStream.Seek((long) initialOffset, SeekOrigin.Begin);

            for (var i = 0; i < count; i++) {
                var position = dat.BaseStream.Position;
                var buff = dat.ReadBytes((int) structSize);

                object obj;
                if (targetFileType.Is(typeof(IWeapon))) {
                    obj = Activator.CreateInstance(targetFileType, buff, (ulong) position, weaponFilename);
                } else {
                    obj = Activator.CreateInstance(targetFileType, buff, (ulong) position);
                }

                if (obj == null) return;

                items.Add(obj);
            }
        }

        private void ReadStructsAsUnknownLength(BinaryReader dat, uint structSize, ulong offset, string weaponFilename) {
            var len = (ulong) dat.BaseStream.Length;
            do {
                var buff = new byte[structSize];
                dat.BaseStream.Seek((long) offset, SeekOrigin.Begin);
                dat.Read(buff, 0, (int) structSize);

                object obj;
                if (targetFileType.Is(typeof(IWeapon))) {
                    obj = Activator.CreateInstance(targetFileType, buff, offset, weaponFilename);
                } else {
                    obj = Activator.CreateInstance(targetFileType, buff, offset);
                }

                if (obj == null) return;

                items.Add(obj);

                offset += structSize;
            } while (offset + structSize <= len);
        }

        private async void Save() {
            var changesSaved = false;
            using (var dat = new BinaryWriter(new FileStream(targetFile, FileMode.Open, FileAccess.Write))) {
                foreach (IMhwItem item in items) {
                    if (item.Offset == 0 || !item.Changed) continue;

                    dat.BaseStream.Seek((long) item.Offset, SeekOrigin.Begin);
                    dat.Write(item.Bytes);

                    item.Changed = false;
                    changesSaved = true;
                }
            }

            savedTimer?.Cancel();
            savedTimer = new CancellationTokenSource();
            lbl_saved.Visibility = changesSaved ? Visibility.Visible : Visibility.Collapsed;
            lbl_no_changes.Visibility = changesSaved ? Visibility.Collapsed : Visibility.Visible;
            try {
                await Task.Delay(3000, savedTimer.Token);
                lbl_saved.Visibility = lbl_no_changes.Visibility = Visibility.Hidden;
            } catch (TaskCanceledException) {
            }
        }

        private Type GetFileType() {
            var fileName = Path.GetFileName(targetFile);
            Debug.Assert(fileName != null, nameof(fileName) + " != null");

            if (fileName.EndsWith(".wp_dat")) {
                return typeof(Melee);
            }

            if (fileName.EndsWith(".wp_dat_g")) {
                if (fileName.StartsWith("bow")) {
                    return typeof(Bow);
                }

                if (fileName.StartsWith("lbg") || fileName.StartsWith("hbg")) {
                    return typeof(BowGun);
                }
            }

            if (fileName.EndsWith(".am_dat")) {
                return typeof(Armor);
            }

            if (fileName.EndsWith(".sgpa")) {
                return typeof(Gem);
            }

            if (fileName.EndsWith(".itm")) {
                return typeof(Item);
            }

            if (fileName.EndsWith(".bbtbl")) {
                return typeof(BottleTable);
            }

            if (fileName.EndsWith(".arm_up")) {
                return typeof(ArmUp);
            }

            if (fileName.EndsWith(".kire")) {
                return typeof(Sharpness);
            }

            if (fileName.EndsWith(".skl_dat")) {
                return typeof(SkillDat);
            }

            if (fileName.EndsWith(".shl_tbl")) {
                return typeof(ShellTable);
            }

            if (fileName.EndsWith(".new_lbr")) {
                return typeof(NewLimitBreak);
            }

            if (fileName.EndsWith(".wep_wsd")) {
                return typeof(WeaponWSword);
            }

            if (fileName.EndsWith(".wep_wsl")) {
                return typeof(WeaponWhistle);
            }

            if (fileName.EndsWith(".wep_glan")) {
                return typeof(WeaponGunLance);
            }

            if (fileName.EndsWith(".wep_saxe")) {
                return typeof(WeaponSwitchAxe);
            }

            if (fileName.EndsWith(".skl_pt_dat")) {
                return typeof(SkillPointData);
            }

            if (fileName.EndsWith(".ask")) {
                return typeof(ASkill);
            }

            throw new Exception($"No type found for: {fileName}");
        }
    }
}