using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
}
