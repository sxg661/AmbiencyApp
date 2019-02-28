using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public struct SearchCriteria
{

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

    public List<string> types;

    public int? occupancy;

}