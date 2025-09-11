using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TiltBtnTextScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text buttonText;         
    public float moveDistance = 10f;

    private Vector3 originalPosition;

    void Start()
    {
        if (buttonText != null)
            originalPosition = buttonText.rectTransform.localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.rectTransform.localPosition = originalPosition + Vector3.down * moveDistance;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.rectTransform.localPosition = originalPosition;
        }
    }
}
