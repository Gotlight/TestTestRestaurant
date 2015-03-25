using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TableReservation : MonoBehaviour
{

    public Text ScreenName;
    void OnEnable()
    {
        GetComponentInChildren<Text>().text = DumbSingleton.Instance.organization.OrganizationName + " reservation";
    }
}
