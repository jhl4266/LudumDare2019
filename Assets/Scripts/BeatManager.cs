using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public int bpm;
    private float timePerAction;
    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        timePerAction = 60.0f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timePerAction)
        {
            counter -= timePerAction;
        }
        gameObject.BroadcastMessage("BeatUpdate", counter / timePerAction);
    }
}
