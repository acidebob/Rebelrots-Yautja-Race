﻿using RimWorld;
using Verse;
using Harmony;
using System.Reflection;
using System.Collections.Generic;
using System;
using Verse.AI;

namespace RRYautja
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            var harmony = HarmonyInstance.Create("com.ogliss.rimworld.mod.rryatuja");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
        

    }

    [HarmonyPatch(typeof(Pawn), "ThreatDisabled")]
    public static class Pawn_ThreatDisabledPatch
    {
        [HarmonyPostfix]
        public static void IgnoreCloak(Pawn __instance, ref bool __result, IAttackTargetSearcher disabledFor)
        {
            bool selected__instance = Find.Selector.SelectedObjects.Contains(__instance);
            Comp_Xenomorph _Xenomorph = null;
            if (disabledFor != null)
            {
                if (disabledFor.Thing != null)
                {
                    _Xenomorph = disabledFor.Thing.TryGetComp<Comp_Xenomorph>();
                    if (_Xenomorph != null)
                    {
                    }
                }
            }
            if (__instance != null)
            {
                if (__instance != null)
                {
                }
            } // XenomorphDefOf.RRY_Hediff_Xenomorph_Hidden
            __result = __result || ((__instance.health.hediffSet.HasHediff(YautjaDefOf.RRY_Hediff_Cloaked)|| __instance.health.hediffSet.HasHediff(XenomorphDefOf.RRY_Hediff_Xenomorph_Hidden)) && _Xenomorph == null);

        }
    }

    [HarmonyPatch(typeof(Building_Turret_Shoulder), "ThreatDisabled")]
    public static class Building_Turret_Shoulder_ThreatDisabledPatch
    {
        [HarmonyPostfix]
        public static void IgnoreShoulderTurret(Building_Turret_Shoulder __instance, ref bool __result, IAttackTargetSearcher disabledFor)
        {
            bool selected__instance = Find.Selector.SelectedObjects.Contains(__instance);
            bool shouldturret = false;
            if (__instance != null)
            {
                if (__instance is Building_Turret_Shoulder)
                {
                    shouldturret = true;
                }
            }
            __result = (__result || shouldturret);

        }
    }

    [HarmonyPatch(typeof(Apparel), "GetWornGizmos")]
    public static class Ogliss_RimWorld_Apparel_GetWornGizmos
    {
        [HarmonyPostfix]
        public static void ApparelGizmosFromComps(Apparel __instance, ref IEnumerable<Gizmo> __result)
        {
            if (__instance == null)
            {
                Log.Warning("ApparelGizmosFromComps cannot access Apparel.");
                return;
            }
            if (__result == null)
            {
                Log.Warning("ApparelGizmosFromComps creating new list.");
                return;
            }

            // Find all comps on the apparel. If any have gizmos, add them to the result returned from apparel already (typically empty set).
            List<Gizmo> l = new List<Gizmo>(__result);
            foreach (CompWearable comp in __instance.GetComps<CompWearable>())
            {
                foreach (Gizmo gizmo in comp.CompGetGizmosWorn())
                {
                    l.Add(gizmo);
                }
            }
            __result = l;
        }
    }



    [HarmonyPatch(typeof(Cloakgen), "GetWornGizmos")]
    public static class Ogliss_RimWorld_Cloakgen_GetWornGizmos
    {
        [HarmonyPostfix]
        public static void ApparelGizmosFromComps(Cloakgen __instance, ref IEnumerable<Gizmo> __result)
        {
            if (__instance == null)
            {
                Log.Warning("ApparelGizmosFromComps cannot access Apparel.");
                return;
            }
            if (__result == null)
            {
                Log.Warning("ApparelGizmosFromComps creating new list.");
                return;
            }

            // Find all comps on the apparel. If any have gizmos, add them to the result returned from apparel already (typically empty set).
            List<Gizmo> l2 = new List<Gizmo>(__result);
            foreach (CompWearable comp in __instance.GetComps<CompWearable>())
            {
                foreach (Gizmo gizmo in comp.CompGetGizmosWorn())
                {
                    l2.Add(gizmo);
                }
            }
            __result = l2;
        }
    }

    public abstract class CompWearable : ThingComp
    {
        public virtual IEnumerable<Gizmo> CompGetGizmosWorn() {
            // return no Gizmos
            return new List<Gizmo>();
        }
    }
    /*
   [HarmonyPatch(typeof(Pawn), "CheckAcceptArrest")]
   public static class Pawn_AcceptArrestPatch
   {
       [HarmonyPrefix]
       public static bool RevealSaboteur(Pawn __instance, Pawn arrester)
       {
           if (__instance.health.hediffSet.HasHediff(HediffDefOfIncidents.Saboteur))
           {
               __instance.health.hediffSet.hediffs.RemoveAll(h => h.def == HediffDefOfIncidents.Saboteur);
               Faction faction = Find.FactionManager.RandomEnemyFaction();
               __instance.SetFaction(faction);
               List<Pawn> thisPawn = new List<Pawn>();
               thisPawn.Add(__instance);
               IncidentParms parms = new IncidentParms();
               parms.faction = faction;
               parms.spawnCenter = __instance.Position;
               parms.raidStrategy = RaidStrategyDefOf.ImmediateAttack;
               parms.raidStrategy.Worker.MakeLords(parms, thisPawn);
               __instance.Map.avoidGrid.Regenerate();
               LessonAutoActivator.TeachOpportunity(ConceptDefOf.EquippingWeapons, OpportunityType.Critical);
               if (faction != null)
               {
                   Find.LetterStack.ReceiveLetter("LetterLabelSabotage".Translate(), "SaboteurRevealedFaction".Translate(__instance.LabelShort, faction.Name, __instance.Named("PAWN")), LetterDefOf.ThreatBig, __instance, null);
               }
               else
               {
                   Find.LetterStack.ReceiveLetter("LetterLabelSabotage".Translate(), "SaboteurRevealed".Translate(__instance.LabelShort, __instance.Named("PAWN")), LetterDefOf.ThreatBig, __instance, null);
               }
           }
           return true;
       }
   }
   */
}