using System.ComponentModel;
using System.Runtime.CompilerServices;

//using Mono.Cecil;
using TMPro;
//using UnityEditor.Rendering.Universal;
using UnityEngine;

//This struct may need to be updated to account for additional effects (chance of flooding stuff)
public struct Upgrade {

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
    public GameObject background;
    public AdvanceGameTime currTime;
    public Flood flood_script;

    public TMP_Text upgrade1desc, upgrade1name, upgrade1cost;

    public AudioManager audioManager;
    
    public Upgrade[] upgrade_table = {
        new Upgrade("Levee Construction", "Constructing a levee on rivers close to the town can help mitigate the effects of flooding in the longterm", 700, 0, 0, 0, 0),
        new Upgrade("Sandbags", "Adding sandbags along a river can help in case of a short term flooding event", 200, 0, 0, 0, 0),
        new Upgrade("Rainfall Barrels", "Rainfall barrels help capture rainfall during the rarer, heavy rainfalls, so that there is increased water available during drought periods", 100, 0, 0, 15, 0),
        new Upgrade("Veterinary Supplies", "Additional veterinary supplies will help town farmers take care of their livestock, increasing food production", 250, 0, 15, 0, 0),
        new Upgrade("Medical Supplies", "Medical supplies are necessary to help maintain the townspeople's health", 250, 15, 0, 0, 0),
        new Upgrade("Irrigation Canals", "Developing and maintaining irrigation canals will help distribute freshwater for crops, but reduce the amount of available water", 200, 0, 15, -5, 0),
        new Upgrade("Increase Fertilizer Usage", "Fertilizer can help crops grow faster and be more productive, but it can also have negative effects on the water supply", 150, 0, 15, -5, 0),
        new Upgrade("Increase Freshwater Storage", "Adding increased freshwater storage will help the town's water supply, but it may also limit how much water is immediately available for crops and animals", 150, 0, -5, 15, 0)
    }; //this value will need to ba changed to keep up with number of upgrades


    //public TMP_Text name_text, description_text;

    public GameObject button2, button3;
    public BuyUpgrade button2_script, button3_script;
    public int upgrade_id1, upgrade_id2, upgrade_id3;

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
        background = GameObject.Find("CC_bg_0");
    
        monies = money_storage.GetComponent<MoneyManager>();
        health = health_storage.GetComponent<MeterManager>();
        food = food_storage.GetComponent<MeterManager>();
        water = water_storage.GetComponent<MeterManager>();
        happiness = happiness_storage.GetComponent<MeterManager>();
        currTime = next_week.GetComponent<AdvanceGameTime>();
        flood_script = background.GetComponent<Flood>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        currTime.time_advance.AddListener(ClearLocks);

        //Need to do a lot of work with this to properly import all of the content + generate ids well

        //At the moment just grabs a random id from the list of upgrades - some of them need to have
        //additional qualifiers however + probably buckets of different costs
        upgrade_id1 = (int)Random.Range(0, max_id);
        upgrade_id2 = button2_script.upgrade_id1;
        upgrade_id3 = button3_script.upgrade_id1;
    }

    // Update is called once per frame
    void Update()
    {
        upgrade1name.text = upgrade_table[upgrade_id1].Name;
        upgrade1desc.text = upgrade_table[upgrade_id1].Description;
        upgrade1cost.text = upgrade_table[upgrade_id1].cost.ToString();
    }

    void OnMouseDown(){

        //Need to identify the requirements for each upgrade to appear
        if(monies.money >= upgrade_table[upgrade_id1].cost && upgrade_table[upgrade_id1].bought == false && clicked == false){
            health.value += upgrade_table[upgrade_id1].health_effect;
            food.value += upgrade_table[upgrade_id1].food_effect;
            water.value += upgrade_table[upgrade_id1].water_effect;
            happiness.value += upgrade_table[upgrade_id1].happiness_effect;
            monies.money -= upgrade_table[upgrade_id1].cost;
            upgrade_table[upgrade_id1].bought = true;
            clicked = true;
            if(upgrade_id1 == 0){
                flood_script.LeveeCheck = true;
            }else if(upgrade_id1 == 1){
                flood_script.SandbagCheck = true;
            }
        }

        //play SFX for button press
        audioManager.PlaySFX(audioManager.buttonLarge);
        
        //Button + upgrade also need to disappear
        //Or could just change it to a different button that has a checkmark or something
    }

    void ClearLocks(){
        //clear ability to buy with this button and reroll id
        clicked = false;
        while(upgrade_table[upgrade_id1].bought == true || (upgrade_id1 == upgrade_id2) || (upgrade_id1 == upgrade_id3)){
            upgrade_id1 = (int)Random.Range(0, max_id);
        }
    }
}
