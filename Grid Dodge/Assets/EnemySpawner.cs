using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject obj;

    public Vector3[] positions;
    public Vector3[] velocities;
    int rand;
    public float rate_min = 0.75f;
    public float rate_max = 1.5f;
    public float rate;
    public float ratio = 10f;
    float wait;
    public float decrease = 0.001f;

    public bool spawn = false;

    // Start is called before the first frame update
    void Start()
    {
        rate = rate_max;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            wait -= Time.deltaTime;
            if (wait <= 0)
            {
                spawn_enemy();
                if (rate > rate_min)
                    rate -= decrease;
                else
                    rate = rate_min;
                wait = rate;
            }
        }
    }

    // Update is called once per frame
    void spawn_enemy()
    {
        rand = Random.Range(0, 12);

        GameObject o = Instantiate(obj, new Vector3(positions[rand].x, positions[rand].y, positions[rand].z), Quaternion.identity);
        Rigidbody rb = o.GetComponent<Rigidbody>();

        float speed = ratio / rate;

        rb.velocity = new Vector3(speed * velocities[rand / 3].x, 0, speed * velocities[rand / 3].z);
        o.GetComponent<Enemy>().wait = rate;
    }

    public void spawn_start()
    {
        if (!spawn)
        {
            spawn = true;
            wait = rate;
        }
    }

    public void spawn_reset()
    {
        spawn = false;
        rate = rate_max;
    }
}