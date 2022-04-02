using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Deathzone : MonoBehaviour

{
    public GameObject Player;
    public GameObject DeathAnimation;
    public GameObject GlobalVolume;
    private bool HasDied;
    public GameObject BackMainmenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalVolume.SetActive(false);
            DeathAnimation.SetActive(true);
            HasDied = true;
            BackMainmenu.SetActive(true);
            Player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        
       
    }


}
