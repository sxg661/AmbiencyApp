using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public abstract class Client
{

    protected static Client client;

    List<VenueInfo> results = new List<VenueInfo>();

    private int socket;

    protected SearchCriteria criteria = new SearchCriteria();


    public abstract bool NewResults();

    public abstract List<VenueInfo> GetResults();

    public abstract void RequestResults(SearchCriteria criteria);
    

    public List<VenueInfo> filter(List<VenueInfo> venues)
    {
        List<VenueInfo> newVenues = new List<VenueInfo>();
        foreach (VenueInfo venue in venues)
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

        Debug.Log(criteria);
        foreach (string type in criteria.types)
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

        if (criteria.occupancy.HasValue)
        {
            venue1Score += Mathf.Abs((venue1.occupancy - criteria.occupancy.Value)) / 5;
            venue2Score += Mathf.Abs((venue2.occupancy - criteria.occupancy.Value)) / 5;
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

        venue1Score += venue1.dist * 2;
        venue2Score += venue2.dist * 2;

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