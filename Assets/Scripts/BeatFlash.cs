﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatFlash : MonoBehaviour
{
    private Image image;

    public Color color1;
    public Color color2;

    private float lastPercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    void BeatUpdate(float percentage) {
        bool isNewBeat = percentage < lastPercentage;
        lastPercentage = percentage;

        if (isNewBeat)
        {
            if (image.color == color1)
            {
                image.color = color2;
            }
            else
            {
                image.color = color1;
            }
        }
    }
}
