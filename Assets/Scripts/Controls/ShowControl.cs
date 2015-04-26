using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowControl : MonoBehaviour
{
    public void TimePicker(InputField fieldToSet)
    {
        InstantiateUi<TimePicker>("TimePicker").Init(fieldToSet);
    }

    public void GalleryPreview(Image image)
    {
        var gp = InstantiateUi<ImagePreview>("GalleryPreview");
        gp.Init(image.sprite);
    }

    public void GalleryIterator()
    {
        
    }

    private T InstantiateUi<T>(string controlName) where T : MonoBehaviour
    {
        const string root = "UIControls";
        var resource = Resources.Load(string.Format("{0}/{1}",root,controlName));
        DebugUtils.Assert(resource != null, string.Format("Prefab 'Resources/UIControls/{0}' not found", controlName));
        var t = (GameObject)Instantiate(resource);
        t.transform.SetParent(CanvasRoot, false);
        var result = t.GetComponent<T>();
        DebugUtils.Assert(result != null, string.Format("'Resources/UIControls/{0}' doesn't hae component {1}", controlName, typeof(T)));
        return result;
    }

    private static Transform _canvasRootCache;
    private static Transform CanvasRoot
    {
        get
        {
            if (!_canvasRootCache)
                _canvasRootCache = FindObjectOfType<CanvasScaler>().transform;
            return _canvasRootCache;
        }
    }

}