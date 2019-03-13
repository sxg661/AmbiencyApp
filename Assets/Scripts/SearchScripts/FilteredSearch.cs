using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteredSearch : MonoBehaviour
{
    private enum ScaleType { REGULAR, LOGARITHMIC}

    [SerializeField]
    private GameObject lightFill;
    private Scale lightScale;
    [SerializeField]
    private Text lightText;

    [SerializeField]
    private GameObject temperatureFill;
    private Scale temperatureScale;
    [SerializeField]
    private Text temperatureText;

    [SerializeField]
    private GameObject soundFill;
    private Scale soundScale;
    [SerializeField]
    private Text soundText;

    [SerializeField]
    private GameObject occpuancyFill;
    private Scale occupancyScale;
    [SerializeField]
    private Text OccupancyText;


    [SerializeField]
    private GameObject humidityFill;
    private Scale humidityScale;
    [SerializeField]
    private Text humiditiyText;

    private List<(Scale,Text)> scales = new List<(Scale,Text)>();
    


    private void Start()
    {
        lightScale = new QualitativeScale(lightFill, "lux", 0, 5, 10,
            new List<(int, string)> { (1, "Very Dark"),(10,"Dark"), (100, "Dim"), (1000, "Bright"), (10000, "Very Bright") });
        scales.Add((lightScale, lightText));

        temperatureScale = new QualitativeScale(temperatureFill, "oC", 10, 30,
            new List<(int, string)> { (10, "Cold"), (15, "Chilly"), (20, "Warm"), (25, "Hot") });
        scales.Add((temperatureScale, temperatureText));

        soundScale = new QualitativeScale(soundFill, "dB", 0, 90, 
            new List<(int, string)> { (0, "Silent"), (20, "Quiet"), (50, "Normal"), (70, "Noisy") });
        scales.Add((soundScale, soundText));

        occupancyScale = new QualitativeScale(occpuancyFill, "%", 0, 100,
            new List<(int, string)> { (0, "Empty"), (25, "Uncrowded"), (50, "Busy"), (75, "Packed") });
        scales.Add((occupancyScale, OccupancyText));

        humidityScale = new QualitativeScale(humidityFill, "%", 0, 100,
            new List<(int, string)> { (0, "Dry"), (30, "Normal"), (60, "Humid") });
        scales.Add((humidityScale, humiditiyText));

        

    }

    // Update is called once per frame
    void Update()
    {
       foreach((Scale,Text) scale in scales)
        {
            scale.Item2.text = scale.Item1.GetLabel();
        }
    }
}
