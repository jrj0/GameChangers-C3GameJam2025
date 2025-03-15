using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    public int money = 5000; //assuming that you start with 5000 dollars - this value can absolutely change
    //public Button badMoneyButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 5000; //make sure that it resets
        //badMoneyButton.onClick.AddListener(()=>ButtonWasClicked());
    }

    // Update is called once per frame
    void Update()
    {
        // when clicking on a different button, make money go down
    }

    /**void ButtonWasClicked(){
        money -= 25;
    }*/
}
