using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConnectScript : MonoBehaviour
{

    [SerializeField]
    Text ipText;

    [SerializeField]
    Text portText;

    public static string ip;
    public static int port;


    public void Connect()
    {
       
        bool success = Int32.TryParse(portText.text, out port);

        
        if(!success)
        {
            Debug.Log("couldn't connect: #" + portText.text + "#");
            return;
        }

       

        ip = ipText.text;

        SceneManager.LoadScene("Scene"); 



        
    }
}
