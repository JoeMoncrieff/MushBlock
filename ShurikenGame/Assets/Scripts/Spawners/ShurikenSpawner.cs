using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    public GameObject shuriken;
    public float[] locations = { -1.5f, 0f, 1.5f };
    public int lvl = 1;
    public int batchSize = 5;

    public int currentBatchSize;


    public float timer;
    public float startingInterval = 1f;
    public float currentInterval;

    void Awake()
    {
        currentBatchSize = batchSize;
        currentInterval = startingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnGameObject();
    }

    void SpawnGameObject()
    {
        timer += Time.deltaTime;

        if (timer >= currentInterval)
        {
            Vector3 temp = transform.position;
            temp.x = locations[Random.Range(0, 3)];

            GameObject newShuriken = Instantiate(shuriken, temp, Quaternion.identity);
            SoundManager.instance.shurikenLaunchSound();
            timer = 0f;

            newShuriken.transform.SetParent(transform);


            currentBatchSize--;
            if (currentBatchSize <= 0)
            {
                lvl++;
                batchSize = batchSize += (lvl * 2);
                currentBatchSize = batchSize;
                float change = lvl * 0.05f;
                Debug.Log(change.ToString());
                currentInterval = startingInterval - (change);
                if (currentInterval <= 0.3f)
                {
                    currentInterval = 0.3f;
                }
                Debug.Log("Level: " + lvl.ToString());
                timer -= 2f;
            }
        }
    }
}
