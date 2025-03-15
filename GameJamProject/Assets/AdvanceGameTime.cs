using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AdvanceGameTime : MonoBehaviour
{

    public int week;

    public UnityEvent time_advance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //beginning of game, when sprite is first loaded in
        week = 0;
        //actually might want to ddelay this some
        while(!SceneManager.GetSceneByName("Town").isLoaded){

        }
        if(time_advance == null){
            time_advance = new UnityEvent();
        }
        //time_advance.AddListener(ClearLocks);
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
            time_advance.Invoke();
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
