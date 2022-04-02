using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisclaimerScript : MonoBehaviour
{
    public Image disclaimerImage;

    void Start()
    {
        StartCoroutine(FadeDisclaimer());
    }

    IEnumerator FadeDisclaimer()
    {
        yield return new WaitForSeconds(5f);

        while(disclaimerImage.color.a > 0f)
        {
            disclaimerImage.color = new Color(disclaimerImage.color.r, disclaimerImage.color.g, disclaimerImage.color.b, disclaimerImage.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
