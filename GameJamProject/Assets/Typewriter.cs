using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typewriter : MonoBehaviour
{
    public Text textUI;
    public float typingSpeed = 0.05f;
    public string fullText;
    private int currentCharacterIndex = 0;
    private string currentText = "";
    private int textRatio = 0;

    void Start()
    {
        if (textUI != null)
        {
            textUI.text = "";
        }
    }

    void Update()
    {
        textRatio++;
        TypewriterEffect();
        
    }

    public void TypewriterEffect()
    {
        if (textRatio % 7 == 0)
        {
            if (textUI != null && fullText != null && fullText.Length > 0)
            {
                if (currentCharacterIndex < fullText.Length)
                {
                    currentText = fullText.Substring(0, currentCharacterIndex + 1);
                    textUI.text = currentText;
                    currentCharacterIndex++;
                    Invoke("TypewriterEffect", typingSpeed);
                }
                else
                {
                    Debug.Log("Typing finished!");
                }
            }
        }
    }
}