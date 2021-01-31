using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FogEffect : MonoBehaviour
{
    public Image fakeFogImage;
    public static FogEffect instance;

    private void Awake()
    {
        fakeFogImage.color = Color.white;
    }

    private void Start()
    {
        fakeFogImage.DOColor(new Color(1, 1, 1, 0), 3f).OnComplete(() => {
            fakeFogImage.gameObject.SetActive(false);
        });
    }
}
