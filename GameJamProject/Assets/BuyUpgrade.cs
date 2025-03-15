using Mono.Cecil;
using TMPro;
using UnityEditor.Rendering.Universal;
using UnityEngine;

//This struct may need to be updated to account for additional effects (chance of flooding stuff)
struct Upgrade {
    public string Name;
    public string Description;
    public int cost;
    public int health_effect;
    public int food_effect;
    public int water_effect;
    public int happiness_effect;
};

public class BuyUpgrade : MonoBehaviour
{
    // This should be a parameterizable/modifyable script to allow a buy button to buy a specific upgrade
    // Need to have an array or other accessible data table of all possible upgrades in the game
    // Tie a specific upgrade to each instance of a buy button

    // This script does need to access every meter manager + the stored money
    private MoneyManager monies;
    private MeterManager health, food, water, happiness;

    public GameObject money_storage, health_storage, food_storage, water_storage, happiness_storage;

    private Upgrade[] upgrade_table = new Upgrade[5]; //this value will need to ba changed to keep up with number of upgrades


    //public TMP_Text name_text, description_text;

    int upgrade_id;

    bool clicked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health_storage = GameObject.Find("Health Icon");
        food_storage = GameObject.Find("Food Icon");
        water_storage = GameObject.Find("Water Icon");
        happiness_storage = GameObject.Find("Happiness Icon");
        money_storage = GameObject.Find("Money Symbol/Storage");
    
        monies = money_storage.GetComponent<MoneyManager>();
        health = health_storage.GetComponent<MeterManager>();
        food = food_storage.GetComponent<MeterManager>();
        water = water_storage.GetComponent<MeterManager>();
        happiness = happiness_storage.GetComponent<MeterManager>();

        upgrade_table[0].Name = "Rainfall Barrels";
        upgrade_table[0].Description = "Rainfall barrels help capture rainfall during the rarer, heavy rainfalls, so that there is increased water available during drought periods";
        upgrade_table[0].cost = 100;
        upgrade_table[0].health_effect = 0;
        upgrade_table[0].food_effect = 0;
        upgrade_table[0].water_effect = 15;
        upgrade_table[0].happiness_effect = 0;

        upgrade_id = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //name_text.text = upgrade_table[upgrade_id].Name;
        //description_text.text = upgrade_table[upgrade_id].Description;
    }

    void OnMouseDown(){
        //Need to identify the requirements for each upgrade to appear
        if(monies.money >= upgrade_table[upgrade_id].cost && clicked == false){
            health.value += upgrade_table[upgrade_id].health_effect;
            food.value += upgrade_table[upgrade_id].food_effect;
            water.value += upgrade_table[upgrade_id].water_effect;
            happiness.value += upgrade_table[upgrade_id].happiness_effect;
            monies.money -= upgrade_table[upgrade_id].cost;
            clicked = true;
        }
        //Button + upgrade also need to disappear
        //Or could just change it to a different button that has a checkmark or something
    }
}
