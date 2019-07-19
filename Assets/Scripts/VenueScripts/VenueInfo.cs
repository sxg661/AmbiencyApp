using UnityEngine;
using System.Collections;

public class VenueInfo
{
    public string name;
    public string type;
    public float occupancy;  //percentage 0-100
    public float humidity;   //percentage 0-100 
    public float light;   //percentage 0-100000 lux (maybe have a useful graphic as Tom suggested for this)
    public float temperature;   //0 - 50 degrees c
    public float sound;    //0 - 100 dB
    public float dist;     //in mile format this to 2.d.p

    public VenueInfo(string name, string type, float occupancy, float humidity, float light, float temperature, float sound, float dist)
    {
        this.name = name;
        this.type = type;
        this.occupancy = occupancy;
        this.dist = dist;
        this.humidity = humidity;
        this.light = light;
        this.temperature = temperature;
        this.sound = sound;
    }

}
