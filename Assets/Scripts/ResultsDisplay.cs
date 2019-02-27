using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{
    List<VenueInfo> results = new List<VenueInfo>();


    private VenueImages venueImages;
    

    [SerializeField]
    private GameObject buttonPrefab;



    private void Awake()
    {
        venueImages = gameObject.GetComponent<VenueImages>();
        results.Add(new VenueInfo("Joe's Bar", "Bar"));
        results.Add(new VenueInfo("James's Bar", "Bar"));
        results.Add(new VenueInfo("Sophie's Bar", "Bar"));
        results.Add(new VenueInfo("Kai's Bar", "Bar"));
        results.Add(new VenueInfo("Thomas's Bar", "Bar"));
        results.Add(new VenueInfo("Kat's Bar", "Bar"));
        results.Add(new VenueInfo("Kareoke Bar", "Bar"));
        for(int i = 0; i < 10; i++)
        {
            results.Add(new VenueInfo("Bar "+i, "Bar"));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(VenueInfo result in results)
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.SetImage(venueImages.getImage(result.name));
            venueController.ChangeName(result.name, result.type);
        }
    }
}
