using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace ModuleDeconstruct
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            Log($"{MyPluginInfo.PLUGIN_NAME} loaded");
        }

        public void Log(string message)
        {
            base.Logger.LogInfo(message);
        }
    }
}
