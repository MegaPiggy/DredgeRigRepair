using HarmonyLib;
using Winch.Core;

namespace RigRepair
{
	[HarmonyPatch(typeof(TIRPhaseStateChanger))]
	public static class TIRPhaseStateChangerPatcher
	{
		[HarmonyPrefix]
		[HarmonyPatch(nameof(TIRPhaseStateChanger.Phase6))]
		public static bool Phase6(TIRPhaseStateChanger __instance)
		{
			WinchCore.Log.Debug("[TIRPhaseStateChanger] Phase6()");
			__instance.SetDrillUp();
			__instance.SetCrackMaterials(6);
			__instance.SetRigState(false);
			return false;
		}

		public static void SetRigState(this TIRPhaseStateChanger tIRPhaseStateChanger, bool broken)
		{
			tIRPhaseStateChanger.rigBaseBroken.SetActive(value: broken);
			tIRPhaseStateChanger.rigBaseRegular.SetActive(value: !broken);
		}
	}
}
