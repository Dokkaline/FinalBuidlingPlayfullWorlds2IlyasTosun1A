using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScore : MonoBehaviour
{
    public AudioSource collectSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerManager>().HasPurifire)
            {
                collectSound.Play();
                other.gameObject.GetComponent<PlayerManager>().AddBullet();

                other.gameObject.GetComponent<PlayerManager>().startVFX();

                other.gameObject.GetComponent<ScoringSystem>().theScore++;
                Destroy(gameObject);

            }

        }

    }


}
