using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterWanderer : MonoBehaviour
{
    public float f_WanderTimer;
    private float f_Timer;

    private Transform _Target;
    private NavMeshAgent _Agent;
    void OnEnable()
    {
        _Agent = GetComponent<NavMeshAgent>();
        f_Timer = f_WanderTimer;
    }
    void Update()
    {
        f_Timer += Time.deltaTime;

        if (f_Timer >= f_WanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, f_WanderTimer, -1);
            _Agent.SetDestination(newPos);
            f_Timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


}
