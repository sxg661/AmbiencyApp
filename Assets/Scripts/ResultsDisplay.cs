using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{



    private VenueImages venueImages;
    

    [SerializeField]
    private GameObject buttonPrefab;



    private void Awake()
    {
        venueImages = gameObject.GetComponent<VenueImages>();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        SearchCriteria searchCriteria = new SearchCriteria(new List<string> { "Club" , "Bar"}, 70);


        List<VenueInfo> results = DummyServer.server.getResults(searchCriteria);
        foreach(VenueInfo result in results)
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.LoadVenue(result, venueImages.getImage(result.name));
        }
    }
}
