using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color FadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if(fadeOnStart)
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        Fade(1,0);
    }

    public void FadeOut()
    {
        Fade(0,1);
    }


   public void Fade(float alphaIn, float aplhaOut)
   {
    StartCoroutine(FadeRoutine(alphaIn, aplhaOut));

   }

   public IEnumerator FadeRoutine(float alphaIn, float aplhaOut)
   {
        float timer = 0;
        while(timer< fadeDuration)
        {
            Color newColor = FadeColor;
            newColor.a = Mathf.Lerp(alphaIn, aplhaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }
            Color newColor2 = FadeColor;
            newColor2.a = aplhaOut;

            rend.material.SetColor("_Color", newColor2);
   }
}
