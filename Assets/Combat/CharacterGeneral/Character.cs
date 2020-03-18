using UnityEngine;
using Assets.Combat;
using System;
using Assets;

/// <summary>
/// Basic character class containing the necessary stats and methods to simulate a character of dnd.
/// </summary>
public class Character : MonoBehaviour, IDamageable, IKillable, ICharacter
{
    // private Item[3] attunement

    private Class characterClass;
    private Race race;
    private int proficiency;
    private Background background;
    private string alignment;
    private HitPoints hitPoints;
    private AbilityScores abilityScores;
    private Equipment equipment;
    private bool playerControlled;
    private int ac;
    private int initiative; // Initiative bonus
    private double speed;
    private string characterName;
    private int xp;
    private bool isAlive;

    public HitPoints HitPoints { get => hitPoints; set => hitPoints = value; }
    public int AC { get => ac; set => ac = value; }
    /// <summary>
    /// When getting the initiative rolls a D20 and add the necessary modifiers
    /// </summary>
    public int Initiative { get => new Die(DieType.D20).RollDie() + abilityScores.GetAbilityModifier(AbilityType.Dexterity) + initiative; set => initiative = value; }
    public double Speed { get => speed; set => speed = value; }
    public string CharacterName { get => characterName; set => characterName = value; }
    public int XP { get => xp; set => xp = value; }
    public bool PlayerControlled { get => playerControlled; set => playerControlled = value; }
    public int Proficiency { get => proficiency; set => proficiency = value; }
    public string Alignment { get => alignment; set => alignment = value; }
    internal Class CharacterClass { get => characterClass; set => characterClass = value; }
    internal Race Race { get => race; set => race = value; }
    internal AbilityScores AbilityScores { get => abilityScores; set => abilityScores = value; }
    internal Equipment Equipment { get => equipment; set => equipment = value; }
    internal Background Background { get => background; set => background = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }

    /// <summary>
    /// To be called when the character takes danage
    /// </summary>
    /// <param name="amount">Amount of damage</param>
    public void Damage(int amount)
    {
        hitPoints.Damage(amount);
    }

    /// <summary>
    /// To be called when the character dies
    /// </summary>
    public void Die()
    {
        IsAlive = false;
    }

    /// <summary>
    /// To be called when you need to check if the character died
    /// </summary>
    /// <returns>Return true if the character is dead</returns>
    public bool CheckForDeath()
    {
        bool isDead = hitPoints.CheckForDeath();
        if(isDead == true)
        {
            IsAlive = false;
        }
        return isDead;
    }

    /// <summary>
    /// To be called when a character is healed
    /// </summary>
    /// <param name="amount">Amount of heal</param>
    public void Heal(int amount)
    {
        hitPoints.Heal(amount);
    }

    /// <summary>
    /// To be called when the character levels up
    /// TODO expand functionality
    /// </summary>
    public void LevelUp()
    {
        characterClass.LevelUp();
    }

    /// <summary>
    /// Checks if the character is able to move the given distance
    /// </summary>
    /// <param name="distance">Distance in meters that the character wishes to move</param>
    /// <returns>Return true if the character is able to move the distance</returns>
    public bool Move(double distance)
    {
        // If the character is able to move it subtracts the distance from the remaining speed
        // The speed should be reset at the start of the character's turn
        distance = HelperFunctions.MetersToFeet(distance);
        bool ableToMove = distance <= speed;
        if (ableToMove)
        {
            speed -= distance;
        }
        return ableToMove;
    }

    /// <summary>
    /// Resets the characters speed with the values from the race and class
    /// TODO add to the diagram
    /// </summary>
    public void ResetSpeed()
    {
        speed = race.Speed + characterClass.Speed;
    }

    public void UseSkill()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// To be called when the character makes an attack against a valid character target
    /// </summary>
    /// <param name="weapon">Equipped weapon</param>
    /// <param name="target">Target character</param>
    public void Attack(Weapon weapon, Character target)
    {
        // Gets the ability modifier needed according to the weapon
        int abilityModifier;
        abilityModifier = AbilityScores.GetAbilityModifier(AbilityType.Strength);
        if (weapon.IsFinesse)
        {
            int dex = AbilityScores.GetAbilityModifier(AbilityType.Dexterity);
            if (dex > abilityModifier)
                abilityModifier = dex;
        }
        // Checks for proficiency with the weapon
        int prof = 0;
        if (weapon.IsMartial)
        {
            if (characterClass.Proficiencies.Contains("Martial"))
                prof = proficiency;
        }
        else if (!weapon.IsMartial)
        {
            if (characterClass.Proficiencies.Contains("Simple"))
                prof = proficiency;
        }
        // Rolls a D20
        Die d20 = new Die(DieType.D20);
        int rolled = d20.RollDie();

        // Checks if the attack hit
        int attackRoll = rolled + prof + abilityModifier;
        if (attackRoll >= target.AC)
        {
            // If hit, calculate damage, deal it and queue message
            int damage = 0;
            for (int i = 0; i < weapon.NumberOfDice; i++)
                damage += weapon.DieDamage.RollDie();
            if (rolled == Assets.Combat.Die.NAT20)
                damage *= 2;
            damage += abilityModifier;

            CombatLog.AddMessageToQueue(CharacterName + " succeeded at attacking " + target.CharacterName + " and inflicted " + damage + "damage.");
            target.Damage(damage);
        }
        else
        {
            // Else just display message
            CombatLog.AddMessageToQueue(CharacterName + " missed the attack on" + target.CharacterName + ".");
        }
    }

    public void CastSpell()
    {
        throw new NotImplementedException();
    }
}
