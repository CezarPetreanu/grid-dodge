using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rb;
    public GameObject bullet;
    public GameObject coin;
    private float scale = 0;
    public bool inflate = true;
    public float wait;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().enabled = false;
        tr.localScale = new Vector3(0f, 0f, 0f);
        Invoke("enemy_deflate", wait);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(coin.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        enemy_inflate();
        tr.position = new Vector3(tr.position.x, 2, tr.position.z);
    }

    void enemy_inflate()
    {
        if (scale != 2 && inflate)
        {
            scale = Mathf.Lerp(scale, 2, 0.05f);
            tr.localScale = new Vector3(scale, scale, scale);
        }
        else if (scale != 0 && !inflate)
        {
            GetComponent<SphereCollider>().enabled = false;
            scale = Mathf.Lerp(scale, 0, 0.05f);
            tr.localScale = new Vector3(scale, scale, scale);
            if (scale < 0.01)
                Destroy(gameObject);

        }
        if (scale > 1.8)
        {
            GetComponent<SphereCollider>().enabled = true;
        }
    }

    void enemy_deflate()
    {
        inflate = false;
    }
}
