using System.Collections.Generic;
using Assets;
using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;


public class Organizations
{
    public List<ModelOrganization> data { get; set; }
 
}

public class OrganizationDeserializer : MonoBehaviour
{
    public Organizations organizations = new Organizations();

    public string url = "http://www.grosseto.somee.com/api/organization";
    
    public WWW www;

    void Start()
    {
        Download();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Download () { 
        StartCoroutine(LoadAndDeserialize()); //In C#, you have to explicitly start a coroutine. 
    }

    private IEnumerator LoadAndDeserialize()
    {
        www = new WWW(url);
        yield return www;

        organizations.data = JsonMapper.ToObject<List<ModelOrganization>>(www.text);
        if (organizations.data.Count != 0)
            Debug.Log("Organizations deserialized successfully!");
        
    }
}