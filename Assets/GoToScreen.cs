using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoToScreen : MonoBehaviour
{

    public Image NextScreen;
    public Image CurrentScreen;

    public void GoToNextScreen()
    {
        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);
    }

    public void GoToNextScreenWithoutDeactivationofCurrent()
    {
        NextScreen.gameObject.SetActive(true);
    }
}
