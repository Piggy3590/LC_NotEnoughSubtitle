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
    public class SubtitleModBase : BaseUnityPlugin
    {
        private const string modGUID = "Piggy3590.NotEnoughSubtitle";
        private const string modName = "Not Enough Subtitle";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static SubtitleModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Not Enough Subtitle is loaded");

            harmony.PatchAll(typeof(SubtitleModBase));
            harmony.PatchAll(typeof(HUDManagerPatch));
            harmony.PatchAll(typeof(StartOfRoundPatch));
        }


    }
}
