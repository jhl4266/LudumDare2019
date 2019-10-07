using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateEmails : MonoBehaviour
{
    public GameObject email;
    private Vector3 emailPosition = new Vector3(-50, 50, 0);
    private ProgressScript progress;

    // Start is called before the first frame update
    void Start()
    {
        progress = GameObject.Find("Progress").GetComponent<ProgressScript>();

        if (progress.BeatLevelTwo)
        {
            MakeEmail("Mr. Bags", "Nice show last night! I think you have a few fans here now.");
        }

        if (progress.BeatLevelOne)
        {
            if (progress.LevelTwoLosses > 0)
            {
                MakeEmail("Mr. Agent", "You must have lost the few fans you got already!");
            }
            MakeEmail("Mr. Agent", "Looks like you're starting to get a following! I've got another show for you...", "Level 2");
            MakeEmail("Mr. Bags", "The show was better than last time, but not by much. It looks like one or two people may have actually liked it this time.");
        }
        
        if (progress.LevelOneLosses > 0)
        {
            MakeEmail("Mr. Agent", "That's no way to start a career! I knew this would happen...");
        }
        MakeEmail("Mr. Agent", "Hey Juke, I know you've had no luck making any fans, but how about a gig?", "Level 1");
        MakeEmail("Mr. Bags", "You're really bad at DJing! Please don't ask again...");

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
