using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowDirectionsForRestaurant : MonoBehaviour
{

    public GameObject VinohradyInfo;
    public GameObject BiancoRossoInfo;
    public GameObject BrumlovkaInfo;
    public GameObject DejviceInfo;
    public GameObject PruhoniceInfo;
    public GameObject MarinaInfo;
    public Text ScreenName;

    public void Load()
    {
        var activeRestaurant = DumbSingleton.Instance.organization.OrganizationName;
        switch (activeRestaurant)
        {
            case "Vinohrady":
                VinohradyInfo.gameObject.SetActive(true);
                BiancoRossoInfo.gameObject.SetActive(false);
                BrumlovkaInfo.gameObject.SetActive(false);
                DejviceInfo.gameObject.SetActive(false);
                PruhoniceInfo.gameObject.SetActive(false);
                MarinaInfo.gameObject.SetActive(false);
                break;
            case "Bianco Rosso":
                BiancoRossoInfo.gameObject.SetActive(true);
                VinohradyInfo.gameObject.SetActive(false);
                BrumlovkaInfo.gameObject.SetActive(false);
                DejviceInfo.gameObject.SetActive(false);
                PruhoniceInfo.gameObject.SetActive(false);
                MarinaInfo.gameObject.SetActive(false);
                break;
            case "Brumlovka":
                BrumlovkaInfo.gameObject.SetActive(true);
                BiancoRossoInfo.gameObject.SetActive(false);
                VinohradyInfo.gameObject.SetActive(false);
                DejviceInfo.gameObject.SetActive(false);
                PruhoniceInfo.gameObject.SetActive(false);
                MarinaInfo.gameObject.SetActive(false);
                break;
            case "Dejvice":
                DejviceInfo.gameObject.SetActive(true);
                BrumlovkaInfo.gameObject.SetActive(false);
                BiancoRossoInfo.gameObject.SetActive(false);
                VinohradyInfo.gameObject.SetActive(false);
                PruhoniceInfo.gameObject.SetActive(false);
                MarinaInfo.gameObject.SetActive(false);
                break;
            case "Průhonice":
                PruhoniceInfo.gameObject.SetActive(true);
                DejviceInfo.gameObject.SetActive(false);
                BrumlovkaInfo.gameObject.SetActive(false);
                BiancoRossoInfo.gameObject.SetActive(false);
                VinohradyInfo.gameObject.SetActive(false);
                MarinaInfo.gameObject.SetActive(false);
                break;
            case "Marina":
                MarinaInfo.gameObject.SetActive(true);
                PruhoniceInfo.gameObject.SetActive(false);
                DejviceInfo.gameObject.SetActive(false);
                BrumlovkaInfo.gameObject.SetActive(false);
                BiancoRossoInfo.gameObject.SetActive(false);
                VinohradyInfo.gameObject.SetActive(false);
                break;
        }
        ScreenName.text = activeRestaurant + " - directions";
    }
}
