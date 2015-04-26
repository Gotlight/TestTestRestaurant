using UnityEngine;

public static class HierarchyExtensions
{
    public static T InstantiateAsChild<T>(this Transform parent, T childPrefab) where T: Component
    {
        var t = (( GameObject) GameObject.Instantiate(childPrefab.gameObject)).transform;
        t.SetParent(parent, false);
        t.gameObject.layer = parent.gameObject.layer;

        return t.GetComponent<T>();
    }
}