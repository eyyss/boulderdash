using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ControlTile : MonoBehaviour
{
    public bool hitFrame;
    public bool hitGrass;
    public bool hitRock;
    public bool hitDiamond;

    public GameObject hitObject;

    private SpriteRenderer sp;

    public Color colorRed = Color.red;
    public Color colorGreen = Color.green;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

        sp.color = colorGreen;


    }
    private void Start()
    {
        if (!GameManager.Instance.test)
        {
            sp.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out TilemapCollider2D tC))
        {
            if(tC == GameManager.Instance.frameTilemapCollider)
            {
                hitFrame = true;
                sp.color = colorRed;
                hitObject = collision.gameObject;
            }
            if (tC == GameManager.Instance.grassTilemapCollider)
            {
                hitGrass = true;
                hitObject = collision.gameObject;
            }
        }
        if (collision.TryGetComponent(out Rock rock))
        {
            hitRock = true;
            sp.color = colorRed;
            hitObject = collision.gameObject;
        }

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TilemapCollider2D tC))
        {
            if (tC == GameManager.Instance.frameTilemapCollider)
            {
                hitFrame = false;
                sp.color = colorGreen;
                hitObject = null;
            }
            if (tC == GameManager.Instance.grassTilemapCollider)
            {
                hitGrass = false;
                hitObject = null;
            }
        }
        if (collision.TryGetComponent(out Rock rock))
        {
            hitRock = false;
            sp.color = colorGreen;
            hitObject = null;
        }

        
    }
}
