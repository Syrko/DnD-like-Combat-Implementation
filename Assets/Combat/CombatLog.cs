using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLog : MonoBehaviour
{
    private static Queue<string> messageQueue;

    void Awake()
    {
        messageQueue = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        while(messageQueue.Count > 0)
        {
            string msg = messageQueue.Dequeue();
            // TODO print msg
        }
    }

    internal static void AddMessageToQueue(string msg)
    {
        messageQueue.Enqueue(msg);
    }
}
