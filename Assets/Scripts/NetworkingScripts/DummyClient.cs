using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class DummyClient : Client
{

    List<VenueInfo> results = new List<VenueInfo>();

    bool changed;


    public DummyClient()
    {
        results.Add(new VenueInfo("Joe's Bar", "Bar", 50, 50, 1000, 23, 60, 0));
        results.Add(new VenueInfo("James's Cafe", "Restaurant", 90, 80, 900, 26, 80, 0.5f));
        results.Add(new VenueInfo("Sophie's Super Disco", "Club", 100, 90, 100, 30, 95, 0.7f));
        results.Add(new VenueInfo("Kai's", "Bar", 95, 90, 100, 25, 80, 0.3f));
        results.Add(new VenueInfo("Thomas's Jazz Club", "Club", 70, 40, 700, 21, 110, 1f));
        results.Add(new VenueInfo("Kat's Sushi Bar", "Restaurant", 13, 30, 3000, 18, 40, 0.1f));
        results.Add(new VenueInfo("Beer Garden", "Bar", 40, 50, 1000, 21, 70, 2f));
        results.Add(new VenueInfo("Study Library", "Library", 40, 50, 10000, 19, 40, 1f));
        results.Add(new VenueInfo("Bad Libary", "Library", 90, 80, 1000, 13, 70, 1f));
        for (int i = 0; i < 10; i++)
        {
            results.Add(new VenueInfo("Bar " + i, "Bar", i * 10, 50, 1000, 25, 70, 2f + i));
        }
    }




    public override List<VenueInfo> RequestResults(SearchCriteria criteria)
    {
        //in a real client the network call would be made HERE
        this.criteria = criteria;
        List<VenueInfo> newResults = filter(results);
        newResults.Sort(CompareVenues);
        return newResults;
    }

 
    public override void CloseConnection()
    {
        Debug.Log("Disconnected");
    }

    //DO THREAD STUFF HERE I WILL LEARN HOW TO DO THIS...



}