using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPopupController : MonoBehaviour
{

    public static SearchPopupController controller;

    [SerializeField]
    Text venueTypeText;

    public void Awake()
    {
        controller = this;
    }

    public void Appear(string name)
    {
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        venueTypeText.text = name;
    }

    public void Disappear()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(1500, 0, 0);
    }
}
