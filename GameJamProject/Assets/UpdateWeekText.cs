using TMPro;
using UnityEngine;

public class UpdateWeekText : MonoBehaviour
{

    public GameObject next_week;
    public AdvanceGameTime currTime;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_week = GameObject.Find("Next_Week_Button_0");
        currTime = next_week.GetComponent<AdvanceGameTime>();
        currTime.time_advance.AddListener(UpdateWeek);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateWeek(){
        text.text = "Week " + (currTime.week + 1);
    }

}
