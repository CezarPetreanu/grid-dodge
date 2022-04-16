using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    int row=1, col=1;
    int prevrow=1, prevcol=1;

    static public Coin instance;

    void choose_pos()
    {
        do
        {
            row = Random.Range(-1, 2);
            col = Random.Range(-1, 2);
        } while (row == prevrow && col == prevcol);

        prevrow = row;
        prevcol = col;
    }
    void move_coin()
    {
        choose_pos();
        this.transform.position = new Vector3 (row*2, this.transform.position.y, col*2);
    }

    void Start()
    {
        instance = this;
        move_coin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.gameObject.GetComponent<Player>().spawn_start)
            {
                move_coin();
                Score.instance.addPoint();
            }
        }
    }
}
