using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private void Start()
    {
        ProgressScript progress = GameObject.Find("Progress").GetComponent<ProgressScript>();

        if (!progress.FirstLoad)
        {
            GetComponent<CameraMove>().enabled = true;
            Destroy(gameObject.transform.GetChild(0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<CameraMove>().enabled = true;
            Destroy(gameObject.transform.GetChild(0));
        }
    }
}
