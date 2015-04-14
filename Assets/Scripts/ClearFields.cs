using System;
using UnityEngine;
using UnityEngine.UI;

public class ClearFields : MonoBehaviour
{
    public InputField UsernameField;
    public InputField PasswordField;

    public void Clear()
    {
        UsernameField.text = String.Empty;
        PasswordField.text = String.Empty;
    }

}