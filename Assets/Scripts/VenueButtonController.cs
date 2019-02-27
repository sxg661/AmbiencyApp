using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueButtonController : MonoBehaviour
{

    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Image venueImage;

    [SerializeField]
    private Text typeText;


    public void ChangeName(string name, string type)
    {
        nameText.text = name;
        typeText.text = type;
    }

    public void SetImage(Image venueImage)
    {
        this.venueImage.sprite = venueImage.sprite;
    }
    
}
