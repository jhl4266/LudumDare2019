using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public GameObject start;
    public GameObject end;

    public float time;
    public float rate;
    private float counter;

    private Transform tStart;
    private Transform tEnd;

    public GameObject screenOff;
    public GameObject emailUI;

    // Start is called before the first frame update
    void Start()
    {
        tStart = start.transform;
        tEnd = end.transform;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > time) {
            counter = time;
        }

        float percentage = Mathf.Pow(counter, rate) / Mathf.Pow(time, rate);
        transform.position = Vector3.Lerp(tStart.position, tEnd.position, percentage);
        transform.rotation = Quaternion.Lerp(tStart.rotation, tEnd.rotation, percentage);

        if (counter == time) {
            screenOff.GetComponent<Image>().enabled = false;
            emailUI.SetActive(true);
            Destroy(this);
        }
    }
}
