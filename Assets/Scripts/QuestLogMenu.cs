using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogMenu : MonoBehaviour
{
    [SerializeField] GameObject mainQuestsMenu = null;
    [SerializeField] GameObject sideQuestsMenu = null;
    [SerializeField] GameObject mainQuestsButtonHighlight = null;
    [SerializeField] GameObject sideQuestsButtonHighlight = null;

    private void OnEnable()
    {
        ShowMainQuests();
    }

    public void ShowMainQuests()
    {
        SetAllInactive();
        mainQuestsMenu.SetActive(true);
        mainQuestsButtonHighlight.SetActive(true);
    }

    public void ShowSideQuests()
    {
        SetAllInactive();
        sideQuestsMenu.SetActive(true);
        sideQuestsButtonHighlight.SetActive(true);
    }

    private void SetAllInactive()
    {
        mainQuestsMenu.SetActive(false);
        mainQuestsButtonHighlight.SetActive(false);
        sideQuestsMenu.SetActive(false);
        sideQuestsButtonHighlight.SetActive(false);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
