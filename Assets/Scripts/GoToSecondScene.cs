using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoToSecondScene : MonoBehaviour
{

    public Image scene1;
    public Image scene2;
	// Use this for initialization
	void Start () {
//        scene2.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void goToSecondScene()
    {
        scene1.gameObject.SetActive(false);
        scene2.gameObject.SetActive(true);
    }

    public void goToFirstScene()
    {
        scene2.gameObject.SetActive(false);
        scene1.gameObject.SetActive(true);

//        String orgID = scene2.GetComponent<OrganizationInfoDeserializer>().OrganizationID;
//        var a =
//            scene1.GetComponent<OrganizationDeserializer>()
//                .organizations.data.Find(x => x.ID == orgID).Catalogs.data;
        
//        String s = a.Find(x => x.MenuCatalogLocalizationName == "Paté with rosted almonds").ID;
//        foreach (var cat in a)
//        {
//            Debug.Log(cat.MenuCatalogLocalizationName); 
//        }
        
    }
}
