using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenUpgradesMenu : MonoBehaviour
{
    public GameObject health_icon, food_icon, water_icon, happiness_icon, money_icon;

    //public MeshRenderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        //should open the upgrades menu - needs to load new scene + move some items to the menu scene
        //Specifically the meters + money need to move to a different scene
        SceneManager.LoadScene("UpgradesOverlay", LoadSceneMode.Additive);
        //renderer.enabled = true;
        //These dont actually seem to be moving?
        SceneManager.MoveGameObjectToScene(health_icon, SceneManager.GetSceneByName("UpgradesOverlay"));
        SceneManager.MoveGameObjectToScene(food_icon, SceneManager.GetSceneByName("UpgradesOverlay"));
        SceneManager.MoveGameObjectToScene(water_icon, SceneManager.GetSceneByName("UpgradesOverlay"));
        SceneManager.MoveGameObjectToScene(happiness_icon, SceneManager.GetSceneByName("UpgradesOverlay"));
        SceneManager.MoveGameObjectToScene(money_icon, SceneManager.GetSceneByName("UpgradesOverlay"));
    }
}
