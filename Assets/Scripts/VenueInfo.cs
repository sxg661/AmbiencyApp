using UnityEngine;
using System.Collections;

public class VenueInfo
{
    public string name;
    public string type;
    public int occupancy;  //percentagage 0-100
    public float dist;     //in mile format this to 2.d.p

    public VenueInfo(string name, string type, int occupancy, float dist)
    {
        this.name = name;
        this.type = type;
        this.occupancy = occupancy;
        this.dist = dist;
    }

}
