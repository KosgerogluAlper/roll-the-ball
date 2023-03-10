using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    private int score = 0;
}
