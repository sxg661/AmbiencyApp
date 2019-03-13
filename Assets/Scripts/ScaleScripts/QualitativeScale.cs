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

        for(int i = 0; i < intervals.Count; i++)
        {
            if(i == intervals.Count - 1)
            {
                return intervals[i].Item2;
            }

            if(myValue >= intervals[i].Item1 && myValue < intervals[i + 1].Item1)
            {
                return intervals[i].Item2;
            }


        }

        return "ERROR";


    }
   

    
}
