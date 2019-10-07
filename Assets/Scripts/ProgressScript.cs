using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{
    public string CurrentLevel { get; set; }

    public bool FirstLoad { get; set; }
    public bool WonLastGame { get; set; }

    public int LevelOneLosses { get; set; }
    public bool BeatLevelOne { get; set; }

    public int LevelTwoLosses { get; set; }
    public bool BeatLevelTwo { get; set; }

    public int LevelThreeLosses { get; set; }
    public bool BeatLevelThree { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        FirstLoad = true;
        WonLastGame = false;

        LevelOneLosses = 0;
        LevelTwoLosses = 0;
        LevelThreeLosses = 0;

        BeatLevelOne = false;
        BeatLevelTwo = false;
        BeatLevelThree = false;

        DontDestroyOnLoad(gameObject);
    }
}
