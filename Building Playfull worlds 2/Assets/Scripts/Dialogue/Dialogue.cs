using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text DialogueText;
    public GameObject DialoguePanel;
    public void CreateDialogueText(string text)
    {
        DialoguePanel.SetActive(true);
        StartCoroutine(PlayText(text));
    }
    IEnumerator PlayText(string text)
    {
        DialogueText.text = "";
        foreach (char letter in text)
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(5f);
        DialoguePanel.SetActive(false);
    }
}