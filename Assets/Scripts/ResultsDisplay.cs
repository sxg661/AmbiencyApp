using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{
    List<VenueInfo> results = new List<VenueInfo>();
    

    [SerializeField]
    private GameObject buttonPrefab;



    private void Awake()
    {
        results.Add(new VenueInfo("Joe's Bar"));
        results.Add(new VenueInfo("James's Bar"));
        results.Add(new VenueInfo("Sophie's Bar"));
        results.Add(new VenueInfo("Kai's Bar"));
        results.Add(new VenueInfo("Thomas's Bar"));
        results.Add(new VenueInfo("Kat's Bar"));
        results.Add(new VenueInfo("Kareoke Bar"));
        for(int i = 0; i < 10; i++)
        {
            results.Add(new VenueInfo("Bar "+i));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(VenueInfo result in results)
        {
            GameObject newObj = Instantiate(buttonPrefab, transform, false);
            newObj.name = result.name;
            newObj.GetComponent<VenueButtonController>().ChangeName(result.name);
        }
    }
}
