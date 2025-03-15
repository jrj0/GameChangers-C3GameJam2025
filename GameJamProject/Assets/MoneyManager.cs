using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public int money = 5000; //assuming that you start with 5000 dollars - this value can absolutely change

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 5000; //make sure that it resets
    }

    // Update is called once per frame
    void Update()
    {
        // when clicking on a different button, make money go down

    }
}
