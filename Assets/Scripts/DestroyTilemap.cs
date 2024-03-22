using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DestroyTilemap : MonoBehaviour
    
{
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tilemap.GetTile(Vector3Int.FloorToInt(transform.position)) != null) ;
        {
            Vector3Int targetCellPosition = tilemap.WorldToCell(transform.position);
            if (tilemap.HasTile(targetCellPosition))
            {
                // Erase the tile at the target position
                Debug.Log("test");
                tilemap.SetTile(targetCellPosition, null);
            }
        }
        
    }
    
}
