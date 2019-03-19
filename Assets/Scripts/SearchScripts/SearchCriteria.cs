using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public struct SearchCriteria
{

    public static SearchCriteria criteria = new SearchCriteria();


    public SearchCriteria(List<String> types)
    {
        this.types = types;
        occupancy = null;
        light = null;
        humidity = null;
        temperature = null;
        sound = null;
    }


    public void AddFilteredsearch(float occ, float light, float humid, float temp, float sound)
    {
        occupancy = occ;
        this.light = light;
        humidity = humid;
        temperature = temp;
        this.sound = sound;
    }

    public List<string> types;

    public float? occupancy;

    public float? light;

    public float? humidity;

    public float? temperature;

    public float? sound;

}