using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPageButton : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("TutorialPage");
    }
}
