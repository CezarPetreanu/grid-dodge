using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingObject : MonoBehaviour
{
    public float originalY;
    float ang;
    float s;

    public float speed;
    public float amp;

    void Start()
    {
        this.originalY = this.transform.position.y;
        ang = Random.Range(0f, 360f);
        s = 0;
    }

    void Update()
    {
        ang += speed;
        if (speed >= 360)
            speed = speed % 360;

        s = Mathf.Sin(ang*Mathf.Deg2Rad)*amp;

        this.transform.position = new Vector3(this.transform.position.x, originalY+s, this.transform.position.z);
    }
}
