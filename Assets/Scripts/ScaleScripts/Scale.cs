using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale { 

    public enum ScaleType { LINEAR, LOGARITHMIC}

    protected ScaleType myType;

    protected GameObject myFill;

    protected string unit;

    protected int min;

    protected int max;

    protected int logNum;

    protected int scaleMax;


    public Scale(GameObject myFill, string unit, int min, int max, int scaleMax)
    {
        myType = ScaleType.LINEAR;
        this.myFill = myFill;
        this.unit = unit;
        this.min = min;
        this.max = max;
        this.scaleMax = scaleMax;

        myFill.GetComponent<Slider>().maxValue = scaleMax;


    }

    public Scale(GameObject myFill, string unit, int min, int max, int scaleMax, int logNum)
    {
        myType = ScaleType.LOGARITHMIC;
        this.myFill = myFill;
        this.unit = unit;
        this.min = min;
        this.max = max;
        this.logNum = logNum;
        this.scaleMax = scaleMax;

        myFill.GetComponent<Slider>().maxValue = scaleMax;
    }

    public virtual string GetLabel()
    {
        return string.Format("{0:0}" + unit, GetValue());
    }

    public void ResetBar()
    {
        myFill.GetComponent<Slider>().value = 0;
    }

    public float GetValue()
    {
        float scaleValue = myFill.GetComponent<Slider>().value/ scaleMax;

        switch (myType)
        {
            case ScaleType.LOGARITHMIC:
                float exponent = min + scaleValue * (max - min);
                return (Mathf.Pow(logNum, exponent));
            case ScaleType.LINEAR:
                return (min + scaleValue * (max - min));
            default:
                return 0;

        }
    }

    public void setScalePos(float value)
    {
        Mathf.Clamp(value, min, max);

        switch (myType)
        {
            case ScaleType.LOGARITHMIC:
                float exponent = Mathf.Log(value) / Mathf.Log(10);
                myFill.GetComponent<Slider>().value = ((exponent - min) / (max - min)) * scaleMax;
                break;
            case ScaleType.LINEAR:
                myFill.GetComponent<Slider>().value = ((value - min) / (max - min)) * scaleMax;
                break;
            default:
                ResetBar();
                break;
                
        }
        
    }
   

    
}
