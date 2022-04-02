using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string scenename;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            SceneManager.LoadScene(scenename);

        }

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);


    }

}
