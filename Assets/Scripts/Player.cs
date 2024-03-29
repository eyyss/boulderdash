using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private GridMovement gridMovement;

    public GameObject destroyEffectPrefab;

    public bool dead;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);

        gridMovement = GetComponent<GridMovement>();
    }

    public void Dead()
    {
        dead = true;

        var effect = Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effect,0.5f);

        GameManager.Instance.RespawnPlayer();
        Destroy(gameObject);


    }

    

}
