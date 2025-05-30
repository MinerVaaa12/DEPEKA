using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

public class TintScreen : MonoBehaviour
{
    [SerializeField] Color unTintedColor;      
    [SerializeField] Color tintedColor;         
    float f;                                   
    public float speed = 0.5f;       

    Image image;                                

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Tint()
    {
        StopAllCoroutines();
        f = 0f;
        StartCoroutine(TintScreenRoutine());
    }

    public void UnTint()
    {
        f = 0f;
        StartCoroutine(UnTintScreen());
    }

    private IEnumerator TintScreenRoutine()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp01(f);

            Color c = Color.Lerp(unTintedColor, tintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator UnTintScreen()
    {
        f = 0f;
        while (f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp01(f);

            Color c = Color.Lerp(tintedColor, unTintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }
}
