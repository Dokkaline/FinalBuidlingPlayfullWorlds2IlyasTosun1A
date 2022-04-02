using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnButton : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }



}
