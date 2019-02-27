using UnityEngine;
using System.Collections;

public class VenueInfo
{
    public string name;
    public string type;
    public int occupancy;  //percentage
    public int miles;

    public VenueInfo(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

}
