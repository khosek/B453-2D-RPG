using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private CombatCharacter[] Characters;
    [SerializeField] private float nextTurnDelay = 1.0f;

    private int curCharacterIndex = -1;
    public CombatCharacter currentCharacter;

    public static TurnManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
       OnBeginTurn();
    }

    public void OnBeginTurn()
    {
        curCharacterIndex++;
        if (curCharacterIndex >= Characters.Length)
        {
            curCharacterIndex = 0;
        }

        currentCharacter = Characters[curCharacterIndex];
        CombatEvents.instance.e_onBeginTurn.Invoke(currentCharacter);
    }

    public void EndTurn()
    {
        CombatEvents.instance.e_onEndTurn.Invoke(currentCharacter);

        Invoke(nameof(OnBeginTurn), nextTurnDelay);
    }

    private void OnCharacterDie(CombatCharacter character)
    {
        //CombatEvents.instance.e_onCharacterDie.Invoke(currentCharacter);
    }
}
