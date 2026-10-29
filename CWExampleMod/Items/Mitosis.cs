using CWAPI.Items;
using CWAPI.Utilities;
using CWExampleMod.Tiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWExampleMod.Items;

public class Mitosis : ModdedItem
{
    public Mitosis()
    {
        Name = "Mitosis";
        UpgradeableComponents = new List<UpgradeableComponent>()
        {
            new UpgradeableComponent(1,2,5),
            new UpgradeableComponent(1,1,1)
        };
    }
    public override string SpritePath => "CWExampleMod.Resources.Blob.png";

    public override string GetDescription()
    {
        return "THE BLOBS SHALL RULE THE WORLD!!!";
    }
    
    public override GridData ApplyStartOfGridEffect(GridData gridData, int gridNumber, int numberOfGrids, List<HistoricWord> previousWords, List<BoardGenVizInfo> vizSteps, bool isReroll)
    {
        List<Tile> blobTiles = new List<Tile>();
        for(int i = 0; i < UpgradeableComponents[0].VariableValue; i++)
        {
            Tile randTile = GridUtility.Singleton.GetTileForItemScatter(gridData, TileUtils.GetTileType<BlobTile>(), GlyphType.None);
            randTile.SetTileType(TileUtils.GetTileType<BlobTile>());
            blobTiles.Add(randTile);
        }

        if (blobTiles.Count > 0)
        {
            vizSteps.Add(new BoardGenVizInfo(gridData, this, blobTiles, false, null, false, false, false, vizSteps[vizSteps.Count - 1].PlayerConsumableTiles));
        }

        return gridData;
    }
}