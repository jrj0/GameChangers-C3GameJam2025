using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    public int money = 1000; //assuming that you start with 1000 dollars - this value can absolutely change
    //public Button badMoneyButton;
    public GameObject next_week;
    public AdvanceGameTime currTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 1000; //make sure that it resets
        next_week = GameObject.Find("Next_Week_Button_0");
        currTime = next_week.GetComponent<AdvanceGameTime>();
        currTime.time_advance.AddListener(AddMoney);
    }

    // Update is called once per frame
    void Update()
    {
        // when clicking on a different button, make money go down
    }

    //Need to add money per week
    //Subtract money when specific projects or upgrades are bought
    void AddMoney(){
        money += 400;
    }
}
