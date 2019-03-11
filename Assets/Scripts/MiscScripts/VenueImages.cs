using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueImages : MonoBehaviour
{
    [SerializeField]
    private Image genericBar;

    public Image getImage(string name)
    {
        return genericBar;
    }
}
