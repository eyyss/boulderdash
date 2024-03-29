using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DestroyTilemap : MonoBehaviour  
{
    private GridMovement gridMovement;
    private Tilemap grassTileMap;

    public ControlTile leftTile, rightTile, upTile, downTile;

    private void Awake()
    {
        gridMovement = GetComponent<GridMovement>();
        

    }
    private void Start()
    {
        grassTileMap = GameManager.Instance.grassTilemap;
    }
    // Update is called once per frame
    void Update()
    {
        if (grassTileMap.GetTile(Vector3Int.FloorToInt(transform.position)) != null)
        {
            Vector3Int targetCellPosition = grassTileMap.WorldToCell(transform.position);
            if (grassTileMap.HasTile(targetCellPosition))
            {
                Debug.Log("Tile Silindi");
                grassTileMap.SetTile(targetCellPosition, null);
            }
        }


        PlayerDestroyTile();
    }
    private void PlayerDestroyTile()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            gridMovement.enabled = false;
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x == -1 && leftTile.hitGrass)
            {
                Vector3Int targetCellPosition = grassTileMap.WorldToCell(leftTile.transform.position);
                if (grassTileMap.HasTile(targetCellPosition))
                {
                    Debug.Log("Left Tile Silindi");
                    grassTileMap.SetTile(targetCellPosition, null);
                }
            }

            if (x == 1 && rightTile.hitGrass)
            {
                Vector3Int targetCellPosition = grassTileMap.WorldToCell(rightTile.transform.position);
                if (grassTileMap.HasTile(targetCellPosition))
                {
                    Debug.Log("Right Tile Silindi");
                    grassTileMap.SetTile(targetCellPosition, null);
                }
            }

            if (y == 1 && upTile.hitGrass)
            {
                Vector3Int targetCellPosition = grassTileMap.WorldToCell(upTile.transform.position);
                if (grassTileMap.HasTile(targetCellPosition))
                {
                    Debug.Log("Up Tile Silindi");
                    grassTileMap.SetTile(targetCellPosition, null);
                }
            }

            if (y == -1 && downTile.hitGrass)
            {
                Vector3Int targetCellPosition = grassTileMap.WorldToCell(downTile.transform.position);
                if (grassTileMap.HasTile(targetCellPosition))
                {
                    Debug.Log("Down Tile Silindi");
                    grassTileMap.SetTile(targetCellPosition, null);
                }
            }
        }
        else
        {
            gridMovement.enabled = true;
        }

    }


    
}
