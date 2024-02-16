using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreationManager : MonoBehaviour
{
    public static CreationManager instance;
    private GameManager gameManager;

    private string characterName;
    private CharacterClass characterClass;
    private AbilityScores abilityScores;

    public Button paladinButton;
    public Button mageButton;
    public Button thiefButton;
    public Button clericButton;
    public Button statsButton;
    public TMP_InputField nameField;
    public Button finalizeButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        paladinButton.onClick.AddListener(() => changeClass(CharacterClass.Paladin)); 
        mageButton.onClick.AddListener(() => changeClass(CharacterClass.Mage));
        thiefButton.onClick.AddListener(() => changeClass(CharacterClass.Thief));
        clericButton.onClick.AddListener(() => changeClass(CharacterClass.Cleric));

        statsButton.onClick.AddListener(() => RollStats());

        finalizeButton.onClick.AddListener(() => FinalizeCharacter());
    }

    public void ReName(string characterName)
    {
        this.characterName = characterName;
    }

    public void changeClass(CharacterClass characterClass)
    {
        this.characterClass = characterClass;
    }

    public void RollStats()
    {
        abilityScores.Strength = (int)Random.Range(1, 13);
        abilityScores.Dexterity = (int)Random.Range(1, 13);
        abilityScores.Constitution = (int)Random.Range(1, 13);
        abilityScores.Intelligence = (int)Random.Range(1, 13);
        abilityScores.Wisdom = (int)Random.Range(1, 13);
        abilityScores.Charisma = (int)Random.Range(1, 13);
    }

    public void FinalizeCharacter()
    {
        ReName(nameField.GetComponent<Text>().text);
        gameManager.AddCharacter(new Character(characterName, characterClass, CharacterType.Player, abilityScores));
        gameManager.ChangeScene(0);
    }
}
