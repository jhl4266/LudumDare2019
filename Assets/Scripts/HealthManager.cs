using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    private DamageEffect damageScript;

    public int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
        slider.value = health;
        damageScript = slider.GetComponentInChildren<DamageEffect>();
    }

    void OnDamageTaken()
    {
        health--;
        slider.value = health;
        if (slider.minValue == health)
        {
            Debug.Log("Dead!");
        }

        damageScript.TakeDamage();
    }
}
