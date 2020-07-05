using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ARMenu_MarkerReticle : MonoBehaviour
{
    private RectTransform canvasRect;
    private bool IsInDistractionFreeMode = false;
    private UI_ARMenu_ProductSelector productSelectorComponent;

    void Start ()
    {
        IsInDistractionFreeMode = GetComponent<UI_ARMenu_Responsiveness>().GetInDistractionFreeModeStatus();
        productSelectorComponent = GetComponent<UI_ARMenu_ProductSelector>();
    }

    public void SetToTrackingMode ()
    {
        canvasRect = GameObject.Find("Canvas")
          .GetComponent<RectTransform>();
        foreach (RectTransform childUIObject in canvasRect)
        {
            if (childUIObject.tag == "UI_AR_ProductModelLoader")
            {
                childUIObject.localScale = new Vector3(0, 0, 0);
                continue;
            }

            // if (childUIObject.tag == "UI_AR_MarkerDetection" && childObject.name == "BTN_BackToMenu_ALT" && IsInDistractionFreeMode)
            // {
            //     childUIObject.localScale = new Vector3(0, 0, 0);
            // }

            if (childUIObject.tag == "UI_AR_DistractionFree")
            {
                childUIObject.localScale = new Vector3(0, 0, 0);
            }

            if (childUIObject.tag == "UI_AR_MarkerDetection")
            {
                childUIObject.localScale = new Vector3(1, 1, 1);
            }
        }
        productSelectorComponent.EmptyProductDisplay();
        // SetToDisplayMode();
    }

    public void SetToDisplayMode ()
    {
        if (IsInDistractionFreeMode)
        {
            SetToDistractionFreeMode();
            return;
        }

        canvasRect = GameObject.Find("Canvas")
          .GetComponent<RectTransform>();
        foreach (RectTransform childUIObject in canvasRect)
        {
            if (childUIObject.tag == "UI_AR_ProductModelLoader")
            {
                childUIObject.localScale = new Vector3(1, 1, 1);
                continue;
            }

            if (childUIObject.tag == "UI_AR_MarkerDetection")
            {
                childUIObject.localScale = new Vector3(0, 0, 0);
            }

            if (childUIObject.tag == "UI_AR_DistractionFree")
            {
                childUIObject.localScale = new Vector3(0, 0, 0);
            }
        }
        productSelectorComponent.LoadStartUpProduct();
    }

    public void SetToDistractionFreeMode ()
    {
        canvasRect = GameObject.Find("Canvas")
          .GetComponent<RectTransform>();
        foreach (RectTransform childUIObject in canvasRect)
        {
            if (childUIObject.tag == "UI_AR_ProductModelLoader")
            {
                childUIObject.localScale = new Vector3(0, 0, 0);
                continue;
            }

            if (childUIObject.tag == "UI_AR_MarkerDetection")
            {
                childUIObject.localScale = new Vector3(0, 0, 0);
            }

            if (childUIObject.tag == "UI_AR_DistractionFree")
            {
                childUIObject.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
