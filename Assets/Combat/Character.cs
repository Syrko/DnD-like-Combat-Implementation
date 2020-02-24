using UnityEngine;
using Assets.Combat;
using System;

public class Character : MonoBehaviour, IDamageable, IKillable, ICharacter
{
    // private void background
    // private Item[3] attunement

    private int proficiency;
    private Class characterClass;
    private Race race;
    private Alignment alignment;
    private HitPoints hitPoints;
    private AbilityScores abilityScores;
    private Equipment equipment;
    private bool playerControlled; // TODO add to diagram
    private int ac;
    private int initiative;
    private int speed;
    private string name;
    private int xp;

    public HitPoints HitPoints { get => hitPoints; set => hitPoints = value; }
    public int AC { get => ac; set => ac = value; }
    public int Initiative { get => initiative; set => initiative = value; }
    public int Speed { get => speed; set => speed = value; }
    public string Name { get => name; set => name = value; }
    public int XP { get => xp; set => xp = value; }
    public bool PlayerControlled { get => playerControlled; set => playerControlled = value; }
    internal Class CharacterClass { get => characterClass; set => characterClass = value; }
    internal Race Race { get => race; set => race = value; }
    internal Alignment Alignment { get => alignment; set => alignment = value; }
    internal AbilityScores AbilityScores { get => abilityScores; set => abilityScores = value; }
    internal Equipment Equipment { get => equipment; set => equipment = value; }

    public void Damage(HitPoints hp, int amount)
    {
        throw new NotImplementedException();
    }

    public void Die()
    {
        throw new NotImplementedException();
    }

    public void Heal(HitPoints hp, int amount)
    {
        throw new NotImplementedException();
    }

    public void LevelUp()
    {
        throw new NotImplementedException();
    }
}
