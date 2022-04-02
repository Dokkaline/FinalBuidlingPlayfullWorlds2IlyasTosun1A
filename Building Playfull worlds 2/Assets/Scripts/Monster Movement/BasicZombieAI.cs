using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombieAI : MonoBehaviour
{
    GameObject go_Player;

    NavMeshAgent na_NavMesh;

   [SerializeField] public GameObject VFX;
    void Start()
    {
        go_Player = GameObject.Find("RigidBodyFPSController");

        na_NavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (go_Player == null)
        {
            return;
        }

        na_NavMesh.destination = go_Player.transform.position;
    }

    private void OnEnable()
    {
        VFX.SetActive(true); 
    }

    private void OnDisable()
    {
        VFX.SetActive(false);
    }
}

