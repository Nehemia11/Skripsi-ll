using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu_Controls : MonoBehaviour
{
    RectTransform canvasRect;
    RectTransform ExitConfirmationRect;
    public GameObject ExitConfirmation;

    void Awake ()
    {
        canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        ExitConfirmationRect = ExitConfirmation.GetComponent<RectTransform>();

        refreshPanelBGSizing();
        ExitConfirmationRect.localScale = new Vector3(0, 0, 0);
    }

    public void refreshPanelBGSizing ()
    {
        ExitConfirmationRect.Find("PNL_ExitConfirmation_BG").GetComponent<RectTransform>().sizeDelta = canvasRect.sizeDelta;
    }

    public void AskConfirmationExit ()
    {
        ExitConfirmationRect.localScale = new Vector3(1, 1, 1);
    }

    public void CancelConfirmationExit ()
    {
        ExitConfirmationRect.localScale = new Vector3(0, 0, 0);
    }

    public void StartARSession ()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void ShowAbout ()
    {
        SceneManager.LoadScene("AboutScene");
    }

    public void RedirectToWhatsapp ()
    {
        Application.OpenURL("https://wa.me/6287709200197");
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
