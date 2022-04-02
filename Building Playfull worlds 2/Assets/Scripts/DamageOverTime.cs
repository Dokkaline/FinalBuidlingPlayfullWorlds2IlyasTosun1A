using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public AudioSource Hitsound;

    public HealthbarController healthbar;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (healthbar)
            {
                StartCoroutine(TakeToxicDamage());

            }

        }

    } 

    IEnumerator TakeToxicDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            healthbar.onTakeDamage(5);
            Hitsound.Play();
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (healthbar)
            {
                StopCoroutine(TakeToxicDamage());

            }

        }
    }
}
