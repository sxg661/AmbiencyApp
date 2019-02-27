using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueButtonController : MonoBehaviour
{

    [SerializeField]
    private Text nameText;


    public void ChangeName(string name)
    {
        nameText.text = name;
    }
    
}
