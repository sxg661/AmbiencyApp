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
        results.Add(new VenueInfo("Joe's Bar", "Bar", 50, 0, 50, 1000, 23, 60));
        results.Add(new VenueInfo("James's Cafe", "Restaurant", 90, 0.5f, 80, 900, 26, 80));
        results.Add(new VenueInfo("Sophie's Super Disco", "Club", 100, 0.7f, 90, 100, 30, 95));
        results.Add(new VenueInfo("Kai's", "Bar", 95, 0.3f, 90, 100, 25, 80));
        results.Add(new VenueInfo("Thomas's Jazz Club", "Club", 70, 1f, 40, 700, 21, 110));
        results.Add(new VenueInfo("Kat's Sushi Bar", "Restaurant", 13, 0.1f, 30, 3000, 18, 40));
        results.Add(new VenueInfo("Beer Garden", "Bar", 40, 2f, 50, 1000, 21, 70));
        results.Add(new VenueInfo("Study Library", "Library", 40, 1, 50, 10000, 19, 40));
        results.Add(new VenueInfo("Bad Libary", "Library", 90, 1, 80, 1000, 13, 70));
        for (int i = 0; i < 10; i++)
        {
            results.Add(new VenueInfo("Bar " + i, "Bar", i * 10, 2f + i, 50, 1000, 25, 70 ));
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