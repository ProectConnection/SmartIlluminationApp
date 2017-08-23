using UnityEngine;
using System.Collections;

public class ScoreObject{

    static int Score;
    static public int score
    {
        get
        {
            return Score;
        }
    }

    static public void AddScore()
    {
        Score += 1;
    }

    static public void ResetScore()
    {
        Score = 0;
    }
}
