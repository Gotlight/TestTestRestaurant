using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackButtonHandler : MonoBehaviour
{
    
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Escape)) 
	    {
	        GetComponentInParent<GoToScreen>().GoToNextScreen();
	    }
	}
}
