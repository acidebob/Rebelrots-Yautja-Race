﻿using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace RRYautja
{
    class XenomorphUtil
    {
        public static bool isInfectablePawn(Pawn pawn)
        {
            if (pawn.Dead) return false;
            if (pawn.RaceProps.IsMechanoid) return false;
            if (!pawn.RaceProps.IsFlesh) return false;
            if (IsInfectedPawn(pawn)) return false;
            if (IsXenomorph(pawn)) return false;
            if (IsXenomorphFaction(pawn)) return false;
            if (pawn.BodySize<0.7f) return false;
            return true;
        }
        public static bool isXenomorphInfectedPawn(Pawn pawn)
        {
            HediffSet hediffSet = pawn.health.hediffSet;
            if (hediffSet.HasHediff(XenomorphDefOf.RRY_FaceHuggerInfection, false)) return true;
            if (hediffSet.HasHediff(XenomorphDefOf.RRY_HiddenXenomorphImpregnation, false)) return true;
            if (hediffSet.HasHediff(XenomorphDefOf.RRY_XenomorphImpregnation, false)) return true;
            return false;
        }
        public static bool IsXenomorphPawn(Pawn pawn)
        {
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_FaceHugger) return true;
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Predalien) return true;
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Runner) return true;
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Drone) return true;
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Warrior) return true;
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Queen) return true;
            return false;
        }
        public static bool IsXenomorphCorpse(Corpse corpse)
        {
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_FaceHugger) return true;
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Predalien) return true;
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Runner) return true;
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Drone) return true;
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Warrior) return true;
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Queen) return true;
            return false;
        }
        public static bool isNeomorphInfectedPawn(Pawn pawn)
        {
            HediffSet hediffSet = pawn.health.hediffSet;
            if (hediffSet.HasHediff(XenomorphDefOf.RRY_HiddenNeomorphImpregnation, false)) return true;
            if (hediffSet.HasHediff(XenomorphDefOf.RRY_NeomorphImpregnation, false)) return true;
            return false;
        }
        public static bool IsNeomorphPawn(Pawn pawn)
        {
            if (pawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Neomorph) return true;
            return false;
        }

        public static bool IsNeomorphCorpse(Corpse corpse)
        {
            if (corpse.InnerPawn.kindDef == XenomorphDefOf.RRY_Xenomorph_Neomorph) return true;
            return false;
        }

        public static bool IsInfectedPawn(Pawn pawn)
        {
            if (isXenomorphInfectedPawn(pawn) || isNeomorphInfectedPawn(pawn)) return true;
            return false;
        }
        public static bool IsXenomorph(Pawn pawn)
        {
            if (IsXenomorphPawn(pawn) || IsNeomorphPawn(pawn)) return true;
            return false;
        }
        public static bool IsXenoCorpse(Corpse corpse)
        {
            if (IsXenomorphCorpse(corpse) || IsNeomorphCorpse(corpse)) return true;
            return false;
        }
        public static bool IsXenomorphFaction(Pawn pawn)
        {
            if (pawn.Faction == Find.FactionManager.FirstFactionOfDef(XenomorphDefOf.RRY_Xenomorph)) return true;
            return false;
        }
        public static bool QueenPresent(Map map, out Pawn Queen)
        {
            foreach (var p in map.mapPawns.AllPawnsSpawned)
            {
                if (p.kindDef == XenomorphDefOf.RRY_Xenomorph_Queen)
                {
                    Queen = p;
                    return true;
                }
            }
            Queen = null;
            return false;
        }
        public static bool EggsPresent(Map map)
        {
            return TotalSpawnedEggCount(map)>0;
        }
        public static Thing ClosestReachableEgg(Pawn pawn)
        {
            Thing thing = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForDef(XenomorphDefOf.RRY_EggXenomorphFertilized), PathEndMode.OnCell, TraverseParms.For(TraverseMode.NoPassClosedDoors, Danger.Deadly, false), 9999f, null, null, 0, -1, false, RegionType.Set_Passable, false);
            return null;
        }
        public static int TotalSpawnedEggCount(Map map)
        {
            return map.listerThings.ThingsOfDef(XenomorphDefOf.RRY_EggXenomorphFertilized).Count;
        }
        public static List<Thing> SpawnedEggs(Map map)
        {
            return map.listerThings.ThingsOfDef(XenomorphDefOf.RRY_EggXenomorphFertilized);
        }

        public static float DistanceBetween(IntVec3 a, IntVec3 b)
        {
            double distance = GetDistance(a.x, a.z, b.x, b.z);
            return (float)distance;
        }
        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
