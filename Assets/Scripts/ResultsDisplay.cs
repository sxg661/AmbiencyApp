using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{

    //this is easy to access from anywhere within the code
    public static ResultsDisplay mainResultDisplay;

    List<VenueInfo> results = new List<VenueInfo>();


    private VenueImages venueImages;
    

    [SerializeField]
    private GameObject buttonPrefab;



    private void Awake()
    {
        venueImages = gameObject.GetComponent<VenueImages>();
        results.Add(new VenueInfo("Joe's Bar", "Bar", 50, 0));
        results.Add(new VenueInfo("James's Cafe", "Restaurant", 90, 0.5f));
        results.Add(new VenueInfo("Sophie's Super Disco", "Club", 100, 0.7f));
        results.Add(new VenueInfo("Kai's Bar", "Bar", 100, 0.7f));
        results.Add(new VenueInfo("Thomas's Jazz Club", "Club", 10, 1f));
        results.Add(new VenueInfo("Kat's Sushi Bar", "Restuarant", 50, 1.4f));
        results.Add(new VenueInfo("Kareoke Bar", "Bar", 40, 2f));
        for(int i = 0; i < 10; i++)
        {
            results.Add(new VenueInfo("Bar "+i, "Bar", i*10, 2f+i));
        }
        mainResultDisplay = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(VenueInfo result in results)
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.LoadVenue(result, venueImages.getImage(result.name));
        }
    }
}
