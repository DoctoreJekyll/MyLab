using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public bool playerIsOnRange;
    public GameObject questObj;
    public GameObject dialoguePanel;
    public TMP_Text dialogueT;

    private int dialogueIndex;
    [TextArea(3,6)]public string[] dialogueText;

    private bool didDialogueStart;

    public PlayerMove playerMove;

    public void Update()
    {
        if (playerIsOnRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueT.text == dialogueText[dialogueIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueT.text = dialogueText[dialogueIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        questObj.SetActive(false);
        dialoguePanel.SetActive(true);
        playerMove.canMove = false;

        dialogueIndex = 0;

        StartCoroutine(ShowText());
    }

    private void NextDialogueLine()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueText.Length)
        {
            StartCoroutine(ShowText());
        }
        else
        {
            CloseText();
            questObj.SetActive(true);
        }


    }

    private void CloseText()
    {
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        playerMove.canMove = true;
    }

    private IEnumerator ShowText()
    {
        dialogueT.text = "";
        foreach (char ch in dialogueText[dialogueIndex])
        {
            dialogueT.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsOnRange = true;
        questObj.SetActive(true);
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        playerIsOnRange = false;
        questObj.SetActive(false);
        CloseText();
    }


}
