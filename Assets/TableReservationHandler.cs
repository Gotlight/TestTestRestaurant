using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Text;
using LitJson;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TableReservationHandler : MonoBehaviour
{

    private bool IsLoggedIn;

    public Text timeLabel;
    public Text personCountLabel;
    private String Timetext;
    private String PersonsCountText;
    private String Url = "http://www.grosseto.somee.com/api/TableReservation";    //TODO: Change to hosting URL
    
    void Start()
    {
        Timetext = timeLabel.text;
        PersonsCountText = personCountLabel.text;
    }

    public void Reserve()
    {
        StartCoroutine(PlaceTableReservation());
    }

    public IEnumerator PlaceTableReservation()
    {
        if (!PlayerPrefs.GetString("User id").Equals(String.Empty))
        {
            var datetime = DateTime.ParseExact(Timetext, "HH:mm", CultureInfo.InvariantCulture);
            int personsCount = Convert.ToInt32(PersonsCountText);
            var treservation = new TableReservation();
            treservation.AspNetUserID = PlayerPrefs.GetString("User id");
            treservation.OrganizationID = DumbSingleton.Instance.organization.ID;
            treservation.PersonsCount = personsCount;
            treservation.ReservationDateTime = datetime;

            var headers = new Hashtable();
            headers.Add("Content-Type", "application/json");
            var body = Encoding.UTF8.GetBytes(
                JsonMapper.ToJson(treservation));
            var www = new WWW(Url, body, headers);

            yield return www;

            if (Convert.ToBoolean(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.text);
            }
        }
    }
}

    [Serializable]
    public class TableReservation
    {
        public string AspNetUserID;
        public string OrganizationID;
        public int PersonsCount;
        public DateTime ReservationDateTime;
    }