using BepInEx.Logging;
using DunGen;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace NotEnoughSubtitle.Patches
{
    [HarmonyPatch(typeof(DepositItemsDesk))]
    [HarmonyPatch("MicrophoneSpeak")]
    internal class DepositItemsDeskPatch
    {
        public static float speakTimer = 20;
        public static AudioClip audioClip;
        [HarmonyPatch("Update")]
        private static void Update_Fix()
        {
            if (speakTimer < 100) { speakTimer += Time.deltaTime; }

            HUDManagerPatch.RsubtitleGUItext.text = audioClip.name + "/" + speakTimer;

            if (audioClip.name == "Mic1" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "Your work keeps The Company happy."; }

            if (audioClip.name == "Mic2" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "We value your commitment."; }

            if (audioClip.name == "Mic3" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "We need you."; }
            if (audioClip.name == "Mic3" && speakTimer > 2f && speakTimer < 3f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "eeeeeeeee"; }

            if (audioClip.name == "Mic4" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "Your handwork is invaluable to the company. "; }

            if (audioClip.name == "Mic6" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "Wa."; }

            if (audioClip.name == "Mic7" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "The Company must stay happy."; }
            if (audioClip.name == "Mic7" && speakTimer > 2f && speakTimer < 3f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "eetche compny muast"; }

            if (audioClip.name == "Mic8" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "this wall cannot contain it-"; }
            if (audioClip.name == "Mic8" && speakTimer > 2f && speakTimer < 3f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "ccontai n"; }

            if (audioClip.name == "Mic9" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "Your honest work is invaluable to the Company."; }

            if (audioClip.name == "Mic10" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "You are true professionals."; }

            if (audioClip.name == "Mic11" && speakTimer > 1f && speakTimer < 2f)
            { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>???:</color> " + "Keep our investors happy."; }

            if (speakTimer > 4f && speakTimer < 6f)
            { HUDManagerPatch.RsubtitleGUItext.text = ""; }
        }

        [HarmonyPrefix]
        public static bool MicrophoneSpeak_Prefix(ref AudioSource ___speakerAudio, ref AudioClip[] ___rareMicrophoneAudios, ref AudioClip[] ___microphoneAudios, ref System.Random ___CompanyLevelRandom)
        {
            speakTimer = 0f;
            if (___CompanyLevelRandom.NextDouble() < 0.029999999329447746)
            {
                audioClip = ___rareMicrophoneAudios[___CompanyLevelRandom.Next(0, ___rareMicrophoneAudios.Length)];
            }
            else
            {
                audioClip = ___microphoneAudios[___CompanyLevelRandom.Next(0, ___microphoneAudios.Length)];
            }
            ___speakerAudio.PlayOneShot(audioClip, 1f);
            return false;
        }
    }
}
