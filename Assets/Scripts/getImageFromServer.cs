using UnityEngine;
using UnityEngine.UI;

public class getImageFromServer : MonoBehaviour {
    //3e166d6b-8502-4411-b4ba-6ac54a3f3337
	// Use this for initialization
    public string Url = "http://www.grosseto.somee.com/api/organization/3e166d6b-8502-4411-b4ba-6ac54a3f3337/organizationlogo";
    public Button Butt;
    void Start()
    {
        
//        var bindata = Resources.Load("organizationlogo") as TextAsset;
//        var tt = Resources.Load("1080x1920") as Texture2D;
//        var tex = new Texture2D(1, 1);
////        tex.LoadImage(bindata.bytes);
//        renderer.material.mainTexture = tt;
//        var rc = new Rect(0, 0, tt.width, tt.height);
//        var vc = new Vector2(0.5f, 0.5f);
//        var sp = Sprite.Create(tt, rc, vc);
//        
//         var btn = gameObject.GetComponent<Button>();
//        btn.image.sprite = sp;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
