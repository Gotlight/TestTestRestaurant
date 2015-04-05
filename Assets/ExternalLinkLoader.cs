using UnityEngine;
using System.Collections;

public class ExternalLinkLoader : MonoBehaviour {

    public void RedirectToLink()
    {
        if (Application.platform == RuntimePlatform.Android)
            Application.OpenURL("https://www.google.cz/maps/search/50.0745494,14.437248919");
    }
}
