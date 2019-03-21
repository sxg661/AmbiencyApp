using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{

    private List<GameObject> renderedButtons = new List<GameObject>();

    private VenueImages venueImages;

    private Client myClient;
    

    [SerializeField]
    private GameObject buttonPrefab;

    private void Update()
    {
        if (!myClient.NewResults())
        {
            return;
        }

        ClearResults();
        foreach (VenueInfo result in myClient.GetResults())
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.LoadVenue(result, venueImages.getImage(result.name));
            renderedButtons.Add(newObj);
        }
    }

    private void Awake()
    {
        venueImages = gameObject.GetComponent<VenueImages>();
        myClient = new DummyClient();

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

        myClient.RequestResults(SearchCriteria.criteria);

       
    }


}
