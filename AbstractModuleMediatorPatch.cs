using CG.Client.Ship.Modules.Mediators;
using CG.Ship.Modules;
using HarmonyLib;
using Photon.Pun;
using System.Reflection;

namespace ModuleDeconstruct
{
    [HarmonyPatch]
    internal class AbstractModuleMediatorPatch
    {
        static MethodBase TargetMethod()
        {
            return typeof(AbstractModuleMediator<CellModule>).GetMethod("InitializeDeconstructButton", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        static void Prefix(AbstractModuleMediator<CellModule> __instance)
        {
            if (__instance.Module?.BuildingConstraints?.allowDeconstruction == false && PhotonNetwork.IsMasterClient)
            {
                __instance.Module.BuildingConstraints.allowDeconstruction = true;
            }
        }
    }
}
