using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_Responsiveness : MonoBehaviour
{
    float screenWidth;
    string screenOrientation;

    void Start ()
    {
        initializeComponentReference();
        WatchScreenResolutionChanges();
    }

    private void Update ()
    {
      if (screenWidth != Screen.width)
      {
        WatchScreenResolutionChanges();
      }
    }

    private void WatchScreenResolutionChanges ()
    {
        screenWidth = Screen.width;
        screenOrientation = "Portrait";
        if (Screen.width > Screen.height)
        {
            screenOrientation = "Landscape";
        }
        if (screenOrientation == "Portrait")
        {
            OnScreenOrientationChanged(screenOrientation);
        }
        else
        {
            OnScreenOrientationChanged(screenOrientation);
        }
    }

    public string GetCurrentScreenOrientation ()
    {
        return screenOrientation;
    }

    public abstract void initializeComponentReference ();
    public abstract void OnScreenOrientationChanged (string newScreenOrientation);
}
