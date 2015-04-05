using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
	void Update () {
	    if (Input.GetKey(KeyCode.Escape)) 
	    {
	        GetComponentInParent<GoToScreen>().GoToNextScreen();
	    }
	}
}
