using System;
using System.Globalization;
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
    
    public void Reserve()
    {
        StartCoroutine(PlaceTableReservation());
    }

    public IEnumerator PlaceTableReservation()
    {
        if (!PlayerPrefs.GetString("User id").Equals(String.Empty))
        {
            var datetime = DateTime.ParseExact(timeLabel.text, "HH:mm", CultureInfo.InvariantCulture);
            int personsCount = Convert.ToInt32(personCountLabel.text);
            var treservation = new TableReservation {AspNetUserID = PlayerPrefs.GetString("User id"), OrganizationID = DumbSingleton.Instance.organization.ID, PersonsCount = personsCount, ReservationDateTime = datetime};

            var headers = new Hashtable {{"Content-Type", "application/json"}};
            var body = Encoding.UTF8.GetBytes(
                JsonMapper.ToJson(treservation));
            var www = new WWW(Url, body, headers);

            yield return www;

            Debug.Log(Convert.ToBoolean(www.error) ? www.error : www.text);
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