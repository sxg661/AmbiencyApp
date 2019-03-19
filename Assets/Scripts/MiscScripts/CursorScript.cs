using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour
{
    [SerializeField]
    private Texture2D newCursor;

    // Use this for initialization
    void Start()
    {
        CursorMode mode = CursorMode.ForceSoftware;
        //Set Cursor to not be visible
        Cursor.SetCursor(newCursor, new Vector2(newCursor.width / 4, newCursor.height/4),mode);
        //Cursor.visible = false;
    }


}

