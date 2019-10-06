using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionButton : MonoBehaviour
{
    public GameObject buttonsContainer;
    public GameObject container;
    public GameObject targetUI;

    public void OnPointerDown()
    {
        ChangeUIs();
        ChangeButtons();
    }

    void ChangeUIs() {
        int childCount = container.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = container.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
        targetUI.SetActive(true);
    }

    void ChangeButtons() {
        int childCount = buttonsContainer.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Image childImage = buttonsContainer.transform.GetChild(i).GetComponent<Image>();
            childImage.color = Color.white;
            childImage.transform.GetComponentInChildren<Text>().color = Color.black;
        }

        Image image = GetComponent<Image>();
        image.color = Color.black;
        image.transform.GetComponentInChildren<Text>().color = Color.white;
    }
}
