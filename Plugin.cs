using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using NotEnoughSubtitle.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEnoughSubtitle
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "Piggy3590.NotEnoughSubtitle";
        private const string modName = "Not Enough Subtitle";
        private const string modVersion = "1.0.2";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static Plugin Instance;

        public static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Not Enough Subtitle is loaded");

            harmony.PatchAll(typeof(Plugin));

            harmony.PatchAll(typeof(PlayerBody));
            harmony.PatchAll(typeof(HUDManagerPatch));
            harmony.PatchAll(typeof(StartOfRoundPatch));
            harmony.PatchAll(typeof(DepositItemsDeskPatch));

            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
