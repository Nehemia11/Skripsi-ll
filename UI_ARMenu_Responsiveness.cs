using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ARMenu_Responsiveness : UI_Responsiveness
{
    protected string selectedOrientationLockState = "auto-rotation";
    protected bool IsInDistractionFreeMode = false;
    ScreenOrientation selectedOrientation = ScreenOrientation.AutoRotation;

    RectTransform productPreviewSelectionPanelRect;
    RectTransform productPreviewSizingControlGroupRect;
    RectTransform productInformationPanelRect;
    RectTransform markerTrackerExitButtonRect;
    RectTransform distractionFreeMaximizeButtonRect;

    public GameObject productPreviewSelectionPanel;
    public GameObject productPreviewSizingControlGroup;
    public GameObject productInformationPanel;
    public GameObject markerTrackerExitButton;
    public GameObject distractionFreeMaximizeButton;

    public void ToggleOrientationLock (Button sourceButton)
    {
        Text buttonLabelText = sourceButton.GetComponentInChildren<Text>();

        if (selectedOrientationLockState == "auto-rotation")
        {
            buttonLabelText.text = "Lock\nOrnt";
            selectedOrientationLockState = "lock-rotation";
            selectedOrientation = Screen.orientation;
            Screen.orientation = Screen.orientation;
            return;
        }

        if (selectedOrientationLockState == "lock-rotation")
        {
            buttonLabelText.text = "Auto\nOrnt";
            selectedOrientationLockState = "auto-rotation";
            selectedOrientation = ScreenOrientation.AutoRotation;
            return;
        }
    }

    public void ReleaseOrientationLock ()
    {
        selectedOrientationLockState = "auto-rotation";
        selectedOrientation = ScreenOrientation.AutoRotation;
    }

    public bool GetInDistractionFreeModeStatus ()
    {
        return IsInDistractionFreeMode;
    }

    public void EnableDistractionFreeMode ()
    {
        IsInDistractionFreeMode = true;
    }

    public void DisableDistractionFreeMode ()
    {
        IsInDistractionFreeMode = false;
    }

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
        productPreviewSelectionPanelRect = productPreviewSelectionPanel.GetComponent<RectTransform>();
        productPreviewSizingControlGroupRect = productPreviewSizingControlGroup.GetComponent<RectTransform>();
        productInformationPanelRect = productInformationPanel.GetComponent<RectTransform>();
        markerTrackerExitButtonRect = markerTrackerExitButton.GetComponent<RectTransform>();
        distractionFreeMaximizeButtonRect = distractionFreeMaximizeButton.GetComponent<RectTransform>();
    }

    private void ArrangeUIComponentToPortraitLayout ()
    {
        // productPreviewSelectionPanelRect.localScale = UIComponentScale();
        // productPreviewSizingControlGroupRect.localScale = UIComponentScale();
        // productInformationPanelRect.localScale = UIComponentScale();
        // markerTrackerExitButtonRect.localScale = UIComponentScale();
        // distractionFreeMaximizeButtonRect.localScale = UIComponentScale();

        productPreviewSelectionPanelRect.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        foreach (RectTransform childUIObjectRect in productPreviewSelectionPanelRect)
        {
            if (childUIObjectRect.name == "ProductScrollView")
            {
                foreach (RectTransform productSelectionRect in childUIObjectRect.Find("Viewport").Find("Content"))
                {
                    productSelectionRect.rotation = Quaternion.Euler(new Vector2(0, 0));
                }
                continue;
            }
            childUIObjectRect.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        productPreviewSizingControlGroupRect.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        foreach (RectTransform childUIObjectRect in productPreviewSizingControlGroupRect)
        {
            childUIObjectRect.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }


        productPreviewSelectionPanelRect.localPosition = new Vector3(0, -882f, 0);
        productPreviewSizingControlGroupRect.localPosition = new Vector3(0, -461.9f, 0);
        productInformationPanelRect.anchoredPosition = new Vector3(0, -109.9f, 0);
        markerTrackerExitButtonRect.anchoredPosition = new Vector3(-349f, 182f, 0);
        distractionFreeMaximizeButtonRect.anchoredPosition = new Vector3(402f, 116f, 0);
    }

    private void ArrangeUIComponentToLandscapeLayout ()
    {
        // productPreviewSelectionPanelRect.localScale = UIComponentScale();
        // productPreviewSizingControlGroupRect.localScale = UIComponentScale();
        // productInformationPanelRect.localScale = UIComponentScale();
        // markerTrackerExitButtonRect.localScale = UIComponentScale();
        // distractionFreeMaximizeButtonRect.localScale = UIComponentScale();

        productPreviewSelectionPanelRect.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));

        foreach (Transform childUIObject in productPreviewSelectionPanelRect)
        {
            if (childUIObject.name == "ProductScrollView")
            {
                foreach (Transform productSelection in childUIObject.Find("Viewport").Find("Content"))
                {
                    productSelection.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                continue;
            }
            childUIObject.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90f));
        }

        productPreviewSizingControlGroupRect.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));

        foreach (RectTransform childUIObjectRect in productPreviewSizingControlGroupRect)
        {
            childUIObjectRect.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        productPreviewSelectionPanelRect.localPosition = new Vector3(882f, 0, 0);
        productPreviewSizingControlGroupRect.localPosition = new Vector3(465f, 0, 0);
        productInformationPanelRect.anchoredPosition = new Vector3(-294f, -110f, 0);
        markerTrackerExitButtonRect.anchoredPosition = new Vector3(768f, 191f, 0);
        distractionFreeMaximizeButtonRect.anchoredPosition = new Vector3(830f, 944f, 0);
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
