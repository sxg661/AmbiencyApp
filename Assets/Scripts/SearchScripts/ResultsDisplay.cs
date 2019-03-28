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


       

    }

    private void Awake()
    {
        venueImages = gameObject.GetComponent<VenueImages>();
        myClient = new NetworkClient();

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
        foreach (VenueInfo result in myClient.RequestResults(SearchCriteria.criteria))
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            VenueButtonController venueController = newObj.GetComponent<VenueButtonController>();
            venueController.LoadVenue(result, venueImages.getImage(result.name));
            renderedButtons.Add(newObj);
        }


    }

    public void OnApplicationQuit()
    {
        myClient.CloseConnection();
    }


}
