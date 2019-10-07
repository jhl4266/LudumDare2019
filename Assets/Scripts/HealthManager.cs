using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    private DamageEffect damageScript;

    public int maxHealth;
    private int health;

    private ProgressScript progress;

    private AudioSource audio;
    public AudioClip damageAudio;
    public AudioClip loseAudio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        damageScript = slider.GetComponentInChildren<DamageEffect>();
        progress = GameObject.Find("Progress").GetComponent<ProgressScript>();
    }

    void OnDamageTaken()
    {
        audio.clip = damageAudio;
        audio.Play();

        health--;
        slider.value = health;
        if (slider.minValue == health)
        {
            AudioSource progressAudio = progress.GetComponent<AudioSource>();
            progressAudio.clip = loseAudio;
            progressAudio.Play();

            if (progress.CurrentLevel == "Level 2")
            {
                progress.FirstLoad = false;
                progress.WonLastGame = false;
                progress.LevelTwoLosses++;
            }
            else
            {
                progress.FirstLoad = false;
                progress.WonLastGame = false;
                progress.LevelOneLosses++;
            }
            SceneManager.LoadScene("Bedroom");
        }

        damageScript.TakeDamage();
    }
}
