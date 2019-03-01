using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public struct SearchCriteria
{

    public static SearchCriteria criteria = new SearchCriteria();

    public SearchCriteria(List<String> types, int occupancy)
    {
        this.types = types;
        this.occupancy = occupancy;
    }

    public SearchCriteria(List<String> types)
    {
        this.types = types;
        occupancy = null;
    }

    public void AddOccupancy(int occupancy)
    {
        this.occupancy = occupancy;
    }

    public List<string> types;

    public int? occupancy;

}