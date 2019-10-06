using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public string Level { get; set; }

    public void LoadScene()
    {
        SceneManager.LoadScene(Level);
    }
}
