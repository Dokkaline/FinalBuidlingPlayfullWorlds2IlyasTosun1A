using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEffectTrigger : MonoBehaviour
{
    public GameObject GlobalVolume;
    public AudioSource BubbleSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalVolume.SetActive(false);
            BubbleSound.Play();
            other.gameObject.GetComponent<PlayerManager>().StopToxicDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BubbleSound.Play();
            GlobalVolume.SetActive(true);
            other.gameObject.GetComponent<PlayerManager>().StartToxicDamage();
        }
    }
}

