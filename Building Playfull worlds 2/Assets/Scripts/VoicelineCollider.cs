using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicelineCollider : MonoBehaviour
{
    [SerializeField] public AudioSource VoiceLine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            VoiceLine.Play();
            Destroy(gameObject, 1f);
        }
           

    }
}
