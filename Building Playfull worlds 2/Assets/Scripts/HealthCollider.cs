using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollider : MonoBehaviour
{
    public AudioSource HitSound;
    public HealthbarController healthbar;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Toxic")
        {
            if (healthbar)
            {
                healthbar.onTakeDamage(10);
                HitSound.Play();
                
            }

        }

    }

}