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

    private Queue<string> inQueue;
    private int queueSize = 0;

    public SocketWrapper(StreamReader inStream, StreamWriter outStream, TcpClient client)
    {
        this.inStream = inStream;
        this.outStream = outStream;
        this.client = client;
        inQueue = new Queue<string>();
        outStream.NewLine = "||";
    }


    public void AddMessages(string message)
    {
         //Debug.Log(message);
        string currentMessage = "";

        bool inNewLine = false;

        foreach (char c in message)
        {
            if (c == '|' && !inNewLine)
            {
                inNewLine = true;
            }
            else if (c == '|' && inNewLine)
            {
                inNewLine = false;
                inQueue.Enqueue(leftover + currentMessage);
                queueSize++;
                leftover = "";
                currentMessage = "";
            }
            else if (c != '|' && inNewLine)
            {
                inNewLine = false;
                currentMessage = currentMessage + '|' + c;
            }
            else
            {
                currentMessage = currentMessage + c;
            }
        }

        if (currentMessage != "")
        {
            leftover = leftover + currentMessage;
        }
    }


    private void RefillQueue()
    {

        string messages = inStream.ReadLine();

        if(messages != null)
        {

            inQueue.Enqueue(messages);
            queueSize++;
        }




    }

    public string ReadLine()
    {
        /*
        if (inStream.Peek() >= 0)
        {
            throw new Exception("Error: no data to read from client");
        }*/
        string retValue;
        
        while (queueSize == 0)
        {
            RefillQueue();
            
        }


        timeSinceFirstAttempt = 0f;

        retValue = inQueue.Dequeue();
        queueSize--;


        return retValue;
    }

    public void WriteLine(string line)
    {
        outStream.WriteLine(line);
        outStream.Flush();
    }



}