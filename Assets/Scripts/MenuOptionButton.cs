using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionButton : MonoBehaviour
{
    public GameObject container;
    public GameObject targetUI;

    public void OnPointerDown()
    {
        Debug.Log("Click!");
        int childCount = container.transform.childCount;
        for (int i = 0; i < childCount; i++) {
            Transform child = container.transform.GetChild(i);
            transform.gameObject.SetActive(false);
        }

        targetUI.SetActive(true);
    }
}
