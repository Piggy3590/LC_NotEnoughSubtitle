using BepInEx;
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
        private static int speakerNum;
        private static bool isRareDialogue;
        private static bool isDialogueRerolled;
        public static bool canBeHeard;

        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        private static void Update_PreFix()
        {
            if (speakTimer < 100) { speakTimer += Time.deltaTime; }

            if (canBeHeard)
            {
                if (speakerNum == 0 && speakTimer > 1f && speakTimer < 2f && !isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "귀하의 노력이 회사를 행복하게 만듭니다.";
                    Plugin.mls.LogInfo("Played 1!!!!");
                }

                if (speakerNum == 1 && speakTimer > 1f && speakTimer < 2f && !isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "우리는 여러분의 헌신을 소중하게 생각합니다.";
                    Plugin.mls.LogInfo("Played 2!!!!");
                }

                if (speakerNum == 2 && speakTimer > 1f && speakTimer < 2f && !isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "여러분의 수고는 회사에 매우 중요합니다.";
                    Plugin.mls.LogInfo("Played 3!!!!");
                }

                if (speakerNum == 3 && speakTimer > 1f && speakTimer < 2f && !isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "여러분의 정직한 업무는 회사의 귀중한 자산입니다.";
                    Plugin.mls.LogInfo("Played 4!!!!");
                }

                if (speakerNum == 4 && speakTimer > 1f && speakTimer < 2f && !isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "여러분은 진정한 전문가입니다.";
                    Plugin.mls.LogInfo("Played 5!!!!");
                }



                if (speakerNum == 0 && speakTimer > 1f && speakTimer < 2f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "와.";
                    Plugin.mls.LogInfo("Played 1!!!!");
                }

                if (speakerNum == 1 && speakTimer > 1f && speakTimer < 2f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "이 벽은 그것을 격리할 수 없-";
                    Plugin.mls.LogInfo("Played 2!!!!");
                }
                if (speakerNum == 1 && speakTimer > 5.5f && speakTimer < 6f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "격ㄹ ㅣ"; }

                if (speakerNum == 2 && speakTimer > 1f && speakTimer < 2f && isRareDialogue)
                {
                    HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "와.";
                    Plugin.mls.LogInfo("Played 3!!!!");
                }

                if (speakerNum == 3 && speakTimer > 1f && speakTimer < 2f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "회사는 항상 행복해야 합니다.";
                    Plugin.mls.LogInfo("Played 4!!!!");
                }
                if (speakerNum == 3 && speakTimer > 2f && speakTimer < 3f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "호ㅣ사는 항ㅅㅏㅇ"; }


                if (speakerNum == 4 && speakTimer > 1f && speakTimer < 2f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "우리는 당신이 필요합니다.";
                    Plugin.mls.LogInfo("Played 5!!!!");
                }
                if (speakerNum == 5 && speakTimer > 2f && speakTimer < 3f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "이이이이이이-"; }


                if (speakerNum == 6 && speakTimer > 1f && speakTimer < 2f && isRareDialogue)
                { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>???:</color> " + "계속해서 우리 투자자들의 만족도를 유지하세요.";
                }
            }

            if (speakTimer > 6f && speakTimer < 8f)
            { HUDManagerPatch.RsubtitleGUItext.text = "";
                isDialogueRerolled = false;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("MicrophoneSpeak")]
        public static bool MicrophoneSpeak_Prefix(ref AudioSource ___speakerAudio, ref AudioClip[] ___rareMicrophoneAudios, ref AudioClip[] ___microphoneAudios, ref System.Random ___CompanyLevelRandom)
        {
            speakTimer = 1f;
            if (!isDialogueRerolled)
            {
                isDialogueRerolled = true;
                if (___CompanyLevelRandom.NextDouble() < 0.029999999329447746)
                {
                    speakerNum = ___CompanyLevelRandom.Next(0, ___rareMicrophoneAudios.Length);
                    audioClip = ___rareMicrophoneAudios[speakerNum];
                    isRareDialogue = true;
                }
                else
                {
                    speakerNum = ___CompanyLevelRandom.Next(0, ___microphoneAudios.Length);
                    audioClip = ___microphoneAudios[speakerNum];
                    isRareDialogue = false;
                }
                Plugin.mls.LogInfo("TESBNFHIUJDBNFIHNSGVSJDNV: " + speakerNum);
                ___speakerAudio.PlayOneShot(audioClip, 1f);
            }
            return false;
        }
    }
}
