using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EmailScript : MonoBehaviour, IPointerDownHandler
{
    public string From { get; set; }
    public string Content { get; set; }
    public string Level { get; set; }
    private GameObject ui;
    private GameObject playButton;

    public void Initialize()
    {
        playButton = GameObject.Find("PlayButton");
        ui = GameObject.Find("Email_UI");

        Text fromText = GetComponent<Text>();
        fromText.text = From;

        Text contentText = transform.GetChild(0).GetComponentInChildren<Text>();
        contentText.text = Content;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ui.transform.Find("From").GetComponent<Text>().text = "From: " + From;
        ui.transform.Find("Content").GetComponent<Text>().text = Content;
        ui.transform.Find("FromLine").gameObject.SetActive(true);

        PlayClickNoise();

        if (Level == "")
        {
            playButton.SetActive(false);
        }
        else
        {
            playButton.SetActive(true);
            playButton.GetComponent<PlayButtonScript>().Level = Level;
            playButton.GetComponentInChildren<Text>().text = "Play " + Level;
        }
    }

    void PlayClickNoise() 
    {
        GameObject clickContainer = GameObject.Find("ClickContainer");
        int count = clickContainer.transform.childCount;
        int index = Random.Range(0, count);
        clickContainer.transform.GetChild(index).GetComponent<AudioSource>().Play();
    }
}
