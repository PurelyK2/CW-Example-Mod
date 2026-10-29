using CWAPI.Characters;
using CWAPI.Utilities;
using CWExampleMod.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CWExampleMod.Characters;

public class Blob : ModdedCharacter
{
    public Blob() : base("Blob", "BLOB", "BLOB", new Mitosis(), null, new Color32(34, 100, 221, 255), new Color32(34, 221, 0, 255), new Vector3(20f, 150f, 0f), new Vector3(-50f, 150f, 0f), new List<Type>(), Emotions.CactusCharacter, true, "Blobity Blob Blob")
    {
    }

    public override bool CheckUnlocked()
    {
        return ItemUtils.ModdedItems.FirstOrDefault(item => item.GetType() == typeof(Mitosis))?.IsUnlocked == true;
    }
}
