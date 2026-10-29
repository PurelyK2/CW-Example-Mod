global using Random = UnityEngine.Random;
global using static CWExampleMod.Plugin;

using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace CWExampleMod;

// Settings Menu Adjustments (For Modded Settings)

[BepInPlugin("Purely_K2.CursedExample", "Cursed Words Example Mod", "0.1.0")]
[BepInDependency("Purely_K2.CursedAPI")]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance;
    public static ManualLogSource Log => Instance.Logger;

    void Awake()
    {
        Instance = this;

        Log.LogInfo("Starting API");

        var harmony = new Harmony("Purely_K2.CursedAPI");

        try
        {
            harmony.PatchAll();
        }
        catch (System.Exception e)
        {
            Log.LogError(e);
        }
    }
}