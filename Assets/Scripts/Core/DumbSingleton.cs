using Assets;
using UnityEngine;

public class DumbSingleton : MonoBehaviour
{
    public static DumbSingleton Instance { get; private set; }
    public ModelOrganization organization;
    public string parentID;
    public bool downloaded;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);

        Instance = this;
    }
}