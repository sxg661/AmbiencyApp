using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeButtonController : MonoBehaviour
{
    [SerializeField]
    private Text venueType;

    public void Click()
    {
        SearchCriteria.criteria = new SearchCriteria(new List<string>{ venueType.text });
    }
}
