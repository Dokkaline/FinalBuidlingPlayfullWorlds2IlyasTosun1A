using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image HealthSlider;
    public AudioSource DeathSound;
    public AudioSource HitSound;
    [SerializeField] public GameObject VFX;


    public float i_MaxHealth = 100;
    public float i_CurrentHealth;

    void Start()
    {
        i_CurrentHealth = i_MaxHealth;
       
    }

    
    public void TakeDamage(int damage)
    {
        
        if ((i_CurrentHealth - damage) <= 0)
        {

            //  go_Player.GetComponent<ScoringSystem>().UpdateScoreText();

            //  go_Player.GetComponent<Health>().AddToMaxHealth(2);
            DeathSound.Play();
            VFX.SetActive(true);
            i_CurrentHealth = 0;
            Destroy(this.gameObject,3f);
            

        }
        else
        {
            HitSound.Play();
            i_CurrentHealth -= damage;
            SetHealth(i_CurrentHealth);
        }

    }
 
    public void SetHealth(float health)
    {
        float value = health / i_MaxHealth;
        Debug.Log(value);
        HealthSlider.fillAmount = value;
        
    }
}