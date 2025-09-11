using UnityEngine;

public class ImageLooper : MonoBehaviour
{
    public float speed = 200f;    
    public float resetX = -300f;      
    public float endX = 800f;          

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(resetX, rectTransform.anchoredPosition.y);
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);

        if (rectTransform.anchoredPosition.x > endX)
        {
            rectTransform.anchoredPosition = new Vector2(resetX, rectTransform.anchoredPosition.y);
        }
    }
}
