using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Rock : MonoBehaviour
{
    public RockControlTile leftTile, rightTile, upTile, downTile,leftDownTile,rightDownTile;


    private Vector3 velocity;

    public float downTime;
    private float timer;

    public int downSpeed;



    private void Start()
    {
        Tilemap tileMap = GameManager.Instance.grassTilemap;
        Vector3Int targetCellPosition = tileMap.WorldToCell(transform.position);
        if (tileMap.HasTile(targetCellPosition))
        {
            tileMap.SetTile(targetCellPosition, null);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        PlayerIsHit();


        if (downTile.hitPlayer)
        {
            timer = 0;
        }

        // assa
        if (!downTile.hitRock && !downTile.hitFrame && !downTile.hitGrass && !downTile.hitPlayer && timer >= downTime)
        {
            timer = 0;
            velocity = Vector2.down;
            transform.position += velocity;
            downSpeed++;

        }
        else if (timer >= downTime)
        {
            if (downSpeed>0)
            {
                downSpeed--;
            }
        }



        if (!leftTile.hitRock && !leftTile.hitFrame && !leftTile.hitGrass && !leftTile.hitPlayer && timer > downTime)
        {
            if (!leftDownTile.hitRock && !leftDownTile.hitFrame && !leftDownTile.hitGrass && !leftDownTile.hitPlayer && timer > downTime)
            {
                if (!downTile.hitGrass && !downTile.hitPlayer)
                {
                    timer = 0;
                    velocity = Vector2.left;
                    transform.position += velocity;
                }
            }
        }

        if (!rightTile.hitRock && !rightTile.hitFrame && !rightTile.hitGrass && !rightTile.hitPlayer && timer > downTime)
        {
            if (!rightDownTile.hitRock && !rightDownTile.hitFrame && !rightDownTile.hitGrass && !rightDownTile.hitPlayer && timer > downTime)
            {
                if (!downTile.hitGrass && !downTile.hitPlayer)
                {
                    timer = 0;
                    velocity = Vector2.right;
                    transform.position += velocity;
                }
            }
        }

    }

    private void PlayerIsHit()
    {
        if (downSpeed>0 && downTile.hitPlayer)
        {
            if (!Player.Instance.dead)
            {
                Player.Instance.Dead();
            }
        }
    }

    public void Move(float x)
    {
        if (x<0)
        {
            if (!leftTile.hitFrame && !leftTile.hitGrass && !leftTile.hitPlayer && !leftTile.hitRock)
            {
                velocity = Vector2.left;
                transform.position += velocity;
            }
        }
        if (x>0)
        {
            if (!rightTile.hitFrame && !rightTile.hitGrass && !rightTile.hitPlayer && !rightTile.hitRock)
            {
                velocity = Vector2.right;
                transform.position += velocity;
            }
        }
    }


}
