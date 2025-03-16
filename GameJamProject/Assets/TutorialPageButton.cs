using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPageButton : MonoBehaviour
{
    public void GoToTutorial()
    {
        SceneManager.LoadScene("TutorialPage");
    }
}
