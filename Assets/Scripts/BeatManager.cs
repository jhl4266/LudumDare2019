using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public float bpm;
    private float timePerAction;
    private float counter = 0;

    public AudioSource audio;
    public AudioClip levelTwoSong;

    // Start is called before the first frame update
    void Start()
    {
        timePerAction = 60.0f / bpm;
        ProgressScript progress = GameObject.Find("Progress").GetComponent<ProgressScript>();
        if (progress.CurrentLevel == "Level 2") 
        {
            bpm = 120;
            audio.clip = levelTwoSong;
        }
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timePerAction)
        {
            counter -= timePerAction;
            gameObject.BroadcastMessage("OnNewBeat");
        }
        gameObject.BroadcastMessage("BeatUpdate", counter / timePerAction);
    }
}
