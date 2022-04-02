using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainPurifire : MonoBehaviour
{
    public GameObject Purifire;
    public GameObject PurifireinCase;
    public AudioSource Voiceline;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            Purifire.SetActive(true);
            PurifireinCase.SetActive(false);
            Voiceline.Play();
            
            Player.GetComponent<PlayerManager>().HasPurifire = true;
        }


    }
}
