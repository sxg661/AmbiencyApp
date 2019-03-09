using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{

    private List<GameObject> renderedButtons = new List<GameObject>();

    private VenueImages venueImages;
    

    [SerializeField]
    private GameObject buttonPrefab;



    private void Awake()
    {
        venueImages = gameObject.GetComponent<VenueImages>();
        

    }

    private void ClearResults()
    {
        foreach(GameObject button in renderedButtons)
        {
            Destroy(button);
        }
        renderedButtons = new List<GameObject>();
    }

    public void DisplayResults()
    {
        ClearResults();

        foreach(VenueInfo result in DummyServer.server.getResults(SearchCriteria.criteria))
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.LoadVenue(result, venueImages.getImage(result.name));
            renderedButtons.Add(newObj);
        }
    }
}
