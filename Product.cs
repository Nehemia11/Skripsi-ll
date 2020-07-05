using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product
{
    public string name;
    public string slug;
    public string price;
    public int width = 0;
    public int height = 0;
    public Sprite image;
    public GameObject model;
}
