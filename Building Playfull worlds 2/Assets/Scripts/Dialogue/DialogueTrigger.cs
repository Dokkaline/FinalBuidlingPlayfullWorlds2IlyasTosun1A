
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : Dialogue
{
    public string GivenText;
    public bool CanInteract = false;
    public TMP_Text InteractText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanInteract = true;
            InteractText.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (CanInteract && Input.GetKeyDown(KeyCode.E))
        {
            CreateDialogueText(GivenText);
            InteractText.gameObject.SetActive(false);
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanInteract = false;
            InteractText.gameObject.SetActive(false);
        }
    }
}