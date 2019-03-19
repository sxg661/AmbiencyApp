using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{

    [SerializeField]
    GameObject venuePic;
    Image venueImage;

    [SerializeField]
    GameObject nameText;

    [SerializeField]
    GameObject distText;

    [SerializeField]
    GameObject lightFill;

    [SerializeField]
    GameObject tempFill;

    [SerializeField]
    GameObject soundFill;

    [SerializeField]
    GameObject occFill;

    [SerializeField]
    GameObject humidFill;




    public void LoadVenue(VenueInfo venue, Image venueImage)
    {
        Scale lightScale = new Scale(lightFill, "", 0, 5, 10);
        lightScale.setScalePos(venue.light);

        Scale tempScale = new Scale(tempFill, "", 10, 30);
        tempScale.setScalePos(venue.temperature);

        Scale soundScale = new Scale(soundFill, "", 0, 90);
        soundScale.setScalePos(venue.sound);

        Scale occScale = new Scale(occFill, "", 0, 100);
        occScale.setScalePos(venue.occupancy);

        Scale humidScale = new Scale(humidFill, "", 0, 100);
        humidScale.setScalePos(venue.humidity);

        nameText.GetComponent<Text>().text = venue.name;

        distText.GetComponent<Text>().text = string.Format("{0:0.0}m", venue.dist);

        this.venueImage = venuePic.GetComponent<Image>();

        this.venueImage.sprite = venueImage.sprite;

        Appear();

    }

    public void Dissapear()
    {

        GetComponent<RectTransform>().localPosition = new Vector3(50000, 50000, 0);
    }

    public void Appear()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }
    
}
