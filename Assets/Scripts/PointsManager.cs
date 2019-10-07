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

    private AudioSource audio;
    public AudioClip pointAudio;
    public AudioClip winAudio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        progress = GameObject.Find("Progress").GetComponent<ProgressScript>();
    }

    void OnPointGet() {
        audio.clip = pointAudio;
        audio.Play();

        points++;
        slider.value = points;
        if (slider.maxValue == points) 
        {
            AudioSource progressAudio = progress.GetComponent<AudioSource>();
            progressAudio.clip = winAudio;
            progressAudio.Play();

            if (progress.CurrentLevel == "Level 2") 
            {
                progress.FirstLoad = false;
                progress.WonLastGame = true;
                progress.BeatLevelTwo = true;
            }
            else 
            {
                progress.FirstLoad = false;
                progress.WonLastGame = true;
                progress.BeatLevelOne = true;
            }
            SceneManager.LoadScene("Bedroom");
        }
    }
}
