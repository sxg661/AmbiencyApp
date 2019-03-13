using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class DummyServer
{

    public static DummyServer server = new DummyServer();

    List<VenueInfo> results = new List<VenueInfo>();

    private SearchCriteria criteria = new SearchCriteria();

    public DummyServer()
    {
        results.Add(new VenueInfo("Joe's Bar", "Bar", 50, 0, 50, 1000, 23, 60));
        results.Add(new VenueInfo("James's Cafe", "Restaurant", 90, 0.5f, 80, 900, 26, 80));
        results.Add(new VenueInfo("Sophie's Super Disco", "Club", 100, 0.7f, 90, 100, 30, 95));
        results.Add(new VenueInfo("Kai's", "Bar", 95, 0.3f, 90, 100, 25, 80));
        results.Add(new VenueInfo("Thomas's Jazz Club", "Club", 70, 1f, 40, 700, 21, 110));
        results.Add(new VenueInfo("Kat's Sushi Bar", "Restaurant", 13, 0.1f, 30, 3000, 18, 40));
        results.Add(new VenueInfo("Beer Garden", "Bar", 40, 2f, 50, 1000, 21, 70));
        for (int i = 0; i < 10; i++)
        {
            results.Add(new VenueInfo("Bar " + i, "Bar", i * 10, 2f + i, 50, 1000, 25, 70 ));
        }
    }

   

   

    public List<VenueInfo> getResults( SearchCriteria criteria)
    {
        this.criteria = criteria;
        List<VenueInfo> newResults = filter(results);
        newResults.Sort(CompareVenues);
        return newResults;
    }

    public List<VenueInfo> filter(List<VenueInfo> venues)
    {
        List<VenueInfo> newVenues = new List<VenueInfo>();
        foreach(VenueInfo venue in venues)
        {
            if (inclueInResult(venue))
            {
                newVenues.Add(venue);
            }
        }
        return newVenues;
    }

    public bool inclueInResult(VenueInfo venue)
    {
        foreach(string type in criteria.types)
        {
            if (type.Equals(venue.type))
            {
                return true;
            }
        }
        return false;
    }



    public int CompareVenues(VenueInfo venue1, VenueInfo venue2)
    {
        float venue1Score = 0;
        float venue2Score = 0;

        if(criteria.occupancy.HasValue)
        {
            Debug.Log(criteria.occupancy.Value);
            venue1Score += Math.Abs((venue1.occupancy - criteria.occupancy.Value)/5) ;
            venue2Score += Math.Abs((venue2.occupancy - criteria.occupancy.Value)/5) ;
        }

        venue1Score += venue1.dist;
        venue2Score += venue2.dist;

        if (venue1Score == venue2Score)
        {
            return 0;
        }
        else if (venue1Score > venue2Score)
        {
            return 1;
        }
        else return -1;


    }

}