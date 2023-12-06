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
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {
        private static TextMeshProUGUI textComponent;
        public static TextMeshProUGUI RsubtitleGUItext;

        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        private static void Awake_Postfix(ref HUDManager __instance)
        {
            GameObject testSubtitlesGUI = new("testSubtitlesGUI");
            testSubtitlesGUI.AddComponent<RectTransform>();
            TextMeshProUGUI textComponent = testSubtitlesGUI.AddComponent<TextMeshProUGUI>();

            RectTransform rectTransform = textComponent.rectTransform;
            rectTransform.SetParent(GameObject.Find("Systems/UI/Canvas/Panel/GameObject/PlayerScreen").transform, false);
            rectTransform.sizeDelta = new Vector2(600, 200);
            rectTransform.anchoredPosition = new Vector2(0, -125);

            textComponent.alignment = TextAlignmentOptions.Center;
            textComponent.font = __instance.controlTipLines[0].font;
            textComponent.fontSize = 20f;

            RsubtitleGUItext = textComponent;
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void Update_Postfix()
        {
            if (RsubtitleGUItext == textComponent)
            {
                RsubtitleGUItext.text = "Testing";
            }
        }
    }
}
