using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Tilemap frameTilemap, grassTilemap;
    public TilemapCollider2D frameTilemapCollider;
    public TilemapCollider2D grassTilemapCollider;

    public bool test;

    public GameObject playerPrefab;
    public TextMeshProUGUI requiredDiamondText;

    public int requiredDiamondCount ;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        requiredDiamondCount = FindObjectsOfType<Diamond>().Length;
        requiredDiamondText.text = requiredDiamondCount.ToString();
    }
    public void RespawnPlayer()
    {
        StartCoroutine(e());
        IEnumerator e()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeDiamond()
    {
        requiredDiamondCount--;
        requiredDiamondText.text = requiredDiamondCount.ToString();
    }
}
