using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBubble : MonoBehaviour
{
    [SerializeField]public AudioSource bubbleSound;
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bubbleSound.Play();
        }

    }

}

