using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IConversational
{
    [Header("Conversation Details")]
    [SerializeField] string conversationDataFilePath;
    public bool isInConversation = false;

    public void Start()
    {
        GameEvents.instance.e_onDialogEnd.AddListener(ResetDialogue);
    }

    public void StartConversation()
    {
        if (!isInConversation)
        {
            isInConversation = true;
            GameEvents.instance.e_startDialog.Invoke(conversationDataFilePath);
        }
        else
        {
            return;
        }
    }

    public void ResetDialogue()
    {

    }
}
