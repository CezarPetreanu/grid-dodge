using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int row=1, col=1;
    public int prevrow = 0,
                prevcol= 0;


    static public Coin instance;

    void choose_pos()
    {
        prevrow = Convert.ToInt32(Player.instance.Position_row);
        prevcol = Convert.ToInt32(Player.instance.Position_col);
        do
        {
            row = UnityEngine.Random.Range(-1, 2);
            col = UnityEngine.Random.Range(-1, 2);
        } while (row == prevrow && col == prevcol);

        Debug.Log("row:" + row + " | col:" + col + "\nprevrow:"+prevrow + " | prevcol:" + prevcol);
    }
    public void move_coin()
    {
        choose_pos();
        GetComponent<floatingObject>().originalY = 0.6f;
        this.transform.position = new Vector3 (row*2, this.transform.position.y, col*2);
        Debug.Log("Moved!");
    }

    void Start()
    {
        instance = this;
        HideCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideCoin()
    {
        GetComponent<floatingObject>().originalY = -0.5f;
        this.transform.position = new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.gameObject.GetComponent<Player>().spawn_start)
            {
                move_coin();
                Score.instance.addPoint();
                FindObjectOfType<AudioManager>().Play("snd_Coin");
            }
        }
    }
}
