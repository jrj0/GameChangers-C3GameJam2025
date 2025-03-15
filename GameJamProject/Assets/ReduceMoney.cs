using Unity.VisualScripting;
using UnityEngine;

public class ReduceMoney : MonoBehaviour
{

    private MoneyManager monies;
    public GameObject money_storage;
    public GameObject bad_money_button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monies = money_storage.GetComponent<MoneyManager>();
        bad_money_button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown(){
        monies.money -= 25;
    }
}
