﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x0200021E RID: 542
    public class ThoughtWorker_MutliHediff : ThoughtWorker
    {
        int stageIndex = 0;
        // Token: 0x06000A30 RID: 2608 RVA: 0x0004FE58 File Offset: 0x0004E258
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {

            if (p.kindDef.race!=YautjaDefOf.Alien_Yautja)
            {
                return ThoughtState.Inactive;
            }
            if (p.health.hediffSet.hediffs!=null)
            {
                List<HediffDef> list = p.GetComp<RRYautja.Comp_Yautja>().Props.bloodedDefs;
                foreach (var hd in p.health.hediffSet.hediffs)
                {
                    if (hd.def.defName.Contains("RRY_Hediff_BloodedM"))
                    {
                        hediffDef = hd.def;
                    }
                }
                for (int i = 1; i < list.Count; i++)
                {

                    def.stages.Add(new ThoughtStage
                    {
                        baseMoodEffect = def.stages[0].baseMoodEffect + (1 + i),
                        description = string.Format("{0}{1}{2}", desc1, list[i].stages[0].label, desc2),
                        label = string.Format("{0} {1}", list[i].stages[0].label, def.stages[0].label)
                    });
                }
                stageIndex = list.IndexOf(hediffDef);
            }
            Hediff firstHediffOfDef = p.health.hediffSet.GetFirstHediffOfDef(hediffDef, false);
            if (firstHediffOfDef == null || firstHediffOfDef.def.stages == null)
            {
                return ThoughtState.Inactive;
            }
            return ThoughtState.ActiveAtStage(stageIndex);
        }


        public ThoughtState thoughtState;
        // Token: 0x040003FA RID: 1018

        HediffDef hediffDef;

        String desc1 = string.Format("I've proven myself by killing a ");

        String desc2 = string.Format(" and marked myself with its blood. I feel amazing.");
       
    }
}