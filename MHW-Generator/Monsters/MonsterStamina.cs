﻿using System.Collections.Generic;
using MHW_Generator.Models;
using MHW_Template.Models;
using MHW_Template.Struct_Generation;

namespace MHW_Generator.Monsters {
    public class MonsterStamina : IMultiStruct {
        public MultiStruct Generate() { // .dtt_sta
            // Fatigue
            var fatigue = new List<MhwMultiStructData.Entry> {
                new MhwMultiStructData.Entry("Duration", typeof(float)),
                new MhwMultiStructData.Entry("Stamina Min", typeof(uint)),
                new MhwMultiStructData.Entry("Stamina Max", typeof(uint))
            };
            // Stamina
            var stamina = new List<MhwMultiStructData.Entry> {
                new MhwMultiStructData.Entry("Unk", typeof(uint)),
                new MhwMultiStructData.Entry("Base", typeof(uint))
            };
            var staminaCount = new List<MhwMultiStructData.Entry> {
                new MhwMultiStructData.Entry("Number of Stamina Entries", typeof(uint), true).Out(out var count)
            };

            var structs = new List<MhwMultiStructData.StructData> {
                new MhwMultiStructData.StructData("Monster Stamina (1)", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry("Magic 1", typeof(uint), true),
                    new MhwMultiStructData.Entry("Magic 2", typeof(uint), true),
                    new MhwMultiStructData.Entry("Monster Id", typeof(uint), true, dataSourceType: DataSourceType.Monsters),
                    new MhwMultiStructData.Entry("Magic 3", typeof(uint), true)
                }, 1),

                new MhwMultiStructData.StructData("Fatigue (LR)", fatigue, 1),
                new MhwMultiStructData.StructData("Stamina Count (LR)", staminaCount, 1, true).Out(out var lrHolder),
                new MhwMultiStructData.StructData("Stamina (LR)", stamina, canAddRows: true, _010Link: new MhwMultiStructData.ArrayLink(lrHolder, count)),

                new MhwMultiStructData.StructData("Fatigue (HR)", fatigue, 1),
                new MhwMultiStructData.StructData("Stamina Count (HR)", staminaCount, 1, true).Out(out var hrHolder),
                new MhwMultiStructData.StructData("Stamina (HR)", stamina, canAddRows: true, _010Link: new MhwMultiStructData.ArrayLink(hrHolder, count)),

                new MhwMultiStructData.StructData("Fatigue (MR)", fatigue, 1),
                new MhwMultiStructData.StructData("Stamina Count (MR)", staminaCount, 1, true).Out(out var mrHolder),
                new MhwMultiStructData.StructData("Stamina (MR)", stamina, canAddRows: true, _010Link: new MhwMultiStructData.ArrayLink(mrHolder, count)),

                new MhwMultiStructData.StructData("Monster Stamina (2)", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry("Fatigue Speed", typeof(float))
                }, 1)
            };

            return new MultiStruct("Monsters", "MonsterStamina", new MhwMultiStructData(structs, "dtt_sta"));
        }
    }
}