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
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        else {
            GameObject clone = Instantiate(bubble, new Vector3(transform.position[0] - 3.5f, transform.position[1] + 0.5f, 0), transform.rotation);
            clone.transform.parent = transform;
            timer = 0;
        }
    }
}
