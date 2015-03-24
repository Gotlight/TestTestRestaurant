using System.Collections.Generic;
using System.Linq;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableMenuCategoryList : MonoBehaviour
{
    public RowImageTextButton MenuCategoryPrefab;
    public Text PriceForItem;
    public LayoutGroup Panel;
    public Text ScreenName;
    public string MenucategoryId;
    public string BackButtonMenuCategoryID;
    public Button BackButton;
    public Button BackButtonFirstLevel;
    public Image Details;

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
            var scrollableMenuScript = view.GetComponentInParent<ScrollableMenuCategoryList>();
            scrollableMenuScript.Panel = Panel;
            scrollableMenuScript.MenuCategoryPrefab = MenuCategoryPrefab;
            scrollableMenuScript.ScreenName = ScreenName;
            scrollableMenuScript.MenucategoryId = m.ID;
            scrollableMenuScript.BackButton = BackButton;
            scrollableMenuScript.BackButtonFirstLevel = BackButtonFirstLevel;
        }
        
    }

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
            var scrollableMenuScript = view.GetComponentInParent<ScrollableMenuCategoryList>();
            scrollableMenuScript.Panel = Panel;
            scrollableMenuScript.MenuCategoryPrefab = MenuCategoryPrefab;
            scrollableMenuScript.ScreenName = ScreenName;
            scrollableMenuScript.MenucategoryId = i.MenuCatalogID;
            scrollableMenuScript.BackButton = BackButton;
            scrollableMenuScript.BackButtonFirstLevel = BackButtonFirstLevel;
            Details.gameObject.SetActive(false);
            PriceForItem.gameObject.SetActive(true);
        }
    }

    public void ManageMenuFirstLevel()
    {
        ScreenName.text = DumbSingleton.Instance.organization.OrganizationName + " menu list";   // TODO Localization
        var org = DumbSingleton.Instance.organization;
        var list = org.Catalogs.data.Where(x => x.ParentID == "00000000-0000-0000-0000-000000000000");

            Fill(list);
        if (BackButtonMenuCategoryID.Equals(""))
        {
            BackButtonFirstLevel.gameObject.SetActive(true);
            BackButton.gameObject.SetActive(false);
        }
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
        if (BackButtonMenuCategoryID.Equals(""))
        {
            list = org.Catalogs.data.Where(x => x.ParentID == MenucategoryId);
            BackButton.GetComponent<ScrollableMenuCategoryList>().BackButtonMenuCategoryID = MenucategoryId;
            ScreenName.text = org.Catalogs.data.Where(x => x.ID == MenucategoryId).First().MenuCatalogLocalizationName;

            foreach (var menuRow in list)
            {
                var item = org.Items.data.First(x => x.MenuCatalogID == menuRow.ID);
                itemList.Add(item);
                if (itemList.Count == org.Items.data.Count)
                    break;
            }
        }
        else                                        // the branch for Back button
        {
            if (BackButtonMenuCategoryID == "00000000-0000-0000-0000-000000000000")
            {
                BackButtonFirstLevel.gameObject.SetActive(true);
                BackButton.gameObject.SetActive(false);
                BackButtonFirstLevel.GetComponent<GoToScreen>().GoToNextScreen();

            }
            else 
            {
                id = org.Catalogs.data.Where(x => x.ID == BackButtonMenuCategoryID).First().ParentID;
               
                    list = org.Catalogs.data.Where(x => x.ParentID == id);
                    BackButtonMenuCategoryID = id;
                if (id != "00000000-0000-0000-0000-000000000000")
                {
                    ScreenName.text = org.Catalogs.data.First(x => x.ID == id).MenuCatalogLocalizationName;
                }
                else
                {
                    ScreenName.text = DumbSingleton.Instance.organization.OrganizationName + " menu list"; 
                }
                
                
            }
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
    


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ManageMenuSecondLevel();
        }
    }

    void Start()
    {
//        var data = DumbSingleton.Instance.organization;
    }
}