using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimePicker : MonoBehaviour
{
    private InputField _fieldToSet;

    void Start()
    {
        StartCoroutine(WaitPickAndClose());
    }

    IEnumerator WaitPickAndClose()
    {
        yield return new WaitForSeconds(2);
    }

    public void Init(InputField fieldToSet)
    {
        _fieldToSet = fieldToSet;
    }
}