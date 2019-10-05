using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    private Image image;

    private float counter = 0;
    private Color red;
    private Color white;

    void Start()
    {
        image = GetComponent<Image>();
        red = new Color(1.0f, 0, 0, 1.0f);
        white = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                counter = 0;
            }

            image.color = Color.Lerp(white, red, counter);
        }
    }

    public void TakeDamage()
    {
        counter = 1.0f;
    }
}
