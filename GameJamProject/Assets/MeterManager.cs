using UnityEngine;

public class MeterManager : MonoBehaviour
{
    public int value;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //need to set limits on these values just to make sure that it doesn't break the meter spritesheets
        if(value > 100){
            value = 100;
        }else if(value < 0){
            value = 0;
        }
    }
}
