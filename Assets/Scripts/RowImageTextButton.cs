using System;
using UnityEngine;
using UnityEngine.UI;

public class RowImageTextButton : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;
    public LevelInfo LevelInfoScript;
    public ModelMenu MyInfo = null;
    public Text Price;
    public Image DetailsIcon;
//    [SerializeField] private string _string;

    public string Text { get { return _text.text; } set { _text.text = value; } }
    public Sprite Image { set { _image.sprite = value; } }
//    public string String { get { return _string; } set { _string = value; } }


    public void Click()
    {
        if (MyInfo != null && MyInfo.ID.Equals(""))
            LevelInfoScript.GoToLevel();
        else
            LevelInfoScript.GoToLevel(MyInfo);
    }
}