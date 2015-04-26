using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GoToClientZone: MonoBehaviour
    {
        public Image MainScreen;
        public Image LoginScreen;
        public Image ClientZoneScreen;

        public void GoToMyClientZone()
        {
            MainScreen.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("User id") != string.Empty)
                ClientZoneScreen.gameObject.SetActive(true);
            else
                LoginScreen.gameObject.SetActive(true);
        }
    }
}