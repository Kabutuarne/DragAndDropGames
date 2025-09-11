using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToCityScene()
    {
        SceneManager.LoadScene("CityScene");
    }
}
