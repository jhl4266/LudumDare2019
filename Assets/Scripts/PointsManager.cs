using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Slider slider;

    private int points = 0;

    void OnPointGet() {
        points++;
        slider.value = points;
        if (slider.maxValue == points) {
            Debug.Log("Win!");
        }
    }
}
