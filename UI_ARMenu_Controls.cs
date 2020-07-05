using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ARMenu_Controls : MonoBehaviour
{
  public void BackToMenu()
  {
      SceneManager.LoadScene("MenuScene");
  }
}
