using System.Collections.ObjectModel;
using MHW_Editor.Models;

namespace MHW_Editor.PlData {
    public partial class PlSkillParam {
        public ObservableCollection<PlDataItemCustomView> GetCustomView() {
            return new ObservableCollection<PlDataItemCustomView> {
                new PlDataItemCustomView(this, "Speed Eating 1 Drink Motion Speed", "Speed_Eating_1_Drink_Motion_Speed", Bytes, 8),
                new PlDataItemCustomView(this, "Speed Eating 2 Drink Motion Speed", "Speed_Eating_2_Drink_Motion_Speed", Bytes, 12),
                new PlDataItemCustomView(this, "Speed Eating 3 Drink Motion Speed", "Speed_Eating_3_Drink_Motion_Speed", Bytes, 16),
                new PlDataItemCustomView(this, "Speed Eating 1 Drink End Frame", "Speed_Eating_1_Drink_End_Frame", Bytes, 20),
                new PlDataItemCustomView(this, "Speed Eating 2 Drink End Frame", "Speed_Eating_2_Drink_End_Frame", Bytes, 24),
                new PlDataItemCustomView(this, "Speed Eating 3 Drink End Frame", "Speed_Eating_3_Drink_End_Frame", Bytes, 28),
                new PlDataItemCustomView(this, "Speed Eating 1 Heal Speed Rate", "Speed_Eating_1_Heal_Speed_Rate", Bytes, 32),
                new PlDataItemCustomView(this, "Speed Eating 2 Heal Speed Rate", "Speed_Eating_2_Heal_Speed_Rate", Bytes, 36),
                new PlDataItemCustomView(this, "Speed Eating 3 Heal Speed Rate", "Speed_Eating_3_Heal_Speed_Rate", Bytes, 40),
                new PlDataItemCustomView(this, "Speed Eating 1 Meat Motion Speed", "Speed_Eating_1_Meat_Motion_Speed", Bytes, 44),
                new PlDataItemCustomView(this, "Speed Eating 2 Meat Motion Speed", "Speed_Eating_2_Meat_Motion_Speed", Bytes, 48),
                new PlDataItemCustomView(this, "Speed Eating 3 Meat Motion Speed", "Speed_Eating_3_Meat_Motion_Speed", Bytes, 52),
                new PlDataItemCustomView(this, "Speed Eating 1 Meat Loop Count", "Speed_Eating_1_Meat_Loop_Count", Bytes, 56),
                new PlDataItemCustomView(this, "Speed Eating 2 Meat Loop Count", "Speed_Eating_2_Meat_Loop_Count", Bytes, 57),
                new PlDataItemCustomView(this, "Speed Eating 3 Meat Loop Count", "Speed_Eating_3_Meat_Loop_Count", Bytes, 58),
                new PlDataItemCustomView(this, "Speed Eating 1/2/3 Meat End Frame", "Speed_Eating_1_2_3_Meat_End_Frame", Bytes, 59),
                new PlDataItemCustomView(this, "Speed Eating 1 Tablet Motion Speed", "Speed_Eating_1_Tablet_Motion_Speed", Bytes, 63),
                new PlDataItemCustomView(this, "Speed Eating 2 Tablet Motion Speed", "Speed_Eating_2_Tablet_Motion_Speed", Bytes, 67),
                new PlDataItemCustomView(this, "Speed Eating 3 Tablet Motion Speed", "Speed_Eating_3_Tablet_Motion_Speed", Bytes, 71),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__1000", Bytes, 3),
                new PlDataItemCustomView(this, "Mud Motion Speed", "Mud_Motion_Speed", Bytes, 75),
                new PlDataItemCustomView(this, "Mud Trans Rate", "Mud_Trans_Rate", Bytes, 79),
                new PlDataItemCustomView(this, "Elemental Damage Defense %", "Elemental_Damage_Defense_", Bytes, 83),
                new PlDataItemCustomView(this, "Elemental Damage Resist %", "Elemental_Damage_Resist_", Bytes, 84),
                new PlDataItemCustomView(this, "Elemental Damage Resist", "Elemental_Damage_Resist", Bytes, 85),
                new PlDataItemCustomView(this, "Weakness Exploit Hitzone Threshold", "Weakness_Exploit_Hitzone_Threshold", Bytes, 86),
                new PlDataItemCustomView(this, "Latent Power Activation Time", "Latent_Power_Activation_Time", Bytes, 87),
                new PlDataItemCustomView(this, "Latent Power Total Damage to Trigger", "Latent_Power_Total_Damage_to_Trigger", Bytes, 89),
                new PlDataItemCustomView(this, "Latent Power Secret Total Damage to Trigger", "Latent_Power_Secret_Total_Damage_to_Trigger", Bytes, 91),
                new PlDataItemCustomView(this, "Heroics Activation Health %", "Heroics_Activation_Health_", Bytes, 93),
                new PlDataItemCustomView(this, "Guts Health Threshold", "Guts_Health_Threshold", Bytes, 97),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__1600", Bytes, 3),
                new PlDataItemCustomView(this, "Wide Range 1 Efficiency", "Wide_Range_1_Efficiency", Bytes, 98),
                new PlDataItemCustomView(this, "Wide Range 2 Efficiency", "Wide_Range_2_Efficiency", Bytes, 102),
                new PlDataItemCustomView(this, "Wide Range 3 Efficiency", "Wide_Range_3_Efficiency", Bytes, 106),
                new PlDataItemCustomView(this, "Wide Range 4 Efficiency", "Wide_Range_4_Efficiency", Bytes, 110),
                new PlDataItemCustomView(this, "Wide Range 5 Efficiency", "Wide_Range_5_Efficiency", Bytes, 114),
                new PlDataItemCustomView(this, "Wide Range 1 Range", "Wide_Range_1_Range", Bytes, 118),
                new PlDataItemCustomView(this, "Wide Range 2 Range", "Wide_Range_2_Range", Bytes, 122),
                new PlDataItemCustomView(this, "Wide Range 3 Range", "Wide_Range_3_Range", Bytes, 126),
                new PlDataItemCustomView(this, "Wide Range 4 Range", "Wide_Range_4_Range", Bytes, 130),
                new PlDataItemCustomView(this, "Wide Range 5 Range", "Wide_Range_5_Range", Bytes, 134),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__2150", Bytes, 3),
                new PlDataItemCustomView(this, "Unk1", "Unk1", Bytes, 138),
                new PlDataItemCustomView(this, "Unk2", "Unk2", Bytes, 142),
                new PlDataItemCustomView(this, "Unk3", "Unk3", Bytes, 146),
                new PlDataItemCustomView(this, "Unk4", "Unk4", Bytes, 150),
                new PlDataItemCustomView(this, "Unk5", "Unk5", Bytes, 154),
                new PlDataItemCustomView(this, "Unk6", "Unk6", Bytes, 158),
                new PlDataItemCustomView(this, "Unk7", "Unk7", Bytes, 162),
                new PlDataItemCustomView(this, "Unk8", "Unk8", Bytes, 166),
                new PlDataItemCustomView(this, "Unk9", "Unk9", Bytes, 170),
                new PlDataItemCustomView(this, "Unk10", "Unk10", Bytes, 174),
                new PlDataItemCustomView(this, "Unk11", "Unk11", Bytes, 178),
                new PlDataItemCustomView(this, "Unk12", "Unk12", Bytes, 182),
                new PlDataItemCustomView(this, "Unk13", "Unk13", Bytes, 186),
                new PlDataItemCustomView(this, "Unk14", "Unk14", Bytes, 190),
                new PlDataItemCustomView(this, "Unk15", "Unk15", Bytes, 194),
                new PlDataItemCustomView(this, "Unk16", "Unk16", Bytes, 198),
                new PlDataItemCustomView(this, "Unk17", "Unk17", Bytes, 202),
                new PlDataItemCustomView(this, "Unk18", "Unk18", Bytes, 202),
                new PlDataItemCustomView(this, "Unk19", "Unk19", Bytes, 206),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__3150", Bytes, 3),
                new PlDataItemCustomView(this, "Focus (Gunlance, Charge Shot) Time Rate 1", "Focus_Gunlance_Charge_Shot_Time_Rate_1", Bytes, 210),
                new PlDataItemCustomView(this, "Focus (Gunlance, Charge Shot) Time Rate 2", "Focus_Gunlance_Charge_Shot_Time_Rate_2", Bytes, 214),
                new PlDataItemCustomView(this, "Focus (Gunlance, Charge Shot) Time Rate 3", "Focus_Gunlance_Charge_Shot_Time_Rate_3", Bytes, 218),
                new PlDataItemCustomView(this, "Focus (Charge Blade, Slash 2) Time Rate 1", "Focus_Charge_Blade_Slash_2_Time_Rate_1", Bytes, 222),
                new PlDataItemCustomView(this, "Focus (Charge Blade, Slash 2) Time Rate 2", "Focus_Charge_Blade_Slash_2_Time_Rate_2", Bytes, 226),
                new PlDataItemCustomView(this, "Focus (Charge Blade, Slash 2) Time Rate 3", "Focus_Charge_Blade_Slash_2_Time_Rate_3", Bytes, 230),
                new PlDataItemCustomView(this, "Focus (Charge Blade, Phial Charge Slash) Time Rate 1", "Focus_Charge_Blade_Phial_Charge_Slash_Time_Rate_1", Bytes, 234),
                new PlDataItemCustomView(this, "Focus (Charge Blade, Phial Charge Slash) Time Rate 2", "Focus_Charge_Blade_Phial_Charge_Slash_Time_Rate_2", Bytes, 238),
                new PlDataItemCustomView(this, "Focus (Charge Blade, Phial Charge Slash) Time Rate 3", "Focus_Charge_Blade_Phial_Charge_Slash_Time_Rate_3", Bytes, 242),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__3650", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Great Sword) Attack Power", "Punishing_Draw_Great_Sword_Attack_Power", Bytes, 246),
                new PlDataItemCustomView(this, "Punishing Draw (Great Sword) Stun", "Punishing_Draw_Great_Sword_Stun", Bytes, 248),
                new PlDataItemCustomView(this, "Punishing Draw (Great Sword) Exhaust", "Punishing_Draw_Great_Sword_Exhaust", Bytes, 250),
                new PlDataItemCustomView(this, "Punishing Draw (Great Sword) Param 4", "Punishing_Draw_Great_Sword_Param_4", Bytes, 252),
                new PlDataItemCustomView(this, "Punishing Draw (Great Sword) Param 5", "Punishing_Draw_Great_Sword_Param_5", Bytes, 254),
                new PlDataItemCustomView(this, "Punishing Draw (Great Sword) Param 6", "Punishing_Draw_Great_Sword_Param_6", Bytes, 256),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__4000", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Sword & Shield) Attack Power", "Punishing_Draw_Sword_Shield_Attack_Power", Bytes, 258),
                new PlDataItemCustomView(this, "Punishing Draw (Sword & Shield) Stun", "Punishing_Draw_Sword_Shield_Stun", Bytes, 260),
                new PlDataItemCustomView(this, "Punishing Draw (Sword & Shield) Exhaust", "Punishing_Draw_Sword_Shield_Exhaust", Bytes, 262),
                new PlDataItemCustomView(this, "Punishing Draw (Sword & Shield) Param 4", "Punishing_Draw_Sword_Shield_Param_4", Bytes, 264),
                new PlDataItemCustomView(this, "Punishing Draw (Sword & Shield) Param 5", "Punishing_Draw_Sword_Shield_Param_5", Bytes, 266),
                new PlDataItemCustomView(this, "Punishing Draw (Sword & Shield) Param 6", "Punishing_Draw_Sword_Shield_Param_6", Bytes, 268),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__4350", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Dual Blades) Attack Power", "Punishing_Draw_Dual_Blades_Attack_Power", Bytes, 270),
                new PlDataItemCustomView(this, "Punishing Draw (Dual Blades) Stun", "Punishing_Draw_Dual_Blades_Stun", Bytes, 272),
                new PlDataItemCustomView(this, "Punishing Draw (Dual Blades) Exhaust", "Punishing_Draw_Dual_Blades_Exhaust", Bytes, 274),
                new PlDataItemCustomView(this, "Punishing Draw (Dual Blades) Param 4", "Punishing_Draw_Dual_Blades_Param_4", Bytes, 276),
                new PlDataItemCustomView(this, "Punishing Draw (Dual Blades) Param 5", "Punishing_Draw_Dual_Blades_Param_5", Bytes, 278),
                new PlDataItemCustomView(this, "Punishing Draw (Dual Blades) Param 6", "Punishing_Draw_Dual_Blades_Param_6", Bytes, 280),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__4700", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Long Sword) Attack Power", "Punishing_Draw_Long_Sword_Attack_Power", Bytes, 282),
                new PlDataItemCustomView(this, "Punishing Draw (Long Sword) Stun", "Punishing_Draw_Long_Sword_Stun", Bytes, 284),
                new PlDataItemCustomView(this, "Punishing Draw (Long Sword) Exhaust", "Punishing_Draw_Long_Sword_Exhaust", Bytes, 286),
                new PlDataItemCustomView(this, "Punishing Draw (Long Sword) Param 4", "Punishing_Draw_Long_Sword_Param_4", Bytes, 288),
                new PlDataItemCustomView(this, "Punishing Draw (Long Sword) Param 5", "Punishing_Draw_Long_Sword_Param_5", Bytes, 290),
                new PlDataItemCustomView(this, "Punishing Draw (Long Sword) Param 6", "Punishing_Draw_Long_Sword_Param_6", Bytes, 292),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__5050", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Hammer) Attack Power", "Punishing_Draw_Hammer_Attack_Power", Bytes, 294),
                new PlDataItemCustomView(this, "Punishing Draw (Hammer) Stun", "Punishing_Draw_Hammer_Stun", Bytes, 296),
                new PlDataItemCustomView(this, "Punishing Draw (Hammer) Exhaust", "Punishing_Draw_Hammer_Exhaust", Bytes, 298),
                new PlDataItemCustomView(this, "Punishing Draw (Hammer) Param 4", "Punishing_Draw_Hammer_Param_4", Bytes, 300),
                new PlDataItemCustomView(this, "Punishing Draw (Hammer) Param 5", "Punishing_Draw_Hammer_Param_5", Bytes, 302),
                new PlDataItemCustomView(this, "Punishing Draw (Hammer) Param 6", "Punishing_Draw_Hammer_Param_6", Bytes, 304),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__5400", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Hunting Horn) Attack Power", "Punishing_Draw_Hunting_Horn_Attack_Power", Bytes, 306),
                new PlDataItemCustomView(this, "Punishing Draw (Hunting Horn) Stun", "Punishing_Draw_Hunting_Horn_Stun", Bytes, 308),
                new PlDataItemCustomView(this, "Punishing Draw (Hunting Horn) Exhaust", "Punishing_Draw_Hunting_Horn_Exhaust", Bytes, 310),
                new PlDataItemCustomView(this, "Punishing Draw (Hunting Horn) Param 4", "Punishing_Draw_Hunting_Horn_Param_4", Bytes, 312),
                new PlDataItemCustomView(this, "Punishing Draw (Hunting Horn) Param 5", "Punishing_Draw_Hunting_Horn_Param_5", Bytes, 314),
                new PlDataItemCustomView(this, "Punishing Draw (Hunting Horn) Param 6", "Punishing_Draw_Hunting_Horn_Param_6", Bytes, 316),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__5750", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Lance) Attack Power", "Punishing_Draw_Lance_Attack_Power", Bytes, 318),
                new PlDataItemCustomView(this, "Punishing Draw (Lance) Stun", "Punishing_Draw_Lance_Stun", Bytes, 320),
                new PlDataItemCustomView(this, "Punishing Draw (Lance) Exhaust", "Punishing_Draw_Lance_Exhaust", Bytes, 322),
                new PlDataItemCustomView(this, "Punishing Draw (Lance) Param 4", "Punishing_Draw_Lance_Param_4", Bytes, 324),
                new PlDataItemCustomView(this, "Punishing Draw (Lance) Param 5", "Punishing_Draw_Lance_Param_5", Bytes, 326),
                new PlDataItemCustomView(this, "Punishing Draw (Lance) Param 6", "Punishing_Draw_Lance_Param_6", Bytes, 328),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__6100", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Gunlance) Attack Power", "Punishing_Draw_Gunlance_Attack_Power", Bytes, 330),
                new PlDataItemCustomView(this, "Punishing Draw (Gunlance) Stun", "Punishing_Draw_Gunlance_Stun", Bytes, 332),
                new PlDataItemCustomView(this, "Punishing Draw (Gunlance) Exhaust", "Punishing_Draw_Gunlance_Exhaust", Bytes, 334),
                new PlDataItemCustomView(this, "Punishing Draw (Gunlance) Param 4", "Punishing_Draw_Gunlance_Param_4", Bytes, 336),
                new PlDataItemCustomView(this, "Punishing Draw (Gunlance) Param 5", "Punishing_Draw_Gunlance_Param_5", Bytes, 338),
                new PlDataItemCustomView(this, "Punishing Draw (Gunlance) Param 6", "Punishing_Draw_Gunlance_Param_6", Bytes, 340),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__6450", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Switch Axe) Attack Power", "Punishing_Draw_Switch_Axe_Attack_Power", Bytes, 342),
                new PlDataItemCustomView(this, "Punishing Draw (Switch Axe) Stun", "Punishing_Draw_Switch_Axe_Stun", Bytes, 344),
                new PlDataItemCustomView(this, "Punishing Draw (Switch Axe) Exhaust", "Punishing_Draw_Switch_Axe_Exhaust", Bytes, 346),
                new PlDataItemCustomView(this, "Punishing Draw (Switch Axe) Param 4", "Punishing_Draw_Switch_Axe_Param_4", Bytes, 348),
                new PlDataItemCustomView(this, "Punishing Draw (Switch Axe) Param 5", "Punishing_Draw_Switch_Axe_Param_5", Bytes, 350),
                new PlDataItemCustomView(this, "Punishing Draw (Switch Axe) Param 6", "Punishing_Draw_Switch_Axe_Param_6", Bytes, 352),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__6800", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Charge Blade) Attack Power", "Punishing_Draw_Charge_Blade_Attack_Power", Bytes, 354),
                new PlDataItemCustomView(this, "Punishing Draw (Charge Blade) Stun", "Punishing_Draw_Charge_Blade_Stun", Bytes, 356),
                new PlDataItemCustomView(this, "Punishing Draw (Charge Blade) Exhaust", "Punishing_Draw_Charge_Blade_Exhaust", Bytes, 358),
                new PlDataItemCustomView(this, "Punishing Draw (Charge Blade) Param 4", "Punishing_Draw_Charge_Blade_Param_4", Bytes, 360),
                new PlDataItemCustomView(this, "Punishing Draw (Charge Blade) Param 5", "Punishing_Draw_Charge_Blade_Param_5", Bytes, 362),
                new PlDataItemCustomView(this, "Punishing Draw (Charge Blade) Param 6", "Punishing_Draw_Charge_Blade_Param_6", Bytes, 364),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__7150", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Insect Glaive) Attack Power", "Punishing_Draw_Insect_Glaive_Attack_Power", Bytes, 366),
                new PlDataItemCustomView(this, "Punishing Draw (Insect Glaive) Stun", "Punishing_Draw_Insect_Glaive_Stun", Bytes, 368),
                new PlDataItemCustomView(this, "Punishing Draw (Insect Glaive) Exhaust", "Punishing_Draw_Insect_Glaive_Exhaust", Bytes, 370),
                new PlDataItemCustomView(this, "Punishing Draw (Insect Glaive) Param 4", "Punishing_Draw_Insect_Glaive_Param_4", Bytes, 372),
                new PlDataItemCustomView(this, "Punishing Draw (Insect Glaive) Param 5", "Punishing_Draw_Insect_Glaive_Param_5", Bytes, 374),
                new PlDataItemCustomView(this, "Punishing Draw (Insect Glaive) Param 6", "Punishing_Draw_Insect_Glaive_Param_6", Bytes, 376),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__7500", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (Bow) Attack Power", "Punishing_Draw_Bow_Attack_Power", Bytes, 378),
                new PlDataItemCustomView(this, "Punishing Draw (Bow) Stun", "Punishing_Draw_Bow_Stun", Bytes, 380),
                new PlDataItemCustomView(this, "Punishing Draw (Bow) Exhaust", "Punishing_Draw_Bow_Exhaust", Bytes, 382),
                new PlDataItemCustomView(this, "Punishing Draw (Bow) Param 4", "Punishing_Draw_Bow_Param_4", Bytes, 384),
                new PlDataItemCustomView(this, "Punishing Draw (Bow) Param 5", "Punishing_Draw_Bow_Param_5", Bytes, 386),
                new PlDataItemCustomView(this, "Punishing Draw (Bow) Param 6", "Punishing_Draw_Bow_Param_6", Bytes, 388),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__7850", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (HBG) Attack Power", "Punishing_Draw_HBG_Attack_Power", Bytes, 390),
                new PlDataItemCustomView(this, "Punishing Draw (HBG) Stun", "Punishing_Draw_HBG_Stun", Bytes, 392),
                new PlDataItemCustomView(this, "Punishing Draw (HBG) Exhaust", "Punishing_Draw_HBG_Exhaust", Bytes, 394),
                new PlDataItemCustomView(this, "Punishing Draw (HBG) Param 4", "Punishing_Draw_HBG_Param_4", Bytes, 396),
                new PlDataItemCustomView(this, "Punishing Draw (HBG) Param 5", "Punishing_Draw_HBG_Param_5", Bytes, 398),
                new PlDataItemCustomView(this, "Punishing Draw (HBG) Param 6", "Punishing_Draw_HBG_Param_6", Bytes, 400),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__8200", Bytes, 3),
                new PlDataItemCustomView(this, "Punishing Draw (LBG) Attack Power", "Punishing_Draw_LBG_Attack_Power", Bytes, 402),
                new PlDataItemCustomView(this, "Punishing Draw (LBG) Stun", "Punishing_Draw_LBG_Stun", Bytes, 404),
                new PlDataItemCustomView(this, "Punishing Draw (LBG) Exhaust", "Punishing_Draw_LBG_Exhaust", Bytes, 406),
                new PlDataItemCustomView(this, "Punishing Draw (LBG) Param 4", "Punishing_Draw_LBG_Param_4", Bytes, 408),
                new PlDataItemCustomView(this, "Punishing Draw (LBG) Param 5", "Punishing_Draw_LBG_Param_5", Bytes, 410),
                new PlDataItemCustomView(this, "Punishing Draw (LBG) Param 6", "Punishing_Draw_LBG_Param_6", Bytes, 412),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__8550", Bytes, 3),
                new PlDataItemCustomView(this, "-------------------------------------------------------------------------------------------", "__8600", Bytes, 3),
                new PlDataItemCustomView(this, "------Skipping the rest.", "_Skipping_the_rest__8650", Bytes, 3),
            };
        }
    }
}