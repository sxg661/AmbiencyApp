﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale { 

    public enum ScaleType { LINEAR, LOGARITHMIC}

    protected ScaleType myType;

    protected GameObject myFill;

    protected string unit;

    protected int min;

    protected int max;

    protected int logNum;

    public Scale(GameObject myFill, string unit, int min, int max)
    {
        myType = ScaleType.LINEAR;
        this.myFill = myFill;
        this.unit = unit;
        this.min = min;
        this.max = max;
    }

    public Scale(GameObject myFill, string unit, int min, int max, int logNum)
    {
        myType = ScaleType.LOGARITHMIC;
        this.myFill = myFill;
        this.unit = unit;
        this.min = min;
        this.max = max;
        this.logNum = logNum;
    }

    public virtual string GetLabel()
    {
        return string.Format("{0:0}" + unit, GetValue());
    }

    public void ResetBar()
    {
        myFill.GetComponent<RectTransform>().anchorMax = new Vector2(0,0);
    }

    public float GetValue()
    {
        float scaleValue = myFill.GetComponent<RectTransform>().anchorMax.x;

        switch (myType)
        {
            case ScaleType.LOGARITHMIC:
                float exponent = min + scaleValue * (max - min);
                return Mathf.Pow(logNum, exponent);
            case ScaleType.LINEAR:
                return min + scaleValue * (max - min);
            default:
                return 0;

        }
    }
   

    
}
