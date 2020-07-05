using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ARCameraPermission : MonoBehaviour
{
    void Start ()
    {
        #if PLATFORM_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
        #endif
    }
}
