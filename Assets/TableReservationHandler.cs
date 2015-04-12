using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TableReservationHandler : MonoBehaviour
{

    public Image Screen;
    private bool IsLoggedIn;
    void OnEnable()
    {
        IsLoggedIn = Screen.GetComponent<TableReservation>().IsLoggedIn;
    }

    public void PlaceTableReservation()
    {
        if (IsLoggedIn)
        {
            
        }
        else
        {
            
        }
    }
}
