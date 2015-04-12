using System;
using System.Globalization;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TableReservation : MonoBehaviour
{
    public InputField UsernameField;
    public InputField TimeField;
    public InputField PersonsCountField;
    public Text ScreenName;
    public bool IsLoggedIn;
    void OnEnable()
    {
        var userFullName = PlayerPrefs.GetString("User name");
        GetComponentInChildren<Text>().text = DumbSingleton.Instance.organization.OrganizationName + " - reservation";
        if (!userFullName.Equals(String.Empty))
        {
            IsLoggedIn = true;
            UsernameField.GetComponent<InputField>().text = userFullName;
        }
        else
        {
            IsLoggedIn = false;
        }
        TimeField.GetComponent<InputField>().text = DateTime.Now.AddHours(2.0)
            .ToString("HH:mm", CultureInfo.CurrentCulture);
        PersonsCountField.GetComponent<InputField>().text = 2.ToString();
    }

    void OnDisable()
    {
        UsernameField.GetComponent<InputField>().text = String.Empty;
    }
    

}
