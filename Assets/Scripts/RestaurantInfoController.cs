using System;
using System.Reflection.Emit;
using Assets;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class RestaurantInfoController : MonoBehaviour
{
    public Text RestaurantNameText;
    public Image Scene1;
    public Image Scene2;
    public String RestaurantName;
    public Canvas canvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetRestaurantInfo()
    {
        var infoDeserializer = Scene2.GetComponent<OrganizationInfoDeserializer>();
        var itemDeserializer = Scene2.GetComponent<MenuItemDeserializer>();
        if (DumbSingleton.Instance.downloaded != true && !infoDeserializer.Downloaded)                                                 // TODO: CHANGE TO SOME OTHER CONDITION
        {
//            
//            if (a != null) // check if 
//            {
//                
                infoDeserializer.Download("cz");                                            //  TODO: CHANGE ARGUMENT TO USER'S LANGUAGECODE
                itemDeserializer.Download("cz");                                            //  TODO: CHANGE ARGUMENT TO USER'S LANGUAGECODE
//                RestaurantNameText.text = a.OrganizationName;
//            }
            DumbSingleton.Instance.downloaded = true;
        }
            var a =
                Scene1.GetComponent<OrganizationDeserializer>()
                    .organizations.data.Find(x => x.OrganizationName == RestaurantName);
            canvas.GetComponent<DumbSingleton>().organization = a;
            RestaurantNameText.text = a.OrganizationName;

    }
}
