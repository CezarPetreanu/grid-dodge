using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoretext;
    static public Score instance;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoint()
    {
        points++;
        scoretext.text = Convert.ToString(points);
    }
    public void resetScore()
    {
        points = 0;
        scoretext.text = Convert.ToString(points);
    }
}
