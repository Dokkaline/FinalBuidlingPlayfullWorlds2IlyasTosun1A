using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RingPickup : MonoBehaviour
{
    public GameObject interactText;
    private GameObject player = null;
    public GameObject Ringimage;
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
            PickupRing();
        }
    }

    private void PickupRing()
    {
        player.GetComponent<PlayerManager>().HasRing = true;
        Ringimage.SetActive(true);
        GetComponent<AudioSource>().Play();
        interactText.SetActive(false);
        Destroy(this.gameObject);
    }
}
