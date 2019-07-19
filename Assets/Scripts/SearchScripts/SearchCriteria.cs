using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class SearchCriteria
{

    public List<string> types;

    public float occupancy;

    public float light;

    public float humidity;

    public float temperature;

    public float sound;

    public static SearchCriteria criteria = new SearchCriteria();

    public SearchCriteria()
    {
        this.types = new List<String>(); ;
       
    }

    public SearchCriteria(List<String> types)
    {
        this.types = types;
        
    }


    public void AddFilteredsearch(float occ, float light, float humid, float temp, float sound)
    {
        occupancy = occ;
        this.light = light;
        humidity = humid;
        temperature = temp;
        this.sound = sound;
    }

    

}