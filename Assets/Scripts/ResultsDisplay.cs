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

        foreach(VenueInfo result in DummyServer.server.getResults(SearchCriteria.criteria))
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.LoadVenue(result, venueImages.getImage(result.name));
        }
    }
}
