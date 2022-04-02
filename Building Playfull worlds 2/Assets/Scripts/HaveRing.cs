using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveRing : Dialogue
{
    public string HandInText;
    public string GetRingText;
    public GameObject interactText;
    public GameObject KeyImage;
    public GameObject Ringimage;
    private GameObject player = null;
    public GameObject bartender;
    public AudioClip getRingAudio;
    public AudioClip handInAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            interactText.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player != null)
        {
            if (player.GetComponent<PlayerManager>().HasRing)
            {
               
                CreateDialogueText(HandInText);
                bartender.GetComponent<AudioSource>().clip = handInAudio;
                bartender.GetComponent<AudioSource>().Play();
                HandInRing();
            }
            else
            {
                CreateDialogueText(GetRingText);
                bartender.GetComponent<AudioSource>().clip = getRingAudio;
                bartender.GetComponent<AudioSource>().Play();
            }
        }
     
        
    }

    private void HandInRing()
    {
        player.GetComponent<PlayerManager>().HasRing = false;
        Ringimage.SetActive(false);
        player.GetComponent<PlayerManager>().HasKey = true;
        KeyImage.SetActive(true);
        GetComponent<AudioSource>().Play();
        interactText.SetActive(false);
        Destroy(this.gameObject);
    }
}
