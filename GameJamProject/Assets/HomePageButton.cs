using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageButton : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("HomePage");
    }
}
