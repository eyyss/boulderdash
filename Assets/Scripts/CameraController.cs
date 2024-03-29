using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player player;

    public Vector3 firstPosition;
    public CinemachineVirtualCamera cam1, cam2;

    private bool start;
    private IEnumerator Start()
    {
        player = Player.Instance;
        cam2.Priority = 1;

        yield return new WaitForSeconds(3f);
        start = true;
    }

    private void Update()
    {
        //if (!start) { return; } // açarsak oyun baþýnda kamera sagda biraz bekleyip sola kayýyor

        if (player == null) return;
        if(player.transform.position.x < firstPosition.x)
        {
            //ilk camera acýk
            cam1.Priority = 1;
            cam2.Priority = 0;
        }
        if (player.transform.position.x > firstPosition.x)
        {
            //2.
            cam1.Priority = 0;
            cam2.Priority = 1;
        }
    }
}
