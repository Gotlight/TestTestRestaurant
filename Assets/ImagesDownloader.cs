using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImagesDownloader : MonoBehaviour {

        public WWW www;
        public string url = "http://www.kamyab.ir/mostafa74/Mokhtalef/Walpapers/92-01-14/16-HD%20Wallpapers[WwW.KamYab.IR].jpg";              //TODO: Change baseURL to real one
        public bool Downloaded = false;
    


       
        // Use this for initialization
        void Start () {
            
            
        }
	
        // Update is called once per frame
        void Update () {
	    
        }

    public void Download()
    {
        StartCoroutine(LoadGalleryImages());
    }

        public IEnumerator LoadGalleryImages()
        {
            
            www = new WWW(url);

            // wait until the download is done
            yield return www;

            var texture = new Texture2D(16, 16, TextureFormat.RGB24, false);
            // assign the downloaded image to the main texture of the object
            www.LoadImageIntoTexture(texture);

            var rc = new Rect(0, 0, texture.width, texture.height);
            var vc = new Vector2(0.5f, 0.5f);
            Sprite sp = Sprite.Create(texture, rc, vc);
            
            DumbSingleton.Instance.organization.GallerySprite = sp;
        }
    
    }
