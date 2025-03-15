using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceGameTime : MonoBehaviour
{

    int week;

    public BuyUpgrade upgrade_buyer;
    public GameObject upgrade_button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //beginning of game, when sprite is first loaded in
        week = 0;
        //actually might want to ddelay this some
        while(!SceneManager.GetSceneByName("Town").isLoaded){

        }
        upgrade_button = GameObject.Find("BuyButton0");
        upgrade_buyer = upgrade_button.GetComponent<BuyUpgrade>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        upgrade_button = GameObject.Find("BuyButton0");
        upgrade_buyer = upgrade_button.GetComponent<BuyUpgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        //Advance Game Time by one week if not end of game
        if(week < 12){
            //advance time
            week++;
            //clear locks on buying items
            upgrade_buyer.clicked = false;
            //reroll upgrade - this will likely need to be reworked later
            upgrade_buyer.upgrade_id = (int)Random.Range(0, upgrade_buyer.max_id);
            //probably also need to add money
        }else{
            //End the game
            //load in the end game screen
            SceneManager.LoadScene("EndScreen");
            //unload the main game play screen
            SceneManager.UnloadSceneAsync("Town");
        }
    }
}
