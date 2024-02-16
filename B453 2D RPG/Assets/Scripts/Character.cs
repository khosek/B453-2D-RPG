using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AbilityScores
{
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
}

public class Character
{
    
    string name;

    CharacterClass charClass;
    CharacterType charType;
    AbilityScoreNames charAbilityName;

    [SerializeField] GameObject prefab;
    AbilityScores charAbilityScores;

    public Character(string name, CharacterClass charClass, CharacterType charType, AbilityScores abilityScores)
    {
        this.name = name;
        this.charClass = charClass;
        this.charType = charType;
        this.charAbilityScores = abilityScores;
    }

    public int GetAbilityScoreBonus(AbilityScoreNames abilityName)
    {
        if (abilityName == AbilityScoreNames.Strength)
        {
            return charAbilityScores.Strength;
        }
        else if (abilityName == AbilityScoreNames.Dexterity)
        {
            return charAbilityScores.Dexterity;
        }
        else if (abilityName == AbilityScoreNames.Constitution)
        {
            return charAbilityScores.Constitution;
        }
        else if (abilityName == AbilityScoreNames.Intelligence)
        {
            return charAbilityScores.Intelligence;
        }
        else if (abilityName == AbilityScoreNames.Wisdom)
        {
            return charAbilityScores.Wisdom;
        }
        else
        {
            return charAbilityScores.Charisma;
        }
    }
}
