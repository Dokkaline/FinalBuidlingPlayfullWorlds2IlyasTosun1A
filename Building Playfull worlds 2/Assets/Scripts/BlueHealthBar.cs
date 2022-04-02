using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BlueHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float startHealth;
    public GameObject Player;
   
    public void onTakeDamage(float damage)
    {
        if (health - damage >= 0)
        {
            health = health - damage;
            healthBar.fillAmount = health / startHealth;
        }
       
    }

    public void RegenHealth(float heal)
    {
        if(health + heal >= startHealth)
        {
            health = startHealth;
            healthBar.fillAmount = health / startHealth;
        }
        else
        {
            health += heal;
            healthBar.fillAmount = health / startHealth;
        }
    }
}
