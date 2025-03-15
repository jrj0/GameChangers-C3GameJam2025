using UnityEngine;

public class ReduceMoney : MonoBehaviour
{

    private MoneyManager monies;
    public GameObject money_storage;
    //public GameObject bad_money_button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monies = money_storage.GetComponent<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            monies.money -= 25;
        }
    }
}
