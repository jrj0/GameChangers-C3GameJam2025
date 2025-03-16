using UnityEngine;
public class DialogueSpawnScript : MonoBehaviour
{
    public GameObject bubble;
    public float spawnRate;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRate = Random.Range(5, 10);
        timer = 2;
        Farmer.setRandomizedDialogues();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            GameObject clone = Instantiate(bubble, transform);
            timer = 0;
        }
    }
}
