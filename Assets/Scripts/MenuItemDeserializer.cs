using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LitJson;
using UnityEngine;
using UnityEngine.UI;



public class MenuItems
{
    public List<ModelItem> data { get; set; }
}

public class MenuItemDeserializer : MonoBehaviour
{
    public MenuItems items;
    public string baseUrl = "http://www.grosseto.somee.com/api/organization";       
    private string langCode;
    public WWW www;
    public bool Downloaded = false;
    public Image Scene1;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponentInParent<GoToScreen>().GoToNextScreen();
        }
    }

    public void Download(String LangCode)
    {
        langCode = LangCode;
        StartCoroutine(LoadAndDeserialize());
    }

    public IEnumerator LoadAndDeserialize()
    {
        var orgs =
            Scene1.GetComponent<OrganizationDeserializer>()
                .organizations.data;
        String url;
        foreach (var o in orgs)
        {
            url = baseUrl + '/' + o.ID + '/' + langCode + '/' + "menuitem";
            www = new WWW(url);
            yield return www;
            items = new MenuItems { data = JsonMapper.ToObject<List<ModelItem>>(www.text) };
            if (items.data != null)
            {
                o.Items = items;
            }
            else
            {
                Debug.LogError(o.OrganizationName);
            }
        }
        Downloaded = true;


    }
}