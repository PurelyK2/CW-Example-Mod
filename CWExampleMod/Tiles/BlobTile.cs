using CWAPI.Tiles;
using CWAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace CWExampleMod.Tiles;

public class BlobTile : ModdedTileType
{
    public override string TileName => "Blob Tile";
    public override (Color tile, Color word) textColor => new(Color.white, new Color32(34, 100, 221, 255));
    public override Color tileColor => new Color32(20, 75, 175, 255);
    public override bool pulses => false;
    public override bool isXenocolor => true;

    public override GridData ApplyStartOfGridEffect(GridData gridData, int gridNumber, int numberOfGrids, List<HistoricWord> previousWords, List<BoardGenVizInfo> vizSteps, bool isReroll)
    {
        bool isIterating = true;
        while(isIterating)
        {
            List<Tile> list = new List<Tile>();
            foreach(Tile tile in gridData.GridTiles.Where(t => t.MyTileType != TileUtils.GetTileType<BlobTile>() && !t.Gone))
            {
                if(GridUtility.Singleton.GetTilesAdjacentToCoordinates(gridData, tile.Coordinates, false).Count(t => t.MyTileType == TileUtils.GetTileType<BlobTile>()) > 3)
                {
                    tile.SetTileType(TileUtils.GetTileType<BlobTile>());
                    list.Add(tile);
                }
            }
            if(list.Count > 0)
            {
                vizSteps.Add(new BoardGenVizInfo(gridData, null, list, false, null, false, false, false, vizSteps[vizSteps.Count - 1].PlayerConsumableTiles));
            }
            else
            {
                isIterating = false;
            }
        }

        return gridData;
    }

    public override void ApplyTileBonus(ScoreCalcVizInfo step, int index, List<Tile> tiles, List<TileSelection> selections, List<HistoricWord> previousWords, GridData gridData)
    {
        if (tiles.Count == 0)
        {
            return;
        }
        
        List<ScorePacket> tileScores = step.TileScores;
        int blobCount = gridData.GridTiles.Count(t => t.MyTileType == TileUtils.GetTileType<BlobTile>());

        tileScores[index] *= blobCount;
        step.TileScoreMultipliers[index] = blobCount;
    }
}
