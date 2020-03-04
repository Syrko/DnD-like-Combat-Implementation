using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatManager : MonoBehaviour
{
    private List<Character> combatQueue;
    private Character activeCharacter;

    /// <summary>
    /// Get all game objects that are tagged as combatants and put in a list their characterStats component
    /// in order to execute combat functions.
    /// </summary>
    private void Awake()
    {
        combatQueue = new List<Character>();
        var characters = GameObject.FindGameObjectsWithTag("Combatant");
        foreach(var character in characters)
        {
            combatQueue.Add(character.GetComponent<Character>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        combatQueue = combatQueue.OrderByDescending(combatant => combatant.Initiative).ToList();
        StartCoroutine(CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        int activeCharIndex = 0;
        while (true)
        {
            activeCharacter = combatQueue[activeCharIndex];
            if (activeCharacter.PlayerControlled)
            {
                // Detect if a move was input this frame or yield
                if (DetectInput())
                {
                    // TODO do action
                }
                else
                {
                    yield return null;
                    continue;
                }
            }
            else
            {
                // TODO choose move for the ai-controlled character
            }

            if (combatQueue.All(combatant => combatant.PlayerControlled))
            {
                EndCombat(true);
                break;
            }
            else if (combatQueue.All(combatant => combatant.PlayerControlled == false))
            {
                EndCombat(false);
                break;
            }
            else
            {
                activeCharIndex = (activeCharIndex + 1) % combatQueue.Count(); // Go through the list, rotating between the combatants
            }
        }
    }

    bool DetectInput()
    {
        throw new NotImplementedException();
    }

    void EndCombat(bool victory)
    {
        throw new NotImplementedException();
    }
}
