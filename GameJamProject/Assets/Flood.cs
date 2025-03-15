using UnityEngine;
using UnityEngine.SceneManagement;

public class Flood : MonoBehaviour
{
    public GameObject next_week;
    public GameObject health_storage, food_storage, water_storage, happiness_storage;
    public AdvanceGameTime currTime;
    private MeterManager health, food, water, happiness;
    public bool LeveeCheck, SandbagCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_week = GameObject.Find("Next_Week_Button_0");
        health_storage = GameObject.Find("Health Icon");
        food_storage = GameObject.Find("Food Icon");
        water_storage = GameObject.Find("Water Icon");
        happiness_storage = GameObject.Find("Happiness Icon");
        currTime = next_week.GetComponent<AdvanceGameTime>();


        health = health_storage.GetComponent<MeterManager>();
        food = food_storage.GetComponent<MeterManager>();
        water = water_storage.GetComponent<MeterManager>();
        happiness = happiness_storage.GetComponent<MeterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currTime.week == 4){
            SendFlood();
        }
    }

    void SendFlood(){
        if(LeveeCheck && SandbagCheck){
            //really low impact from flood
            //health -5
            health.value -= 5;
            //food 0
            water.value -= 5;
            //water -5
            happiness.value += 10;
            //happiness +10   people are happy they avoided most impacts of the storm
        }else if(LeveeCheck && !SandbagCheck){
            //slightly higher impact from flood
            //health -10
            health.value -= 10;
            //food 0
            //water -10
            water.value -= 10;
            //happiness -5
            happiness.value -= 5;
        }else if(!LeveeCheck && SandbagCheck){
            //greater impacts
            //health -25
            health.value -= 25;
            //food -20
            food.value -= 20;
            //water -40
            water.value -= 40;
            //happiness -25
            happiness.value -= 25;
        }else{
            //devastating impacts
            //health -50
            health.value -= 50;
            //food -50
            food.value -= 50;
            //water -50
            water.value -= 50;
            //happiness -50
            happiness.value -= 50;
        }
    }


}