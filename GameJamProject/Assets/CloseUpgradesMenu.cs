using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseUpgradesMenu : MonoBehaviour
{

    public GameObject health_icon, food_icon, water_icon, happiness_icon, money_icon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health_icon = GameObject.Find("Health Icon");
        food_icon = GameObject.Find("Food Icon");
        water_icon = GameObject.Find("Water Icon");
        happiness_icon = GameObject.Find("Happiness Icon");
        money_icon = GameObject.Find("Money Symbol/Storage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        //should open the upgrades menu - needs to load new scene + move some items to the menu scene
        //Specifically the meters + money need to move to a different scene
        SceneManager.MoveGameObjectToScene(health_icon, SceneManager.GetSceneByName("Town"));
        SceneManager.MoveGameObjectToScene(food_icon, SceneManager.GetSceneByName("Town"));
        SceneManager.MoveGameObjectToScene(water_icon, SceneManager.GetSceneByName("Town"));
        SceneManager.MoveGameObjectToScene(happiness_icon, SceneManager.GetSceneByName("Town"));
        SceneManager.MoveGameObjectToScene(money_icon, SceneManager.GetSceneByName("Town"));

        //unload scene last
        SceneManager.UnloadSceneAsync("UpgradesOverlay");
    }
}
