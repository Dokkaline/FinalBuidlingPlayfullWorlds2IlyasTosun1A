using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGate : Dialogue
{
    public string OpenGateText;
    public string GetKeyText;
    public GameObject interactText;
    private GameObject player = null;
    public GameObject KeyImage;

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
            if (player.GetComponent<PlayerManager>().HasKey)
            {
                OpenGate();
                CreateDialogueText(OpenGateText);
            }
            else
            {
                CreateDialogueText(GetKeyText);
            }
        }
       
    }

    private void OpenGate()
    {
        KeyImage.SetActive(false);
        interactText.SetActive(false);
        Destroy(this.gameObject);
    }
}
