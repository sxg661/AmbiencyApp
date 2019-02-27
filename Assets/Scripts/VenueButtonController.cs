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

    [SerializeField]
    private Text occupancyText;

    [SerializeField]
    private Text distText;




    public void LoadVenue(VenueInfo venue, Image venueImage)
    {
        nameText.text = venue.name;
        typeText.text = venue.type;
        occupancyText.text = venue.occupancy + "%";
        distText.text = string.Format("{0:0.0}m", venue.dist);
        this.venueImage.sprite = venueImage.sprite;
        

    }


   
    
}
