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
        lightScale = new Scale(lightFill, "lux", 0, 5, 10);
        scales.Add((lightScale, lightText));

        temperatureScale = new Scale(temperatureFill, "oC", 10, 30);
        scales.Add((temperatureScale, temperatureText));

        soundScale = new Scale(soundFill, "dB", 0, 90);
        scales.Add((soundScale, soundText));

        occupancyScale = new Scale(occpuancyFill, "%", 0, 100);
        scales.Add((occupancyScale, OccupancyText));

        humidityScale = new Scale(humidityFill, "%", 0, 100);
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
