using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateEmails : MonoBehaviour
{
    public GameObject email;
    private Vector3 emailPosition = new Vector3(-50, -50, 0);
    private ProgressScript progress;

    // Start is called before the first frame update
    void Start()
    {
        progress = GameObject.Find("Progress").GetComponent<ProgressScript>();

        if (progress.BeatLevelOne)
        {
            if (progress.LevelTwoLosses > 0)
            {
                MakeEmail("Mrs. Important", "That show was terrible!");
            }
            MakeEmail("Mrs. Important", "How about a second gig?", "Level 2");
            MakeEmail("Mrs. Bags", "You're bad at DJing don't ask again...");
        }

        if (progress.LevelOneLosses > 0)
        {
            MakeEmail("Mr. Important", "That show was terrible!");
        }
        MakeEmail("Mr. Important", "How about a first gig?", "Level 1");
        MakeEmail("Mr. Bags", "You're bad at DJing don't ask again...");


        GameObject.Find("PlayButton").SetActive(false);
        GameObject.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value = 1.0f;
    }

    void MakeEmail(string newFrom, string newContent, string level = "")
    {
        GameObject newEmail = Instantiate(email, transform);
        EmailScript script = newEmail.GetComponentInChildren<EmailScript>();
        script.Level = level;

        if (level == "")
        {
            newEmail.transform.Find("Priority").gameObject.SetActive(false);
        }

        if (script)
        {
            script.From = newFrom;
            script.Content = newContent;
            script.Initialize();
        }

        newEmail.GetComponent<RectTransform>().anchoredPosition = emailPosition;
        emailPosition -= new Vector3(0, 60, 0);
    }
}
