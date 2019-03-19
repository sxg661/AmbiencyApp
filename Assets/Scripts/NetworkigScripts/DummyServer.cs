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
        results.Add(new VenueInfo("Study Library", "Library", 40, 1, 50, 10000, 19, 40));
        results.Add(new VenueInfo("Bad Libary", "Library", 90, 1, 80, 1000, 13, 70));
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

        //all the factors add a value in the range 0-20 to the score

        if(criteria.occupancy.HasValue)
        {
            venue1Score += Mathf.Abs((venue1.occupancy - criteria.occupancy.Value))/5 ;
            venue2Score += Mathf.Abs((venue2.occupancy - criteria.occupancy.Value))/5 ;
        }

        if (criteria.light.HasValue)
        {
            float exponent = Mathf.Log(criteria.light.Value) / Mathf.Log(10);
            float exponent1 = Mathf.Log(venue1.light) / Mathf.Log(10);
            float expoenent2 = Mathf.Log(venue2.light) / Mathf.Log(10);
            venue1Score += Mathf.Abs(exponent - exponent1) * 4;
            venue2Score += Mathf.Abs(exponent - expoenent2) * 4;
        }

        if (criteria.sound.HasValue)
        {
            venue1Score += Mathf.Abs((venue1.sound - criteria.sound.Value)) / 4.5f;
            venue2Score += Mathf.Abs((venue2.sound - criteria.sound.Value)) / 4.5f;
        }

        if (criteria.humidity.HasValue)
        {
            venue1Score += Mathf.Abs((venue1.humidity - criteria.humidity.Value)) / 5;
            venue2Score += Mathf.Abs((venue2.humidity - criteria.humidity.Value)) / 5;
        }

        if (criteria.temperature.HasValue)
        {
            venue1Score += Mathf.Abs((venue1.temperature - criteria.temperature.Value));
            venue1Score += Mathf.Abs((venue2.temperature - criteria.temperature.Value));
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