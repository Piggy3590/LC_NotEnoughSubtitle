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
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        public static float introTimer = 5000;
        public static float firedTimer = 5000;
        public static float zeroDayTimer = 5000;
        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        private static void Awake_Postfix()
        {
            introTimer = 5000;
            firedTimer = 5000;
            zeroDayTimer = 5000;
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void Update_Postfix()
        {
            if (introTimer < 5000) { introTimer += Time.deltaTime; }
            if (firedTimer < 5000) { firedTimer += Time.deltaTime; }
            if (zeroDayTimer < 5000) { zeroDayTimer += Time.deltaTime; }

            if (introTimer > 7f && introTimer < 7.3f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "당신의 첫 근무일에 오신 것을 환영합니다."; }
            if (introTimer > 10.1f && introTimer < 10.4f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "이곳은 계약 기간 동안 여러분의 의식주가 이루어지는,"; }
            if (introTimer > 12.5f && introTimer < 13f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "당신만의 자동 조종 함선입니다."; }
            if (introTimer > 15.3f && introTimer < 15.5f) { HUDManagerPatch.RsubtitleGUItext.text = "(알아들을 수 없는 말)"; }
            if (introTimer > 20 && introTimer < 20.3) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "이곳을 집처럼 여기시길 바랍니다."; }
            if (introTimer > 21.7 && introTimer < 22) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "탑승 절차를 완료하셨다면 지침서를 확인하신 후" + "\n" + "함선의 컴퓨터 단말기에 로그인하시기 바랍니다."; }
            if (introTimer > 28.3 && introTimer < 29) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "우리는 여러분이 회사의 큰 자산이 될 것이라고 믿습니다."; }
            if (introTimer > 31 && introTimer < 32) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "회사의 큰 큰 자산 회사의 큰 큰 자산..."; }
            if (introTimer > 37 && introTimer < 38) { HUDManagerPatch.RsubtitleGUItext.text = ""; }

            if (firedTimer > 0.15f && firedTimer < 1f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>컴퓨터 파일럿:</color> " + "여러분들은 수익 할당량을 충족하지 못했습니다."; }
            if (firedTimer > 2.2f && firedTimer < 2.5f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>컴퓨터 파일럿:</color> " + "따라서 여러분들의 성과는 기준 미달로 평가되었습니다."; }
            if (firedTimer > 5.5f && firedTimer < 6f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#F15F5F>컴퓨터 파일럿:</color> " + "우리의 징계 절차에 오신 것을 환영합니다."; }
            if (firedTimer > 8f && firedTimer < 9f) { HUDManagerPatch.RsubtitleGUItext.text = ""; }

            if (zeroDayTimer > 5.25f && zeroDayTimer < 5.5f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "즉시 회사 건물로 이동하여 폐철물이나 기타 물건들을 판매하십시오."; }
            if (zeroDayTimer > 10f && zeroDayTimer < 11f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "수익 할당량을 충족시킬 수 있는 시간이 0일 남았습니다."; }
            if (zeroDayTimer > 13.4f && zeroDayTimer < 14f) { HUDManagerPatch.RsubtitleGUItext.text = "<color=#5CD1E5>컴퓨터 파일럿:</color> " + "터미널을 사용하여 함선을 회사 건물로 이동시킬 수 있습니다."; }
            if (zeroDayTimer > 17f && zeroDayTimer < 18f) { HUDManagerPatch.RsubtitleGUItext.text = ""; }
        }
        [HarmonyPostfix]
        [HarmonyPatch("playersFiredGameOver")]
        private static void playersFiredGameOver_Postfix()
        {
            firedTimer = -5f;
        }

        [HarmonyPostfix]
        [HarmonyPatch("playDaysLeftAlertSFXDelayed")]
        private static void playDaysLeftAlertSFXDelayed_Postfix()
        {
            zeroDayTimer = -3f;
        }

        [HarmonyPostfix]
        [HarmonyPatch("firstDayAnimation")]
        private static void firstDayAnimation_Postfix()
        {
            introTimer = -6f;
        }

        [HarmonyPostfix]
        [HarmonyPatch("DisableShipSpeakerLocalClient")]
        private static void DisableShipSpeakerLocalClient_Postfix()
        {
            introTimer = 5000f;
            firedTimer = 5000f;
            zeroDayTimer = 5000f;
            HUDManagerPatch.RsubtitleGUItext.text = "";
        }
    }
}
