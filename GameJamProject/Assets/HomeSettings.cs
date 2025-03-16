using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSettings : MonoBehaviour
{
    public void GoToSettings()
    {
        SceneManager.LoadScene("HomeSettings");
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene("HomeSettings");
    }
}
