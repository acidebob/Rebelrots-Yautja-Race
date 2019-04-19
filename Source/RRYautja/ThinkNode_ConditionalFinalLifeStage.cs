﻿using System;
using Verse;
using Verse.AI;

namespace RimWorld
{
    // Token: 0x020001BE RID: 446
    public class ThinkNode_ConditionalFullyGrown : ThinkNode_Conditional
    {
        // Token: 0x06000956 RID: 2390 RVA: 0x0004D678 File Offset: 0x0004BA78
        protected override bool Satisfied(Pawn pawn)
        {
            LifeStageDef stage = pawn.ageTracker.CurLifeStage;
            if (pawn.kindDef!=XenomorphDefOf.RRY_Xenomorph_FaceHugger&&stage == pawn.RaceProps.lifeStageAges[pawn.RaceProps.lifeStageAges.Count - 1].def) Log.Message(string.Format("{0} CurLifeStage:{1} FinalLifeStage:{2}", pawn.Label, stage, pawn.RaceProps.lifeStageAges[pawn.RaceProps.lifeStageAges.Count - 1].def));
            return stage == pawn.RaceProps.lifeStageAges[pawn.RaceProps.lifeStageAges.Count - 1].def;
        }

    }

    public class ThinkNode_ConditionalNotGrown : ThinkNode_Conditional
    {
        // Token: 0x06000956 RID: 2390 RVA: 0x0004D678 File Offset: 0x0004BA78
        protected override bool Satisfied(Pawn pawn)
        {
            LifeStageDef stage = pawn.ageTracker.CurLifeStage;
        //    if (stage != pawn.RaceProps.lifeStageAges[pawn.RaceProps.lifeStageAges.Count - 1].def) Log.Message(string.Format("{0} CurLifeStage:{1} FinalLifeStage:{2}", pawn.Label, stage, pawn.RaceProps.lifeStageAges[pawn.RaceProps.lifeStageAges.Count - 1].def));
            return stage != pawn.RaceProps.lifeStageAges[pawn.RaceProps.lifeStageAges.Count - 1].def;
        }

    }
}
