using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Emenie")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(20);
        }
        Destroy(gameObject);
    }
}
