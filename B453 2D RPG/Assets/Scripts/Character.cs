using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AbilityScores
{
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;
}

public class Character
{
    
    string name;

    Enums.CharacterClass charClass;
    Enums.CharacterType charType;
    Enums.AbilityScoreNames charAbilityName;

    [SerializeField] GameObject prefab;
    AbilityScores charAbilityScores;

    public Character(string name, Enums.CharacterClass charClass, Enums.CharacterType charType)
    {
        this.name = name;
        this.charClass = charClass;
        this.charType = charType;
        charAbilityScores = new AbilityScores();
    }

    public int GetAbilityScoreBonus(Enums.AbilityScoreNames abilityName)
    {
        if (abilityName == Enums.AbilityScoreNames.strength)
        {
            return charAbilityScores.strength;
        }
        else if (abilityName == Enums.AbilityScoreNames.dexterity)
        {
            return charAbilityScores.dexterity;
        }
        else if (abilityName == Enums.AbilityScoreNames.constitution)
        {
            return charAbilityScores.constitution;
        }
        else if (abilityName == Enums.AbilityScoreNames.intelligence)
        {
            return charAbilityScores.intelligence;
        }
        else if (abilityName == Enums.AbilityScoreNames.wisdom)
        {
            return charAbilityScores.wisdom;
        }
        else
        {
            return charAbilityScores.charisma;
        }
    }
}
