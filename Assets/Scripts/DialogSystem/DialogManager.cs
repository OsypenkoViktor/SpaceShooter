using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public List<DialogInfo> dialogs;
    public GameObject DialogCanvas;
    public TextMeshProUGUI dialogText;
    public Image DialogAvatar;
    private DialogInfo dialogToPlay;
    int currentDialogLineIndex = 0;

    private void Awake()
    {
        LoadDialogs();
    }

    private void Start()
    {
        
    }

    private void LoadDialogs()
    {
        Object[] dialogsObjects = Resources.LoadAll("Dialogues", typeof(DialogInfo));
        foreach (Object dialogObj in dialogsObjects)
        {
            dialogs.Add(dialogObj as DialogInfo);
        }
    }

    public void PlayDialog(string dialogName)
    {
            dialogToPlay = dialogs.Find(dialog=>dialog.dialogName == dialogName);
            DialogCanvas.SetActive(true);
            ShowDialogLine(currentDialogLineIndex);
    }

    public void PlayDialog(DialogInfo dialog)
    {
        dialogToPlay = dialog;
        DialogCanvas.SetActive(true);
        Time.timeScale = 0f;
        ShowDialogLine(currentDialogLineIndex);
    }

    public void PlayNextDialogLine()
    {
        if (currentDialogLineIndex + 1 < dialogToPlay.dialogLines.Count) 
        {
            currentDialogLineIndex++;
            ShowDialogLine(currentDialogLineIndex);
        }
        else
        {
            currentDialogLineIndex = 0;
            Time.timeScale = 1f;
            DialogCanvas.SetActive(false);
        }
    }

    private void ShowDialogLine(int currentDialogLineIndex)
    {
        DialogLine currentDialogLine = dialogToPlay.dialogLines[currentDialogLineIndex];
        dialogText.text = currentDialogLine.character.characterName + ":\n" + currentDialogLine.text;
        DialogAvatar.sprite = currentDialogLine.character.characterSprite;
    }
}

