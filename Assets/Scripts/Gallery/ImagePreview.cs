using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImagePreview : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Init(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.SetNativeSize();
    }

    IEnumerator WaitAndClose(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        Destroy(gameObject);
    }

    public void Close()
    {
        var a = GetComponent<Animator>();
        a.SetTrigger("CloseTrigger");
        StartCoroutine(WaitAndClose(.33f));
    }
}