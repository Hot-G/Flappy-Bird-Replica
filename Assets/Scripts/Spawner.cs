using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnDelay = 2;
    public GameObject PipePrefab;

    float Timer;

    private void Start()
    {
        Timer = SpawnDelay;
    }

    void FixedUpdate()
    {
        if(Timer < 0f)
        {
            Timer = SpawnDelay;

            Instantiate(PipePrefab, new Vector2(transform.position.x, transform.position.y + Random.Range(-0.15f, 0.65f)), Quaternion.identity);
        }
        else
        {
            Timer -= Time.fixedDeltaTime;
        }
    }
}
