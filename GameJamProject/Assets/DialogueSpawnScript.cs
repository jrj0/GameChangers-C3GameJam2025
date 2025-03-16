using UnityEngine;
public class DialogueSpawnScript : MonoBehaviour
{
    public GameObject bubble;
    public float spawnRate;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRate = 5;
        switch (bubble.name) {
            case "BeekeeperChatBubble":
                spawnRate = Random.Range(Beekeeper.rateLow, Beekeeper.rateHigh);
                break;
            case "BlacksmithChatBubble":
                spawnRate = Random.Range(Blacksmith.rateLow, Blacksmith.rateHigh);
                break;
            case "FarmerChatBubble":
                spawnRate = Random.Range(Farmer.rateLow, Farmer.rateHigh);
                break;
            case "RancherChatBubble":
                spawnRate = Random.Range(Rancher.rateLow, Rancher.rateHigh);
                break;
            case "ShepherdChatBubble":
                spawnRate = Random.Range(Shepherd.rateLow, Shepherd.rateHigh);
                break;
        }
        timer = 2;
        Farmer.setRandomizedDialogues();
        Beekeeper.setRandomizedDialogues();
        Shepherd.setRandomizedDialogues();
        Blacksmith.setRandomizedDialogues();
        Rancher.setRandomizedDialogues();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            GameObject clone = Instantiate(bubble, transform);
            //clone.layer = 7; //should be above all the other stuff then
            timer = 0;
        }
    }
}
