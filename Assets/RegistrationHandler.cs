using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class User
{
    public string username { get; set; }
    public string password { get; set; }
}

public class RegistrationHandler : MonoBehaviour
{

    public InputField UsernameField;
    public InputField PasswordField;
    private const string Url = "http://localhost:24024/api/AspNetUser";

    public void Register()
    {
        StartCoroutine(RegisterUser());
    }

    private IEnumerator RegisterUser()
    {
        var username = UsernameField.text;
        var password = PasswordField.text;
        var usr = new User {username = username, password = password};

        var headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        var body = Encoding.UTF8.GetBytes(
            JsonMapper.ToJson(usr));
        var www = new WWW(Url, body, headers);

        yield return www;
//        yield www;

        if (Convert.ToBoolean(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
        // Create a Web Form
//        var form = new WWWForm();
//        form.AddField("username", UsernameField.text);
//        form.AddField("password", PasswordField.text);
////        form.AddField("ConfirmPassword", PasswordField.text);
//
//        // Upload to a cgi script
//        var a = new WWW(Url, form);

//        yield return a;
    }
}

