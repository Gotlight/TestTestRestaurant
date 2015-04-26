using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GalleryGridFill : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup ContentGrid;
    [SerializeField] private Image GridItemPrefab;
    public Text ScreenName;
    
    private string OrgName { get { return DumbSingleton.Instance.organization.OrganizationName; } }
    
    private Sprite[] Sprites
    {
        get
        {
            var dir = new DirectoryInfo("Assets/Resources/" + OrgName);
            DebugUtils.Assert(dir.Exists, "No directory for " + OrgName + " organization");
            return Resources.LoadAll<Sprite>(OrgName);
        }
    }

    private void OnEnable()
    {
        ScreenName.text = DumbSingleton.Instance.organization.OrganizationName + " - gallery";
        // clear content
        foreach (var child in ContentGrid.GetComponentsInChildren<Image>())
            Destroy(child.gameObject);

        var sprites = Sprites;
        for (var i = 0; i < sprites.Count(); i++)
        {
            var t = ContentGrid.transform.InstantiateAsChild<Image>(GridItemPrefab);
            t.sprite = sprites[i];
        }
    }
}