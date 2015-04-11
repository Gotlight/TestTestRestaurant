﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = System.Random;

public class QRCodeGetter : MonoBehaviour
{

    public Image QRimage;
    public string UserId;
    public string Url = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=";
    public Text Username;
    public Text Balance;
    private WWW www;
	// Use this for initialization
	void Start ()
	{
	    Download();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        UserId = PlayerPrefs.GetString("User id");
        Balance.text = UnityEngine.Random.Range(0, 2500).ToString();
        
    }

    public void Download()
    {
        StartCoroutine(LoadQRImage());
    }

    public IEnumerator LoadQRImage()
    {

        www = new WWW(Url+UserId);

        // wait until the download is done
        yield return www;

        var texture = new Texture2D(16, 16, TextureFormat.RGB24, false);
        // assign the downloaded image to the main texture of the object
        www.LoadImageIntoTexture(texture);

        var rc = new Rect(0, 0, texture.width, texture.height);
        var vc = new Vector2(0.5f, 0.5f);
        Sprite sp = Sprite.Create(texture, rc, vc);
        QRimage.GetComponent<Image>().sprite = sp;
        Username.text = PlayerPrefs.GetString("User name");
    }
}
