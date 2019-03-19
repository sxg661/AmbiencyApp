using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueImages : MonoBehaviour
{
    [SerializeField]
    private Image genericBar;

    [SerializeField]
    public Image bar1;

    [SerializeField]
    public Image bar2;

    public Image getImage(string name)
    {
        if (name.Equals("Kai's"))
            return bar2;

        else if (name.Equals("Beer Garden"))
            return bar1;
        return genericBar;
    }
}
