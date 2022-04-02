using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool HasKey = false;
    public bool HasRing = false;
    public bool HasPurifire = false;
    public BlueHealthBar oxygenBar;
    public HealthbarController healthBar;
    public MeshRenderer bubbleMaterial;
    public GameObject purifireEffect;
    public ScoringSystem scoringScript;
    private Coroutine toxicDamage;
    private Coroutine healthDamage;
    private Coroutine healing;
    private Coroutine bubbleEffectRoutine;
    private Coroutine purifireVFX;

    public void startVFX()
    {
        if(purifireVFX != null)
        {
            StopCoroutine(purifireVFX);
        }
        purifireVFX = StartCoroutine(StartPurifireEffect());
    }

    IEnumerator StartPurifireEffect()
    {
        while (true)
        {
            purifireEffect.SetActive(true);
            yield return new WaitForSeconds(3f);
            purifireEffect.SetActive(false);
        }
    }

    public void AddBullet()
    {
        scoringScript.theScore += 1;
    }

    public void StartToxicDamage()
    {
        toxicDamage = StartCoroutine(DealToxicDamage());
        if(healing != null)
        {
            StopCoroutine(healing);
        }
        bubbleEffectRoutine = StartCoroutine(BubbleEffect(true));
    }

    public void StopToxicDamage()
    {
        if(toxicDamage != null)
        {
            StopCoroutine(toxicDamage);
        }
        if(healthDamage != null)
        {
            StopCoroutine(healthDamage);
        }
        healing = StartCoroutine(HealOxygen());
        if (bubbleEffectRoutine != null)
        {
            StopCoroutine(bubbleEffectRoutine);
        }
        bubbleEffectRoutine = StartCoroutine(BubbleEffect(false));
    }

    IEnumerator DealToxicDamage()
    {
        while (true)
        {
            if (oxygenBar.health - 0.1f <= 0 && healthDamage == null)
            {
                oxygenBar.onTakeDamage(0.1f);
                healthDamage = StartCoroutine(DealHealthDamage());
                if(bubbleEffectRoutine != null)
                {
                    StopCoroutine(bubbleEffectRoutine);
                }
                bubbleEffectRoutine = StartCoroutine(BubbleEffect(false));
            }
            else
            {
                oxygenBar.onTakeDamage(0.1f);
            }
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator DealHealthDamage()
    {
        while (true)
        {
            healthBar.onTakeDamage(0.1f);
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator HealOxygen()
    {
        while (oxygenBar.health < 100f)
        {
            oxygenBar.RegenHealth(0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator BubbleEffect(bool outside)
    {
        if (outside)
        {
            while (bubbleMaterial.material.GetFloat("BubbleFloat") > 0f)
            {
                bubbleMaterial.material.SetFloat("BubbleFloat", bubbleMaterial.material.GetFloat("BubbleFloat") - 0.05f);
                yield return new WaitForSeconds(0.07f);
            }
        }
        else
        {
            while (bubbleMaterial.material.GetFloat("BubbleFloat") < 1f)
            {
                bubbleMaterial.material.SetFloat("BubbleFloat", bubbleMaterial.material.GetFloat("BubbleFloat") + 0.05f);
                yield return new WaitForSeconds(0.07f);
            }
        }
    }
}
