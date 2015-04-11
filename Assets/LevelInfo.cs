using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelInfo : MonoBehaviour
{
    public Stack<ModelMenu> LevelInfoStack;
    public Button BackButtonFirstLevel;
    public Button BackButton;
    public Text ScreenName;
    public LayoutGroup Panel;
    public RowImageTextButton MenuCategoryPrefab;

	void Awake () {
	    LevelInfoStack = new Stack<ModelMenu>();
	}

    void OnEnable()
    {
        Debug.Log(PlayerPrefs.GetString("Login token"));
        var menuLevel = new ModelMenu
        {
            ID = "00000000-0000-0000-0000-000000000000",
            MenuCatalogLocalizationName = DumbSingleton.Instance.organization.OrganizationName + " menu list"
        };
        GoToLevel(menuLevel);  
    }

    void OnDisable()
    {
      LevelInfoStack.Clear();   
    }

    public void GoToLevel(ModelMenu level = null)
    {
        if (level != null && level.ID == "00000000-0000-0000-0000-000000000000")
        {
            BackButtonFirstLevel.gameObject.SetActive(true);
            BackButton.gameObject.SetActive(false);
        }
        else
        {
            BackButtonFirstLevel.gameObject.SetActive(false);
            BackButton.gameObject.SetActive(true);
            BackButton.GetComponent<RowImageTextButton>().LevelInfoScript = this;
        }
        
        var org = DumbSingleton.Instance.organization;
        IEnumerable<ModelMenu> list = null;
        string id;
        var itemList = new List<ModelItem>();
        if (level != null)
        {
            list = org.Catalogs.data.Where(x => x.ParentID == level.ID);
            LevelInfoStack.Push(level);
            ScreenName.text = level.MenuCatalogLocalizationName;
            if (LevelInfoStack.Count == 3)
            {
                foreach (var menuRow in list)
                {
                    try
                    {
                        var item = org.Items.data.First(x => x.MenuCatalogID == menuRow.ID);
                        itemList.Add(item);
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    if (itemList.Count == org.Items.data.Count)
                        break;
                }
            }
        }
        else
        {
            LevelInfoStack.Pop();
            if (LevelInfoStack.Count != 0)
            {
                ScreenName.text = LevelInfoStack.First().MenuCatalogLocalizationName;
                list = org.Catalogs.data.Where(x => x.ParentID == LevelInfoStack.First().ID);
            }
            else
            {
                BackButtonFirstLevel.gameObject.SetActive(true);
                BackButton.gameObject.SetActive(false);
                BackButtonFirstLevel.GetComponent<GoToScreen>().GoToNextScreen();
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

    private void Fill(IEnumerable<ModelMenu> menus)
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
            view.LevelInfoScript = this;
            view.MyInfo = m;
        }
    }

    private void Fill(List<ModelItem> items)
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
            view.LevelInfoScript = this;
            view.DetailsIcon.gameObject.SetActive(false);
            view.Price.gameObject.SetActive(true);
            view.GetComponentInParent<Button>().onClick.RemoveAllListeners();
        }
    }
}
