using UnityEngine;

public class TransformationScript : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(ObjectScript.lastDragged != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                ObjectScript.lastDragged.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 30f);
                
            }
            if (Input.GetKey(KeyCode.X))
            {
                ObjectScript.lastDragged.GetComponent<RectTransform>().transform.Rotate(0, 0,-Time.deltaTime * 30f);

            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
              if(ObjectScript.lastDragged.GetComponent<RectTransform>().localScale.y < 1f) {
                    ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector3(
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x,
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y + 0.02f, 1f);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (ObjectScript.lastDragged.GetComponent<RectTransform>().localScale.y > 0.5f)
                {
                    ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector3(
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x,
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y - 0.02f, 1f);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (ObjectScript.lastDragged.GetComponent<RectTransform>().localScale.x > 0.5f)
                {
                    ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector3(
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y,
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x - 0.02f, 1f);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (ObjectScript.lastDragged.GetComponent<RectTransform>().localScale.x < 1f)
                {
                    ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale =
                        new Vector3(
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y,
                        ObjectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x + 0.02f, 1f);
                }
            }

        }
    }
}
