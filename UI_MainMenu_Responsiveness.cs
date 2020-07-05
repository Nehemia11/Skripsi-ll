using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu_Responsiveness : UI_Responsiveness
{
    RectTransform logoRect;
    RectTransform brandTextGroupRect;
    RectTransform mainButtonRect;
    RectTransform miscOptionButtonGroupRect;
    RectTransform ExitConfirmationRect;

    UI_MainMenu_Controls mainMenuControl;

    public GameObject logo;
    public GameObject brandTextGroup;
    public GameObject mainButton;
    public GameObject miscOptionButtonGroup;
    public GameObject ExitConfirmation;

    public override void OnScreenOrientationChanged (string screenOrientation)
    {
        if (GetCurrentScreenOrientation() == "Landscape") {
            ArrangeUIComponentToLandscapeLayout();
        }
        else
        {
            ArrangeUIComponentToPortraitLayout();
        }
    }

    public override void initializeComponentReference ()
    {
        mainMenuControl = GetComponent<UI_MainMenu_Controls>();
        logoRect = logo.GetComponent<RectTransform>();
        brandTextGroupRect = brandTextGroup.GetComponent<RectTransform>();
        mainButtonRect = mainButton.GetComponent<RectTransform>();
        miscOptionButtonGroupRect = miscOptionButtonGroup.GetComponent<RectTransform>();
    }

    private void ArrangeUIComponentToPortraitLayout ()
    {
        logoRect.localScale = UIComponentScale();
        brandTextGroupRect.localScale = UIComponentScale();
        mainButtonRect.localScale = UIComponentScale();
        miscOptionButtonGroupRect.localScale = UIComponentScale();
        ExitConfirmation.GetComponent<Transform>()
          .Find("PNL_ExitConfirmation_BG")
          .Find("PNL_ExitConfirmation_Dialog")
          .GetComponent<RectTransform>()
          .localScale = UIComponentScale();

        mainMenuControl.refreshPanelBGSizing();
        logoRect.anchoredPosition = new Vector3(0, 320f, 0);
        brandTextGroupRect.anchoredPosition = new Vector3(0, -140f, 0);
        mainButtonRect.anchoredPosition = new Vector3(0, -433f, 0);
        miscOptionButtonGroupRect.anchoredPosition = new Vector3(9.000031f, 328.0001f, 0);
    }

    private void ArrangeUIComponentToLandscapeLayout ()
    {
        logoRect.localScale = UIComponentScale();
        brandTextGroupRect.localScale = UIComponentScale(1.2f);
        mainButtonRect.localScale = UIComponentScale(0.9f);
        miscOptionButtonGroupRect.localScale = UIComponentScale(0.89f);
        ExitConfirmation.GetComponent<Transform>()
          .Find("PNL_ExitConfirmation_BG")
          .Find("PNL_ExitConfirmation_Dialog")
          .GetComponent<RectTransform>()
          .localScale = UIComponentScale();

        mainMenuControl.refreshPanelBGSizing();
        logoRect.anchoredPosition = new Vector3(-733f, 84f, 0);
        brandTextGroupRect.anchoredPosition = new Vector3(550f, 460f, 0);
        mainButtonRect.anchoredPosition = new Vector3(550f, 90f, 0);
        miscOptionButtonGroupRect.anchoredPosition = new Vector3(550f, 1304f, 0);
    }

    private Vector3 UIComponentScale (float compensation = 1f)
    {
        RectTransform canvasRect = GameObject.Find("Canvas")
          .GetComponent<RectTransform>();

        if (GetCurrentScreenOrientation() == "Landscape")
        {
            return new Vector3(
              (1/canvasRect.sizeDelta.y) * (canvasRect.sizeDelta.x * compensation),
              (1/canvasRect.sizeDelta.y) * (canvasRect.sizeDelta.x * compensation),
              0
            );
        }

        return new Vector3(1, 1, 1);
    }
}
