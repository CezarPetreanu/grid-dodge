using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningObject : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(0, Random.Range(0f, 360f), 0, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
    }
}
