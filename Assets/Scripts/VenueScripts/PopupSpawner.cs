using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSpawner : MonoBehaviour
{

    public static PopupSpawner spawner;

    public static GameObject popUp;

    [SerializeField]
    GameObject popupPrefab;

    [SerializeField]
    GameObject popupCanvas;


    private void Awake()
    {
        spawner = this;
        popUp = Instantiate(popupPrefab, popupCanvas.transform, false);
        killPopup();
    }

    public void spawnPopup(VenueInfo venue, Image venueImage)
    {
        if(popUp == null)
        {
            popUp = Instantiate(popupPrefab, popupCanvas.transform, false);
        }
        popUp.GetComponent<PopupController>().LoadVenue(venue, venueImage);
    }

    public void killPopup()
    {
        popUp.GetComponent<PopupController>().Dissapear();    
    }

    
    
}
