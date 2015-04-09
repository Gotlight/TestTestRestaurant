using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableGalleryList : MonoBehaviour
{
    public Image Screen2;
    public Image Screen4;
    public Text ScreenName;
    public LayoutGroup Panel;
    public GalleryPictureIconButton GalleryIconPrefab;

    IEnumerator Fill(Sprite toFill)
    {
        if (toFill == null)
            yield return new WaitForEndOfFrame();
        
        var t = Panel.transform;
        var view = t.InstantiateAsChild(GalleryIconPrefab);
        view.GetComponent<Image>().sprite = toFill;
        Screen2.gameObject.SetActive(false);
    }

    public void ManageGalleryPreviewList(){
    
        ScreenName.text = DumbSingleton.Instance.organization.OrganizationName + " Gallery";
        var  imgd = Screen4.GetComponent<ImagesDownloader>();
        imgd.GetComponent<ImagesDownloader>().Download();

        StartCoroutine(Fill(DumbSingleton.Instance.organization.GallerySprite));
    }

    public void ManageFullScreenList()
    {
        
    }
}
