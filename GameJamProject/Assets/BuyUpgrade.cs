using System.ComponentModel;
using Mono.Cecil;
using TMPro;
using UnityEditor.Rendering.Universal;
using UnityEngine;

//This struct may need to be updated to account for additional effects (chance of flooding stuff)
struct Upgrade {

    public Upgrade(string name, string descript, int money, int health, int food, int water, int happy){
        Name = name;
        Description = descript;
        cost = money;
        health_effect = health;
        food_effect = food;
        water_effect = water;
        happiness_effect = happy;
        bought = false;
    }
    public string Name;
    public string Description;
    public int cost;
    public int health_effect;
    public int food_effect;
    public int water_effect;
    public int happiness_effect;
    public bool bought;
};

public class BuyUpgrade : MonoBehaviour
{
    // This should be a parameterizable/modifyable script to allow a buy button to buy a specific upgrade
    // Need to have an array or other accessible data table of all possible upgrades in the game
    // Tie a specific upgrade to each instance of a buy button

    // This script does need to access every meter manager + the stored money
    private MoneyManager monies;
    private MeterManager health, food, water, happiness;

    public GameObject money_storage, health_storage, food_storage, water_storage, happiness_storage, next_week;

    public AdvanceGameTime currTime;
    
    private Upgrade[] upgrade_table = {
        new Upgrade("Rainfall Barrels", "Rainfall barrels help capture rainfall during the rarer, heavy rainfalls, so that there is increased water available during drought periods", 100, 0, 0, 15, 0),
        new Upgrade("Veterinary Supplies", "Additional veterinary supplies will help town farmers take care of their livestock, increasing food production", 250, 0, 15, 0, 0),
        new Upgrade("Medical Supplies", "Medical supplies are necessary to help maintain the townspeople's health", 250, 15, 0, 0, 0),
        new Upgrade("Irrigation Canals", "Developing and maintaining irrigation canals will help distribute freshwater for crops, but reduce the amount of available water", 200, 0, 15, -5, 0)
    }; //this value will need to ba changed to keep up with number of upgrades


    //public TMP_Text name_text, description_text;

    public int upgrade_id;

    public bool clicked = false;

    public int max_id;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        max_id = upgrade_table.Length;

        health_storage = GameObject.Find("Health Icon");
        food_storage = GameObject.Find("Food Icon");
        water_storage = GameObject.Find("Water Icon");
        happiness_storage = GameObject.Find("Happiness Icon");
        money_storage = GameObject.Find("Money Symbol/Storage");
        next_week = GameObject.Find("Next_Week_Button_0");
    
        monies = money_storage.GetComponent<MoneyManager>();
        health = health_storage.GetComponent<MeterManager>();
        food = food_storage.GetComponent<MeterManager>();
        water = water_storage.GetComponent<MeterManager>();
        happiness = happiness_storage.GetComponent<MeterManager>();
        currTime = next_week.GetComponent<AdvanceGameTime>();

        currTime.time_advance.AddListener(ClearLocks);

        //Need to do a lot of work with this to properly import all of the content + generate ids well

        //At the moment just grabs a random id from the list of upgrades - some of them need to have
        //additional qualifiers however + probably buckets of different costs
        upgrade_id = (int)Random.Range(0, max_id);
    }

    // Update is called once per frame
    void Update()
    {
        //name_text.text = upgrade_table[upgrade_id].Name;
        //description_text.text = upgrade_table[upgrade_id].Description;
    }

    void OnMouseDown(){
        //Need to identify the requirements for each upgrade to appear
        if(monies.money >= upgrade_table[upgrade_id].cost && upgrade_table[upgrade_id].bought == false && clicked == false){
            health.value += upgrade_table[upgrade_id].health_effect;
            food.value += upgrade_table[upgrade_id].food_effect;
            water.value += upgrade_table[upgrade_id].water_effect;
            happiness.value += upgrade_table[upgrade_id].happiness_effect;
            monies.money -= upgrade_table[upgrade_id].cost;
            upgrade_table[upgrade_id].bought = true;
            clicked = true;
        }
        //Button + upgrade also need to disappear
        //Or could just change it to a different button that has a checkmark or something
    }

    void ClearLocks(){
        //clear ability to buy with this button and reroll id
        clicked = false;
        while(upgrade_table[upgrade_id].bought == true){
            upgrade_id = (int)Random.Range(0, max_id);
        }
    }
}
