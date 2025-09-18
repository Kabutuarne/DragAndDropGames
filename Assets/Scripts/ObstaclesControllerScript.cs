using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

public class ObstaclesControllerScript : MonoBehaviour
{
    [HideInInspector]
    public float speed = 1f;
    public float waveAplitude = 25f;
    public float waveFrequency = 1f;
    public float fadeDuration = 1.5f;
    private ObjectScript objectScript;
    private ScreenBoundriesScript screenBoundriesScript;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private bool isFadingOut = false;
    private Image image;
    private Color originalColor;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if(canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        originalColor = image.color;

        objectScript = Object.FindFirstObjectByType<ObjectScript>();
        screenBoundriesScript = Object.FindFirstObjectByType<ScreenBoundriesScript>();
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        float waveOffset = Mathf.Sin(Time.time * waveFrequency) * waveAplitude;
        rectTransform.anchoredPosition += new Vector2(-speed * Time.deltaTime, waveOffset * Time.deltaTime);
        // ja lido pa kreisi
        if(speed > 0 && transform.position.x < (screenBoundriesScript.minX + 100) && !isFadingOut)
        {
            StartCoroutine(FadeOutAndDestroy());
        }
        // ja lido pa labi
        if (speed < 0 && transform.position.x > (screenBoundriesScript.maxX - 100) && !isFadingOut)
        {
            StartCoroutine(FadeOutAndDestroy());
        }
        if (ObjectScript.drag && !isFadingOut && RectTransformUtility.RectangleContainsScreenPoint(
            rectTransform, Input.mousePosition, Camera.main))
        {
            Debug.Log("obstacle hit by drag");
            if(ObjectScript.lastDragged != null)
            {
                StartCoroutine(ShrinkAndDestroy(ObjectScript.lastDragged, .5f));
                ObjectScript.lastDragged = null;
                ObjectScript.drag = false;
            }

            StartCoroutine(FadeOutAndDestroy());
            isFadingOut = true;

            image.color = Color.red;
            StartCoroutine(RecoverColor());
  
            StartCoroutine(Vibrate());
            if(objectScript.effects != null && objectScript.audioCli != null)
            {
                objectScript.effects.PlayOneShot(objectScript.audioCli[12]);
            }
        }
        {

        }
    }
    IEnumerator FadeIn()
    {
        float a = 0f;
        while(a < fadeDuration)
        {
            a += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, a / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
    IEnumerator FadeOutAndDestroy()
    {
        float a = 0f;
        float startAlpha = canvasGroup.alpha;

        while (a < fadeDuration)
        {
            a += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, a / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0;
        Destroy(gameObject);
    }

    IEnumerator ShrinkAndDestroy(GameObject target, float duration)
    {
        Vector3 originalScale = target.transform.localScale;
        Quaternion originalRotation = target.transform.rotation;
        float t = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;
            target.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t / duration);
            float angle = Mathf.Lerp(0, 360, t / duration);
            target.transform.rotation = Quaternion.Euler(0, 0, angle);

            yield return null;
        }
        Destroy(target);
    }

    IEnumerator RecoverColor()
    {
        yield return new WaitForSeconds(0.5f);
        image.color = originalColor;
    }

    IEnumerator Vibrate()
    {
        Vector2 originalPosition = rectTransform.anchoredPosition;
        float duration = .3f;
        float elapsed = 0f;
        float intensity = 5f;

        while(elapsed < duration)
        {
            rectTransform.anchoredPosition = originalPosition + Random.insideUnitCircle * intensity;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
