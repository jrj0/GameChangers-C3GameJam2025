using Unity.VisualScripting;
using UnityEngine;

public class ButtonScale : MonoBehaviour
{
    public void PointerOver()
    {
        float scale = 2.2f;
        transform.localScale = new Vector2(scale, scale);
    }

    public void PointerExit()
    {
        float scale = 2.0f;
        transform.localScale = new Vector2(scale, scale);
    }
}