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

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        damageScript = slider.GetComponentInChildren<DamageEffect>();
        progress = GameObject.Find("Progress").GetComponent<ProgressScript>();
    }

    void OnDamageTaken()
    {
        health--;
        slider.value = health;
        if (slider.minValue == health)
        {
            progress.FirstLoad = false;
            progress.WonLastGame = false;
            progress.LevelOneLosses++;
            SceneManager.LoadScene("Bedroom");
        }

        damageScript.TakeDamage();
    }
}
