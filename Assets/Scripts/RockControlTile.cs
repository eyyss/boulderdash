using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RockControlTile : MonoBehaviour
{
    public bool hitFrame;
    public bool hitGrass;
    public bool hitPlayer;
    public bool hitRock;

    private SpriteRenderer sp;

    public Color colorRed = Color.red;
    public Color colorGreen = Color.green;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

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
        if (collision.TryGetComponent(out TilemapCollider2D tC))
        {
            if (tC == GameManager.Instance.frameTilemapCollider)
            {
                hitFrame = true;
                sp.color = colorRed;
            }
            if (tC == GameManager.Instance.grassTilemapCollider)
            {
                hitGrass = true;
                sp.color = colorRed;
            }
        }
        if (collision.CompareTag("Player"))
        {
            hitPlayer = true;
            sp.color = colorRed;
        }
        if (collision.TryGetComponent(out Rock rock))
        {
            hitRock = true;
            sp.color = colorRed;
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
            }
            if (tC == GameManager.Instance.grassTilemapCollider)
            {
                hitGrass = false;
                sp.color = colorGreen;
            }
        }
        if (collision.CompareTag("Player"))
        {
            hitPlayer = false;
            sp.color = colorGreen;
        }
        if (collision.TryGetComponent(out Rock rock))
        {
            hitRock = false;
            sp.color = colorGreen;
        }
    }
}
