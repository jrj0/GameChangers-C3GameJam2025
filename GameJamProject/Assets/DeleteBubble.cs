using UnityEngine;
using System;

public class DeleteBubble : MonoBehaviour
{
    private float timer = 0;
    private const int liveTime = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < liveTime) {
            timer += Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }
}
