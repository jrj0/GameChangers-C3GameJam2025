using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    public int money = 1000; //assuming that you start with 1000 dollars - this value can absolutely change
    //public Button badMoneyButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 1000; //make sure that it resets
        //badMoneyButton.onClick.AddListener(()=>ButtonWasClicked());
    }

    // Update is called once per frame
    void Update()
    {
        // when clicking on a different button, make money go down
    }

    //Need to add 1000 dollars per week
    //Subtract money when specific projects or upgrades are bought
}
