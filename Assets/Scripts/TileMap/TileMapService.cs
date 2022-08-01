using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapService : MonoBehaviour
{
    
    public Tilemap Map;
    public TileMapService(Tilemap map) => Map = map;
    
    public TileBase GetCell(Vector3 position)
    {
        return Map.GetTile(Vector3Int.FloorToInt(position));
    }

    public List<Vector3> GetAroundEmptyWithFilter(List<TileBase> filter, Vector3 position)
    {
        var pos = Vector3Int.FloorToInt(position);
        var outputCoordinate = new List<Vector3>();
        Vector3Int[] aroundMatrix =
        {
            new Vector3Int(pos.x,pos.y+1,0),
            new Vector3Int(pos.x-1,pos.y,0),new Vector3Int(pos.x+1,pos.y,0),
            new Vector3Int(pos.x,pos.y-1,0)
        };
        foreach (var item in aroundMatrix)
        {
            var tile = Map.GetTile(item);
            if (filter.Contains(tile) || tile == null)
            {
                outputCoordinate.Add(item);
            }
        }
        return outputCoordinate;
    }
}