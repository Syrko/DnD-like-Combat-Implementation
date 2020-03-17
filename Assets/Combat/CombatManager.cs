using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Combat;

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
        CombatLog.AddMessageToQueue("The party has entered combat.");
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
        
        CombatLog.AddMessageToQueue("It is " + activeCharacter.CharacterName + "'s turn.");
        while (true)
        {
            activeCharacter = combatQueue[activeCharIndex];
            activeCharacter.Speed = activeCharacter.Race.Speed + activeCharacter.CharacterClass.Speed;
            if (activeCharacter.PlayerControlled)
            {
                // Detect if a move was input this frame or yield
                while (true)
                {
                    if (DetectInput())
                    {
                        // TODO do action
                        // e.g activeCharacter.Attack(activeCharacter.Equipment.WeaponList[0], combatQueue[5]);
                    }
                    else
                    {
                        yield return null;
                        continue;
                    }
                }
            }
            else
            {
                // TODO choose move for the ai-controlled character
            }

            if (combatQueue.All(combatant => combatant.PlayerControlled))
            {
                CombatLog.AddMessageToQueue("Combat ended in Victory!");
                EndCombat(true);
                break;
            }
            else if (combatQueue.All(combatant => combatant.PlayerControlled == false))
            {
                CombatLog.AddMessageToQueue("You were defeated!");
                EndCombat(false);
                break;
            }
            else
            {
                activeCharIndex = (activeCharIndex + 1) % combatQueue.Count(); // Go through the list, rotating between the combatants
                CombatLog.AddMessageToQueue("It is " + combatQueue[activeCharIndex].CharacterName + "'s turn.");
            }
        }
    }

    bool DetectInput(Weapon weapon, Character actor, Character target, double? distance, string Type = "nothing")
    {
        try
        {
            switch (Type)
            {
                case "Move":
                    actor.Move(distance.Value);
                    return true;
                default:
                    return false;
            }
        }
        catch(Exception e)
        {
            return false;
        }
    }


    void EndCombat(bool victory)
    {
        if (!victory)
        {
            // TODO reload prompt
        }
        else
        {
            var combatants = GameObject.FindGameObjectsWithTag("Combatant");
            foreach(var combatant in combatants)
            {
                // TODO change to character tag
                combatant.tag = "temp";
            }
        }
    }
}
