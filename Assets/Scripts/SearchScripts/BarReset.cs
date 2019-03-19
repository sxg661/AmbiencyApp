using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarReset : MonoBehaviour
{
    [SerializeField]
    GameObject lightBar;

    [SerializeField]
    GameObject tempBar;

    [SerializeField]
    GameObject soundBar;

    [SerializeField]
    GameObject occBar;

    [SerializeField]
    GameObject humidBar;

    public void ResetBars()
    {
        lightBar.GetComponent<Slider>().value = 0;
        tempBar.GetComponent<Slider>().value = 0;
        soundBar.GetComponent<Slider>().value = 0;
        occBar.GetComponent<Slider>().value = 0;
        humidBar.GetComponent<Slider>().value = 0;
    }

}
