using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogCanvasClickHandler : MonoBehaviour, IPointerClickHandler
{
    public DialogManager dialogManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        dialogManager.PlayNextDialogLine();
    }
}
