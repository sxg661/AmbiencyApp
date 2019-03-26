using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

public class NetworkClient : Client
{
    private int port;


    private TcpClient client;
    private StreamReader clientIn;
    private StreamWriter clientOut;

    bool newResults = false;

    List<VenueInfo> results = new List<VenueInfo>();

    public static void RecievingThread()
    {
        Console.WriteLine("Child thread starts");
    }


    public NetworkClient()
    {
        
        port = 12345;
        client = new TcpClient("localhost", port);
        clientIn = new StreamReader(client.GetStream());
        clientOut = new StreamWriter(client.GetStream());

        SocketWrapper clientWrapper = new SocketWrapper(clientIn, clientOut,client);
        //clientWrapper.AddMessages("hello\nthere\n\nmy name is ron\n\n");

        
        clientWrapper.WriteLine("app");
        Debug.Log("read: "+clientWrapper.ReadLine());
        
        //string messages = clientIn.ReadLine();
        //Debug.Log(messages);

        
        clientWrapper.WriteLine("money, please");
        Debug.Log("read: " + clientWrapper.ReadLine());

        clientWrapper.WriteLine("SEARCH");
        clientWrapper.WriteLine("Bar");

        Debug.Log("read: " + clientWrapper.ReadLine());
        Debug.Log("read: " + clientWrapper.ReadLine());
        Debug.Log("read: " + clientWrapper.ReadLine());

        clientWrapper.WriteLine("DISCONNECT");
        Debug.Log("read: " + clientWrapper.ReadLine());



        clientIn.Close();
        clientOut.Close();
        client.Close();

    }


    public override List<VenueInfo> GetResults()
    {
        return new List<VenueInfo>();
    }

    public override bool NewResults()
    {
        if (newResults)
        {
            newResults = false;
            return true;
        }

        return false;
    }

    public override void RequestResults(SearchCriteria criteria)
    {
        return;
    }
}