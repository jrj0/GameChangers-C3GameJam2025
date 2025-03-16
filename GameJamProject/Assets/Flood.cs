using UnityEngine;
using UnityEngine.SceneManagement;

public class Flood : MonoBehaviour
{
    public GameObject next_week;
    public GameObject health_storage, food_storage, water_storage, happiness_storage;
    public AdvanceGameTime currTime;
    private MeterManager health, food, water, happiness;
    public bool LeveeCheck, SandbagCheck;
    private bool flood_sent;
    public Sprite[] bg_sprites; //4 background sprites of increasing darkness
    int uhoh_thres, trouble_thres, dying_thres;
    SpriteRenderer testRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flood_sent = false;
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
        uhoh_thres = 40;
        trouble_thres = 25;
        dying_thres = 5;
        testRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currTime.week == 9 && flood_sent == false){
            SendFlood();
        }
        if(health.value < dying_thres || food.value < dying_thres || water.value < dying_thres || happiness.value < dying_thres){
            testRenderer.sprite = bg_sprites[3];
        }else if(health.value < trouble_thres || food.value < trouble_thres || water.value < trouble_thres || happiness.value < trouble_thres){
            testRenderer.sprite = bg_sprites[2];
        }else if(health.value < uhoh_thres || food.value < uhoh_thres || water.value < uhoh_thres || happiness.value < uhoh_thres){
            testRenderer.sprite = bg_sprites[1];
        }else{
            testRenderer.sprite = bg_sprites[0];
        }
        
        
        
    }

    void SendFlood(){
        flood_sent = true;
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