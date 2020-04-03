using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Combat;

public class CombatManager : MonoBehaviour
{
    private List<Character> combatQueue;
    internal Character activeCharacter;  // Make private after deleting runtime example
    private int nextActiveCharacterIndex;

    /// <summary>
    /// Get all game objects that are tagged as combatants and put in a list their 'Character' component
    /// in order to execute combat functions.
    /// </summary>
    private void Awake()
    {
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
        CombatLog.AddMessageToQueue("The party has entered combat.");
        // Roll initiative for all the combatants at the first frame and place them in the combat queue accordingly
        combatQueue = combatQueue.OrderByDescending(combatant => combatant.Initiative).ToList();
        CombatLog.AddMessageToQueue("Initiative rolled");
        nextActiveCharacterIndex = 0;
    }

    /// <summary>
    /// Needs to be called to progress the combat queue.
    /// If the next character is dead, it proceeds to the next one without needing to be called again.
    /// </summary>
    private void NextActiveCharacter()
    {
        do
        {
            activeCharacter = combatQueue[nextActiveCharacterIndex];
            nextActiveCharacterIndex = (nextActiveCharacterIndex + 1) % combatQueue.Count(); // Go through the list, rotating between the combatants
        } while (!activeCharacter.IsAlive);
        CombatLog.AddMessageToQueue("It's " + activeCharacter.CharacterName + "'s turn!");
    }

    /// <summary>
    /// Needs to be called when a character wants to move and returns true if able.
    /// </summary>
    /// <param name="distance">The distance in unity units(meters)</param>
    /// <returns>Returns true if the character can move or false if not.</returns>
    public bool ActiveCharacterMoves(double distance)
    {   
        bool canMove = activeCharacter.Move(distance);
        if (!canMove)
        {
            CombatLog.AddMessageToQueue(activeCharacter.CharacterName + " can't move that far this round!");
        }
        return canMove;
    }

    /// <summary>
    /// Needs to be called when a character wants to attack.
    /// </summary>
    /// <param name="weapon">The equipped weapon</param>
    /// <param name="target">The target of the attack</param>
    internal void ActiveCharacterAttacks(Weapon weapon, Character target)
    {
        activeCharacter.Attack(weapon, target);
        CheckForCombatEnd();
    }

    public void ActiveCharacterCastsSpell()
    {
        throw new NotImplementedException();
        // CheckForCombatEnd();
    }

    /// <summary>
    /// Needs to be called when the combat start for making the first character the active character
    /// </summary>
    public void StartCombat()
    {
        NextActiveCharacter();
        activeCharacter.ResetSpeed();
    }

    /// <summary>
    /// This method is called when a character ends its turn
    /// </summary>
    public void EndActiveCharacterTurn()
    {
        NextActiveCharacter();
        activeCharacter.ResetSpeed();
    }

    /// <summary>
    /// This method should be called when the battle ends.
    /// </summary>
    /// <param name="Victory">If the player party was victorious this should be true</param>
    private void EndCombat(bool Victory)
    {
        if (!Victory)
        {
            throw new NotImplementedException();
            // TODO Show reload screen
        }
        else
        {
            // TODO Show end combat screen
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Method to be called when a character needs to take damage from a source other than the active character (e.g traps)
    /// </summary>
    /// <param name="target">Target of the damage</param>
    /// <param name="source">Source of the damage</param>
    internal void OthersourceDamage(Character target, object source)
    {
        // Have fun
        // object should be of some type like traps, runes or a fricking cliff etc
        int amount = 0; // amount = source.DamageAmount
        target.Damage(amount);
        CheckForCombatEnd();
    }

    /// <summary>
    /// Should be called after damage is dealt to ensure a check is run for combat end.
    /// </summary>
    private void CheckForCombatEnd()
    {
        // Iterates through the combat queue to find if any new characters died.
        foreach (Character character in combatQueue)
        {
            bool isDead = character.CheckForDeath();
            if (isDead)
            {
                CombatLog.AddMessageToQueue(character.CharacterName + " has died!");
            }
        }
        // Checks to see if the combat end requiriments have been reached.
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
