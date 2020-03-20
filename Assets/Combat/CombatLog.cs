using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple class with a static message queue.
/// Messages can be stored from wherever in the code and later instances of the class may appropriately display them
/// in each frame as they become available (e.g through Unity canvas)
/// </summary>
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
