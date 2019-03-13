using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitativeScale : Scale {

    /// <summary>
    /// Give intervals in format (min value of interval, name of interval)
    /// </summary>
    List<(int, string)> intervals = new List<(int, string)>();

    public QualitativeScale(GameObject myFill, string unit, int min, int max, List<(int,string)> intervals) : 
        base(myFill, unit, min, max)
    {
        this.intervals = intervals;
    }

    public QualitativeScale(GameObject myFill, string unit, int min, int max, int logNum, List<(int,string)> intervals) :
        base(myFill, unit, min, max, logNum)
    {
        this.intervals = intervals;
    }

    public override string GetLabel()
    {
        float myValue = GetValue();

        foreach((int, string) interval in intervals)
        {
            if(myValue > interval.Item1)
            {
                return (string.Format(interval.Item2) + " ({0:0.00}" + unit + ")");
            }
        }

        return "SCALE ERROR Intervals don't start a beggiging of range";

    }
   

    
}
