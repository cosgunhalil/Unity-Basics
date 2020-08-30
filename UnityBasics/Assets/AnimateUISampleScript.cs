using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateUISampleScript : MonoBehaviour
{
    [SerializeField]
    private RectTransform targetRectTransform;
    private RectTransform coinRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        coinRectTransform = GetComponent<RectTransform>();

        coinRectTransform.DOAnchorPos(targetRectTransform.anchoredPosition, 3f);

    }
}
