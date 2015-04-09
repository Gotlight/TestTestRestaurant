using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuCatalogButtonLevelDown : MonoBehaviour {
   
    
    public RowImageTextButton MenuCategoryPrefab;
    public Text PriceForItem;
    public LayoutGroup Panel;
    public Text ScreenName;
    public string MenucategoryId;
    public Button BackButton;
    public Button BackButtonFirstLevel;
    public Image Details;

    public void Fill(IEnumerable<ModelItem> items)
    {
        var t = Panel.transform;

        foreach (Transform child in t)
        {
            Destroy(child.gameObject);
        }

        foreach (var i in items)
        {
            var view = t.InstantiateAsChild(MenuCategoryPrefab);
            view.Text = i.MenuItemLocalizationName;
            var menuLevelButton = view.GetComponentInParent<MenuCatalogButtonLevelDown>();
            menuLevelButton.Panel = Panel;
            menuLevelButton.MenuCategoryPrefab = MenuCategoryPrefab;
            menuLevelButton.ScreenName = ScreenName;
            menuLevelButton.MenucategoryId = i.MenuCatalogID;
            menuLevelButton.BackButton = BackButton;
            menuLevelButton.BackButtonFirstLevel = BackButtonFirstLevel;
            Details.gameObject.SetActive(false);
            PriceForItem.gameObject.SetActive(true);
        }
    }

    public void Fill(IEnumerable<ModelMenu> menus)
    {
        var t = Panel.transform;

        foreach (Transform child in t)
        {
            Destroy(child.gameObject);
        }

        foreach (var m in menus)
        {
            var view = t.InstantiateAsChild(MenuCategoryPrefab);
            view.Text = m.MenuCatalogLocalizationName;
            var menuLevelButton = view.GetComponentInParent<MenuCatalogButtonLevelDown>();
            menuLevelButton.Panel = Panel;
            menuLevelButton.MenuCategoryPrefab = MenuCategoryPrefab;
            menuLevelButton.ScreenName = ScreenName;
            menuLevelButton.MenucategoryId = m.ID;
            menuLevelButton.BackButton = BackButton;
            menuLevelButton.BackButtonFirstLevel = BackButtonFirstLevel;
        }

    }


    public void ManageMenuFirstLevel()
    {
        ScreenName.text = DumbSingleton.Instance.organization.OrganizationName + " menu list";   // TODO Localization
        var org = DumbSingleton.Instance.organization;
        var list = org.Catalogs.data.Where(x => x.ParentID == "00000000-0000-0000-0000-000000000000");
//        BackButton.GetComponent<MenuCatalogButtonLevelDown>().
        Fill(list);

        BackButtonFirstLevel.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(false);
    }

    public void ManageMenuSecondLevel()
    {

        BackButtonFirstLevel.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(true);
        //        var  = DumbSingleton.Instance.parentID;
        var org = DumbSingleton.Instance.organization;
        IEnumerable<ModelMenu> list = null;
        string id;
        var itemList = new List<ModelItem>();
        
            list = org.Catalogs.data.Where(x => x.ParentID == MenucategoryId);
//            BackButton.GetComponent<MenuCatalogButtonLevelDown>(). = MenucategoryId;
            ScreenName.text = org.Catalogs.data.Where(x => x.ID == MenucategoryId).First().MenuCatalogLocalizationName;

            foreach (var menuRow in list)
            {
                var item = org.Items.data.First(x => x.MenuCatalogID == menuRow.ID);
                itemList.Add(item);
                if (itemList.Count == org.Items.data.Count)
                    break;
            }
        

        if (itemList.Count() != 0)
        {
            Fill(itemList);
        }
        else if (list != null && list.Count() != 0)
        {

            Fill(list);
        }

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
