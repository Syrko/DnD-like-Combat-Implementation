using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Combat;
using Assets.Combat.Weapons;
using Assets.Dataset;

public class RuntimeExample : MonoBehaviour
{
    const string COMBATANT_TAG = "Combatant";
    int counter = 0;
    GameObject combatManagerGameObject;
    Weapon dagger;
    Weapon dagger2;
    Weapon mace;

    // Start is called before the first frame update
    void Start()
    {
        // SETUP combat example

        // Creating a CombatLog object
        GameObject combatLog = new GameObject("CombatLog");
        combatLog.AddComponent<CombatLog>();

        // Creating weapons
        dagger = DatabaseHelper.GetInstance().GetWeapon("Dagger");
        dagger2 = DatabaseHelper.GetInstance().GetWeapon("Dagger");
        mace = DatabaseHelper.GetInstance().GetWeapon("Mace");

        // Creating characters
        GameObject char1 = new GameObject("Character1");
        char1.AddComponent<Character>();
        GameObject char2 = new GameObject("Character2");
        char2.AddComponent<Character>();
        GameObject char3 = new GameObject("Character3");
        char3.AddComponent<Character>();

        // Characters entering combat
        char1.tag = COMBATANT_TAG;
        char2.tag = COMBATANT_TAG;
        char3.tag = COMBATANT_TAG;

        combatManagerGameObject = new GameObject("CombatManager");
        combatManagerGameObject.AddComponent<CombatManager>();
    }

    private void Update()
    {
        // Manage combat example
        CombatManager combatManager = combatManagerGameObject.GetComponent<CombatManager>();
        if (0 == counter)
            combatManager.StartCombat();
        if (1 == counter)
        {
            Debug.Log("Speed before: " + combatManager.activeCharacter.Speed);
            bool result = combatManager.ActiveCharacterMoves(3);
            Debug.Log("Speed after: " + combatManager.activeCharacter.Speed);
            if (result)
            {
                // move character in-game
            }
        }
        if (2 == counter)
            combatManager.EndActiveCharacterTurn();
        if (3 == counter)
            combatManager.EndActiveCharacterTurn();
        if (4 == counter)
        {
            Debug.Log("Speed before: " + combatManager.activeCharacter.Speed);
            bool result = combatManager.ActiveCharacterMoves(30);
            Debug.Log("Speed after: " + combatManager.activeCharacter.Speed);
            if (result)
            {
                // move character in-game
            }
        }
        if (5 == counter)
            combatManager.EndActiveCharacterTurn();
        if (6 == counter)
            combatManager.EndActiveCharacterTurn();
        if (7 == counter)
        {
            // Let's say active character is equipped with a dagger and wants to attack himself(easier to show with this code)
            // Normally the target character is to be acquired through the gui

            // combatManager.ActiveCharacterAttacks((Weapon)dagger, combatManager.activeCharacter);

            // The above peice of code cannot run as many things must be initialised in other parts of the game
        }
        counter++;
    }
}
