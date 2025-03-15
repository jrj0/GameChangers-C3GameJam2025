using UnityEngine;
using TMPro;
using System;

public class MoneyDisplay : MonoBehaviour
{
    public TMP_Text text;
    public GameObject money_storage;
    private MoneyManager monies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monies = money_storage.GetComponent<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = monies.money.ToString();
    }
}
