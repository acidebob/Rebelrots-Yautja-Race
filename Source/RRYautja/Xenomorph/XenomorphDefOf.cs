﻿using System;
using Verse;

namespace RimWorld
{
	// Token: 0x02000956 RID: 2390
	[DefOf]
    public static class XenomorphDefOf
    {
        // Token: 0x06003781 RID: 14209 RVA: 0x001A8393 File Offset: 0x001A6793
        static XenomorphDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(XenomorphDefOf));
        }
        // Xenomorph DamageDefs 
        public static DamageDef RRY_AcidDamage;
        public static DamageDef RRY_AcidBurn;

        // Xenomorph DamageDefs Special
        public static DamageDef RRY_EmergingChestbursterDD;

        // Xenomorph HefiffDefs
        public static HediffDef RRY_FaceHuggerInfection;
        public static HediffDef RRY_XenomorphImpregnation;
        public static HediffDef RRY_HiddenXenomorphImpregnation;

        // Neomorph HefiffDefs
        public static HediffDef RRY_NeomorphImpregnation;
        public static HediffDef RRY_HiddenNeomorphImpregnation;

        // Xenomorph PawnKindDefs
        public static PawnKindDef RRY_Xenomorph_FaceHugger;
        public static PawnKindDef RRY_Xenomorph_Queen;
        public static PawnKindDef RRY_Xenomorph_Warrior;
        public static PawnKindDef RRY_Xenomorph_Drone;
        public static PawnKindDef RRY_Xenomorph_Runner;
        
        // Neomorph PawnKindDefs
        public static PawnKindDef RRY_Xenomorph_Neomorph;

        // Xenomorph FactionDefs
        public static FactionDef RRY_Xenomorph;

        // Xenomorph JobDefs
        public static JobDef LayXenomorphEgg;
        public static JobDef XenomorphKidnap;

        // Xenomorph ThingDefs
        public static ThingDef RRY_EggXenomorphFertilized;

        // Xenomorph LifeStageDefs
     //   public static LifeStageDef RRY_EggXenomorphFertilized;
    }

    public static class XenomorphRacesDefOf
    {
        // Token: 0x06003781 RID: 14209 RVA: 0x001A8393 File Offset: 0x001A6793
        static XenomorphRacesDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(XenomorphRacesDefOf));
        }
        // Xenomorph ThingDefs Races
        public static ThingDef RRY_Xenomorph_FaceHugger;
        public static ThingDef RRY_Xenomorph_Queen;
        public static ThingDef RRY_Xenomorph_Warrior;
        public static ThingDef RRY_Xenomorph_Drone;
        public static ThingDef RRY_Xenomorph_Runner;

        // Neomorph ThingDefs Races
        public static ThingDef RRY_Xenomorph_Neomorph;
    }
}