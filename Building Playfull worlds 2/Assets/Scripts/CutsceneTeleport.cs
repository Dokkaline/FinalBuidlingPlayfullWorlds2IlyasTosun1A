using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTeleport : MonoBehaviour
{
    [SerializeField]public Transform Player;

    void Update()
    {
        Player.position = transform.position;
    }
}
