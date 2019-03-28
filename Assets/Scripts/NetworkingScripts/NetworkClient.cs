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

    private SocketWrapper wrapper;

    bool newResults = false;

    List<VenueInfo> results = new List<VenueInfo>();


    public void ReadInData()
    {
        Debug.Log("wooo");
        if (wrapper.DataToRead())
        {
            Debug.Log("Hello!!!");
            string command = wrapper.ReadLine();

            switch (command)
            {
                case "VENUE":
                    string venue = wrapper.ReadLine();
                    Debug.Log(venue);
                    break;
                default :
                    Debug.Log("Unknown command recieved from server: " + command);
                    break;
            }
        }
    }


    public NetworkClient()
    {
        
        port = 12345;
        // client = new TcpClient("localhost", port);
        client = new TcpClient("192.168.43.71", port);
        clientIn = new StreamReader(client.GetStream());
        clientOut = new StreamWriter(client.GetStream());

        wrapper = new SocketWrapper(clientIn, clientOut,client);
        wrapper.WriteLine("app");
        Debug.Log(wrapper.ReadLine());
      



    }

    private void addVenue(string venue)
    {
        string[] paramaters = venue.Split('|');
        Debug.Log(paramaters[5]);
        results.Add(new VenueInfo(
            paramaters[1], paramaters[2], float.Parse(paramaters[3]), float.Parse(paramaters[4])
            , float.Parse(paramaters[5]), float.Parse(paramaters[6]), float.Parse(paramaters[7]), float.Parse(paramaters[8])));
    }



    public override List<VenueInfo> RequestResults(SearchCriteria criteria)
    {
        results = new List<VenueInfo>();
        wrapper.WriteLine("SEARCH");
        wrapper.WriteLine(criteria.types[0]);

        bool running = true;
        while (running)
        {
            string command = wrapper.ReadLine();

            switch (command)
            {
                case "VENUE":
                    string newVenue = (wrapper.ReadLine());
                    Debug.Log("Recieved Venue: "+ newVenue);
                    addVenue(newVenue); ;
                    break;
                case "DISPLAY":
                    running = false;
                    break;
            }
        }

        results.Sort(CompareVenues);
        return results ;
    }

    public override void CloseConnection()
    {
        wrapper.WriteLine("DISCONNECT");
        Debug.Log(wrapper.ReadLine());



        clientIn.Close();
        clientOut.Close();
        client.Close();
    }
}