using UnityEngine;

public class MeterUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Want this to be roughly generalizable? So need to somehow get a generalized integer to track
    //For the moment going with a non-generalized version

    private MoneyManager monies;
    public GameObject money_storage;
    
    SpriteRenderer testRenderer;

    public Sprite[] spriteArray;

    void Start()
    {
        monies = money_storage.GetComponent<MoneyManager>();
        testRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        int step = 5000 / 13;  //"maximum" money divided by number of sprites in spritesheet
        int spriteNum = monies.money / step;

        testRenderer.sprite = spriteArray[spriteNum];
        testRenderer.size = new Vector2(4, 4);

    }
}
