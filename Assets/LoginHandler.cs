﻿using System;
using System.Text;
using Assets.Scripts;
using LitJson;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour {

    public InputField UsernameField;
    public InputField PasswordField;
    private const string Url = "http://localhost:24024/api/AspNetUser/Login";


    public void Login()
    {
        StartCoroutine(LoginUser());
    }

    private IEnumerator LoginUser()
    {
        var username = UsernameField.text;
        var password = PasswordField.text;
        var usr = new User { username = username, password = password };

        var headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        var body = Encoding.UTF8.GetBytes(
            JsonMapper.ToJson(usr));
        var www = new WWW(Url, body, headers);

        yield return www;

        if (Convert.ToBoolean(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);



            UserData LoggedInUser = JsonMapper.ToObject<UserData>(www.text);
            PlayerPrefs.SetString("User id", LoggedInUser.Id);
            //            
            PlayerPrefs.SetString("User name", LoggedInUser.UserName);


            WWWForm form = new WWWForm();
            form.AddField("name", "value");
            headers = form.headers;
            byte[] rawData = form.data;

            var encoding = new System.Text.UTF8Encoding();
            headers = new Hashtable();
            headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string b = "grant_type=password" + "&username=" + usr.username + "&password=" + usr.password;
            www = new WWW("http://localhost:24024/token", encoding.GetBytes(b), headers);
            yield return www;

            UserToken loggedInUserToken = JsonMapper.ToObject<UserToken>(www.text);
            PlayerPrefs.SetString("Access token", loggedInUserToken.access_token);
            Debug.Log(loggedInUserToken.access_token);
            GetComponent<GoToScreen>().GoToNextScreen();
        }
    }

}
