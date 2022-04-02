using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthbarController : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float startHealth;
    public GameObject Player;
    public GameObject DeathAnimation;
    public GameObject GlobalVolume;
    private bool HasDied;
    public GameObject BackMainmenu;
    public void onTakeDamage(float damage)
    {
        if(health - damage >= 0)
        {
            health = health - damage;
            healthBar.fillAmount = health / startHealth;
        }
        else
        {
            if (!HasDied)
            {
                foreach (Transform Child in Player.transform)
                {
                    Child.gameObject.SetActive(false);
                }

                GlobalVolume.SetActive(false);
                DeathAnimation.SetActive(true);
                HasDied = true;
                Player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
                BackMainmenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
    
}
