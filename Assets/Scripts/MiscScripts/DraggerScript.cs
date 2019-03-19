using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggerScript : MonoBehaviour
{

    bool mouseHover = false;

    // Update is called once per frame
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("hey!");
    }

    private void OnMouseOver()
    {
        Debug.Log("hello!");
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("hello!");
        mouseHover = false;
    }
}
