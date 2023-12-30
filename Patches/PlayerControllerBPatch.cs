using BepInEx.Logging;
using DunGen;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace NotEnoughSubtitle.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void Update_Postfix(ref Transform ___thisPlayerBody, ref bool ___isCameraDisabled)
        {
            if (___isCameraDisabled) { return; }
            if (GameObject.Find("SpeakerBox") != null)
            {
                if (Vector3.Distance(___thisPlayerBody.position, GameObject.Find("SpeakerBox").transform.position) <= 20)
                {
                    DepositItemsDeskPatch.canBeHeard = true;
                }else
                {
                    DepositItemsDeskPatch.canBeHeard = false;
                }
            }
        }
    }
}