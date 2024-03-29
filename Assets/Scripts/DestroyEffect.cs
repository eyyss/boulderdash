using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyEffect : MonoBehaviour
{
    public List<Transform> destroyTile;
    void Start()
    {
        Destroy(gameObject,0.5f);

        Tilemap tileMap = GameManager.Instance.grassTilemap;
        foreach (Transform t in destroyTile)
        {
            Vector3Int targetCellPosition = tileMap.WorldToCell(t.position);
            if (tileMap.HasTile(targetCellPosition))
            {
                tileMap.SetTile(targetCellPosition, null);
            }
        }

        var hits = Physics2D.BoxCastAll(transform.position, new Vector2(3, 3),0,Vector2.zero);
        foreach (var item in hits)
        {
            if(item.transform.TryGetComponent(out Rock rock))
            {
                Destroy(rock.gameObject);
            }
        }
    }


}
