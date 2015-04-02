using System;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;

public class MenuCatalogs
{
    public List<ModelMenu> data { get; set; }
}


public class OrganizationInfoDeserializer : MonoBehaviour
{
    public MenuCatalogs catalogs;
    public string baseUrl = "http://localhost:24024/api/organization";              //TODO: Change baseURL to real one
    private string langCode;
    public WWW www;
    public bool Downloaded = false;
    public Image Scene1;

    void Start()
    {
    }


    public void Download(String LangCode)
    {
        langCode = LangCode;
        StartCoroutine  (LoadAndDeserialize());
    }

    public IEnumerator LoadAndDeserialize()
    {
        var orgs =
            Scene1.GetComponent<OrganizationDeserializer>()
                .organizations.data;
        String url;
        foreach (var o in orgs)
        {
                url = baseUrl + '/' + o.ID + '/' + langCode + '/' + "menucatalog";
                www = new WWW(url);
                yield return www;
                catalogs = new MenuCatalogs {data = JsonMapper.ToObject<List<ModelMenu>>(www.text)};
            if (catalogs.data != null)
            {
                o.Catalogs = catalogs;
                Debug.Log(o.OrganizationName);
                Debug.Log(o.Catalogs.data.Count);
            }
            else
            {
                Debug.LogError(o.OrganizationName);
            }
        }
        Downloaded = true;


    }
}