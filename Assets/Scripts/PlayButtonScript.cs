using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public string Level { get; set; }

    public void LoadScene()
    {
        ProgressScript progress = GameObject.Find("Progress").GetComponent<ProgressScript>();
        progress.CurrentLevel = Level;

        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Level 1");
    }
}
