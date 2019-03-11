using UnityEngine;
using System.Collections;

public class VenueInfo
{
    public string name;
    public string type;
    public int occupancy;  //percentage 0-100
    public int humidity;   //percentage 0-100 
    public int light;   //percentage 0-20000 lux (maybe have a useful graphic as Tom suggested for this)
    public int temperature;   //0 - 50 degrees c
    public int sound;    //0 - 100 dB
    public float dist;     //in mile format this to 2.d.p

    public VenueInfo(string name, string type, int occupancy, float dist, int humidity, int light, int temperature, int sound)
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
