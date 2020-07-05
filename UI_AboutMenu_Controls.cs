using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_AboutMenu_Controls : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
