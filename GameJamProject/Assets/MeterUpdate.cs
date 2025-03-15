using UnityEngine;

public class MeterUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Want this to be roughly generalizable? So need to somehow get a generalized integer to track
    //For the moment going with a non-generalized version

    private MeterManager meterManage;
    public GameObject data_storage;
    
    SpriteRenderer testRenderer;

    public Sprite[] spriteArray;

    void Start()
    {
        meterManage = data_storage.GetComponent<MeterManager>();
        testRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        int step = 100 / 13;  //"maximum" value divided by number of sprites in spritesheet
        int spriteNum = meterManage.value / step;

        testRenderer.sprite = spriteArray[spriteNum];

    }
}
