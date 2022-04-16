using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Position_row, Position_col;
    public float Position_amp, jump;
    public Transform player;
    public bool gameOver = false;
    public Material deadMat;
    public Material normalMat;

    public GameObject body;
    public GameObject head;
    public GameObject enemy_spawner;

    public bool spawn_start;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -20.0F, 0);
        spawn_start = false;
    }

    void player_move()
    {
        if(!gameOver)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.position = new Vector3(Position_amp * Position_row, jump, Position_amp * Position_col);
            player.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Position_col < 1)
        {
            Position_col++;
            player_move();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Position_col > -1)
        {
            Position_col--;
            player_move();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Position_row < 1)
        {
            Position_row++;
            player_move();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Position_row > -1)
        {
            Position_row--;
            player_move();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(!gameOver && !spawn_start)
            {
                spawn_start = true;
                enemy_spawner.GetComponent<EnemySpawner>().Invoke("spawn_start", 0);
                Score.instance.resetScore();
                Coin.instance.enabled = true;
            }
        }
    }
    void player_reset()
    {
        gameOver = false;
        Position_row = Position_col = 0;
        body.GetComponent<Renderer>().material = normalMat;
        head.GetComponent<Renderer>().material = normalMat;
        player_move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        if (collision.gameObject.tag == "Enemy")
        {
            if(!gameOver)
            {
                Invoke("player_reset", 3f);
                gameOver = true;
                spawn_start = false;
                body.GetComponent<Renderer>().material = deadMat;
                head.GetComponent<Renderer>().material = deadMat;
                enemy_spawner.GetComponent<EnemySpawner>().Invoke("spawn_reset", 0);
                Coin.instance.enabled = false;
            }
        }
    }
}
