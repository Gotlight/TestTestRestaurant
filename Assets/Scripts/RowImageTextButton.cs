using System;
using UnityEngine;
using UnityEngine.UI;

public class RowImageTextButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
//    [SerializeField] private string _string;

    public string Text { get { return _text.text; } set { _text.text = value; } }
    public Sprite Image { set { _image.sprite = value; } }
//    public string String { get { return _string; } set { _string = value; } }
    
}