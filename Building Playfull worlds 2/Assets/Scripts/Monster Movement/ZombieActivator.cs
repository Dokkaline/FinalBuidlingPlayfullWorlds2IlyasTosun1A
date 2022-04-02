using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieActivator : MonoBehaviour
{
    GameObject go_Player;

    public float f_Range;

    [SerializeField] public bool DrawDebug;
    void Start()
    {
        go_Player = GameObject.Find("RigidBodyFPSController");
    }
    void Update()
    {
        if (Vector3.Distance(go_Player.transform.position, transform.position) <= f_Range)
        {
            GetComponent<BasicZombieAI>().enabled = true;
        }
        if (Vector3.Distance(go_Player.transform.position, transform.position) >= f_Range)
        {
            GetComponent<BasicZombieAI>().enabled = false;
        }
      
    }

    private void OnDrawGizmos()
    {

        if (DrawDebug)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, f_Range);

        }

    }
}
