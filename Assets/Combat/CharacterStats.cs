using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public class CharacterStats : MonoBehaviour
{
    private bool playerControlled;
    private int proficiency;
    private int ac;
    private int initiative;
    private int speed;
    private int alignment;
    private string charName;
    private int race;
    private int xp;
    private int background;
    private int attunement;
    private CharacterClass characterClass;
    private HitPoints hitPoints;
    private AbilityScores abilityScores;
    private SavingThrows savingThrows;

    public bool PlayerControlled { get => playerControlled; set => playerControlled = value; }
    public int Proficiency { get => proficiency; set => proficiency = value; }
    public int Ac { get => ac; set => ac = value; }
    public int Initiative { get => initiative; set => initiative = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Alignment { get => alignment; set => alignment = value; }
    public string CharName { get => charName; set => charName = value; }
    public int Race { get => race; set => race = value; }
    public int Xp { get => xp; set => xp = value; }
    public int Background { get => background; set => background = value; }
    public int Attunement { get => attunement; set => attunement = value; }
    internal CharacterClass CharacterClass { get => characterClass; set => characterClass = value; }
    internal HitPoints HitPoints { get => hitPoints; set => hitPoints = value; }
    internal AbilityScores AbilityScores { get => abilityScores; set => abilityScores = value; }
    internal SavingThrows SavingThrows { get => savingThrows; set => savingThrows = value; }

    //private Equipement equipement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
