using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AboutMenu_Responsiveness : UI_Responsiveness
{
  RectTransform logoRect;
  RectTransform contentRect;
  RectTransform backButtonRect;

  public GameObject logo;
  public GameObject content;
  public GameObject backButton;

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
      logoRect = logo.GetComponent<RectTransform>();
      contentRect = content.GetComponent<RectTransform>();
      backButtonRect = backButton.GetComponent<RectTransform>();
  }

  private void ArrangeUIComponentToPortraitLayout ()
  {
      logoRect.anchoredPosition = new Vector3(0, 320f, 0);
      contentRect.anchoredPosition = new Vector3(0, -350f, 0);
      backButtonRect.anchoredPosition = new Vector3(0, 200f, 0);
  }

  private void ArrangeUIComponentToLandscapeLayout ()
  {
      logoRect.anchoredPosition = new Vector3(-395.2f, 94f, 0);
      contentRect.anchoredPosition = new Vector3(366f, 11f, 0);
      backButtonRect.anchoredPosition = new Vector3(-390f, 174f, 0);
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
