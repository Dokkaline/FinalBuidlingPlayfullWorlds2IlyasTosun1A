using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDIalogue : Dialogue 
{
    public string GivenText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CreateDialogueText(GivenText);
            other.gameObject.GetComponent<PlayerManager>().HasKey = true;
        }
    }
}
