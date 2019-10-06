using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public Slider slider;

    private int points = 0;

    private ProgressScript progress;

    void Start()
    {
        progress = GameObject.Find("Progress").GetComponent<ProgressScript>();
    }

    void OnPointGet() {
        points++;
        slider.value = points;
        if (slider.maxValue == points) 
        {
            progress.FirstLoad = false;
            progress.WonLastGame = true;
            progress.BeatLevelOne = true;
            SceneManager.LoadScene("Bedroom");
        }
    }
}
