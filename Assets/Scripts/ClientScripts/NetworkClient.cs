using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class NetworkClient : Client
{

    List<VenueInfo> results = new List<VenueInfo>();


    public NetworkClient(int socket) : base(socket)
    {
        
    }


    public override List<VenueInfo> GetResults()
    {
        throw new NotImplementedException();
    }

    public override bool NewResults()
    {
        throw new NotImplementedException();
    }

    public override void RequestResults(SearchCriteria criteria)
    {
        throw new NotImplementedException();
    }
}