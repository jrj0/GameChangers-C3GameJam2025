using UnityEngine;

public class MeterManager : MonoBehaviour
{
    public int value;
    public GameObject next_week;
    public AdvanceGameTime currTime;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = 50;
        next_week = GameObject.Find("Next_Week_Button_0");
        currTime = next_week.GetComponent<AdvanceGameTime>();
        currTime.time_advance.AddListener(MeterDrop);
    }

    // Update is called once per frame
    void Update()
    {
        //need to set limits on these values just to make sure that it doesn't break the meter spritesheets
        if(value > 100){
            value = 100;
        }else if(value < 0){
            value = 0;
            //send some sort of message for early failure - how to do this?
        }
    }

    void MeterDrop(){
        value -= 5; //drop each meter by 5 every week - this can increase or decrease for balancing
    }
}
