using UnityEngine;
using UnityEditor;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System;

public class SocketWrapper
{
    private StreamReader inStream;
    private StreamWriter outStream;
    private TcpClient client;

    private string leftover;

    private float timeOutTime = 3f;
    private float timeSinceFirstAttempt = 0f;
    private int queueSize = 0;

    public SocketWrapper(StreamReader inStream, StreamWriter outStream, TcpClient client)
    {
        this.inStream = inStream;
        this.outStream = outStream;
        this.client = client;
        outStream.NewLine = "||";
    }


    public bool DataToRead()
    {
        Debug.Log("Peek " + inStream.Peek());
        return (inStream.Peek() >= 0);
    }

    public string ReadLine()
    { 
        return inStream.ReadLine();
    }

    public void WriteLine(string line)
    {
        outStream.WriteLine(line);
        outStream.Flush();
    }
}