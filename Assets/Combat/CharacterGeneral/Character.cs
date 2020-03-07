using UnityEngine;
using Assets.Combat;
using System;

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
    private int initiative;
    private int speed;
    private string characterName;
    private int xp;

    public HitPoints HitPoints { get => hitPoints; set => hitPoints = value; }
    public int AC { get => ac; set => ac = value; }
    public int Initiative { get => initiative; set => initiative = value; }
    public int Speed { get => speed; set => speed = value; }
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

    public void Damage(int amount)
    {
        hitPoints.Damage(amount);
    }

    public void Die()
    {
        throw new NotImplementedException();
    }

    public void Heal(int amount)
    {
        hitPoints.Heal(amount);
    }

    public void LevelUp()
    {
        characterClass.LevelUp();
    }

    public void Move(int distance)
    {
        throw new NotImplementedException();
    }

    public void UseSkill()
    {
        throw new NotImplementedException();
    }

    public void Attack(Weapon weapon, Character target)
    {
        int abilityModifier;
        abilityModifier = AbilityScores.GetAbilityModifier(AbilityType.Strength);
        if (weapon.IsFinesse)
        {
            int dex = AbilityScores.GetAbilityModifier(AbilityType.Dexterity);
            if (dex > abilityModifier)
                abilityModifier = dex;
        }
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

        Die d20 = new Die(DieType.D20);
        int rolled = d20.RollDie();

        int attackRoll = rolled + prof + abilityModifier;
        if (attackRoll >= target.AC)
        {
            int damage = 0;
            for (int i = 0; i < weapon.NumberOfDice; i++)
                damage += weapon.DieDamage.RollDie();
            if (rolled == Assets.Combat.Die.NAT20)
                damage *= 2;
            damage += abilityModifier;

            target.Damage(damage);
        }
    }

    public void CastSpell()
    {
        throw new NotImplementedException();
    }
}
