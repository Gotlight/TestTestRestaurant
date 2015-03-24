using System;
using System.Net.Mime;
using Assets;
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollableGalleryList : MonoBehaviour
{
    public Image Screen4;
    public Text ScreenName;
    public LayoutGroup Panel;
    public RowImageTextButton RowImagePrefab;

    public void Fill(Sprite toFill)
    {
        var t = Panel.transform;
        var view = t.InstantiateAsChild(RowImagePrefab);
       
        var scrollableMenuScript = view.GetComponentInParent<ScrollableMenuCategoryList>();
        scrollableMenuScript.Panel = Panel;
        view.GetComponent<Image>().sprite = toFill;
    }

    public void ManageGalleryPreviewList(){
    
        ScreenName.text = DumbSingleton.Instance.organization.OrganizationName + " Gallery";
        var  imgd = Screen4.GetComponent<ImagesDownloader>();
        imgd.GetComponent<ImagesDownloader>().Download();
        Fill(DumbSingleton.Instance.organization.GallerySprite);
    }

    public void ManageFullScreenList()
    {
        
    }
}
