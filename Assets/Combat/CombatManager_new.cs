using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Combat;

public class CombatManager_new : MonoBehaviour
{
    private List<Character> combatQueue;
    private Character activeCharacter;
    private int nextActiveCharacterIndex;

    /// <summary>
    /// Get all game objects that are tagged as combatants and put in a list their characterStats component
    /// in order to execute combat functions.
    /// </summary>
    private void Awake()
    {
        CombatLog.AddMessageToQueue("The party has entered combat.");
        combatQueue = new List<Character>();
        var characters = GameObject.FindGameObjectsWithTag("Combatant");
        foreach (var character in characters)
        {
            combatQueue.Add(character.GetComponent<Character>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        combatQueue = combatQueue.OrderByDescending(combatant => combatant.Initiative).ToList();
        CombatLog.AddMessageToQueue("Initiative rolled");
        nextActiveCharacterIndex = 0;
    }

    public void NextActiveCharacter()
    {
        do
        {
            activeCharacter = combatQueue[nextActiveCharacterIndex];
            nextActiveCharacterIndex = (nextActiveCharacterIndex + 1) % combatQueue.Count(); // Go through the list, rotating between the combatants
        } while (!activeCharacter.IsAlive);
        CombatLog.AddMessageToQueue("It's " + activeCharacter.name + "'s turn!");
    }

    public bool ActiveCharacterMoves(double distance)
    {   
        bool canMove = activeCharacter.Move(distance);
        return canMove;
    }

    public void ActiveCharacterAttacks(Weapon weapon, Character target)
    {
        activeCharacter.Attack(weapon, target);
        CheckForCombatEnd();
    }

    public void ActiveCharacterCastsSpell()
    {
        throw new NotImplementedException();
        // CheckForCombatEnd();
    }

    public void StartCombat()
    {
        NextActiveCharacter();
    }

    public void EndActiveCharacterTurn()
    {
        NextActiveCharacter();
    }

    public void EndCombat(bool Victory)
    {
        if (!Victory)
        {
            throw new NotImplementedException();
            // Show reload screen
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public void OthersourceDamage(Character target, object source)
    {
        // Have fun
        // object should be of some type like traps, runes or a fricking cliff etc
        int amount = 0; // amount = source.DamageAmount
        target.Damage(amount);
        CheckForCombatEnd();
    }

    private void CheckForCombatEnd()
    {
        foreach (Character character in combatQueue)
        {
            bool isDead = character.CheckForDeath();
            if (isDead)
            {
                CombatLog.AddMessageToQueue(character.name + " has died!");
            }
        }
        if (combatQueue.Any(combatant => combatant.PlayerControlled && combatant.IsAlive))
        {
            if (combatQueue.Any(combatant => !combatant.PlayerControlled && combatant.IsAlive))
            {
                // Battle continues
                return;
            }
            else
            {
                // Victory
                EndCombat(true);
            }
        }
        else
        {
            // The party loses
            EndCombat(false);
        }
    }
}
