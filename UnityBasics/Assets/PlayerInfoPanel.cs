using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField]
    private Canvas currentCanvas;
    private RectTransform infoPanelRectTransform;

    //Player Info size'ı canvas boyutunun %50'si olsun.

    // Start is called before the first frame update
    void Start()
    {
        infoPanelRectTransform = GetComponent<RectTransform>();

        var screenSize = currentCanvas.GetComponent<RectTransform>().sizeDelta;
        Debug.Log("screenSize = " + screenSize);

        SetHeight(screenSize.x * .5f, true);

        ActivateAnimation();

    }

    public void SetHeight(float height, bool preserveAspect)
    {
        if (preserveAspect)
        {
            var currentHeight = infoPanelRectTransform.sizeDelta.y;
            var currentWidth = infoPanelRectTransform.sizeDelta.x;
            var futureHeight = height;
            var futureWidth = (currentWidth * futureHeight) / currentHeight;

            infoPanelRectTransform.sizeDelta = new Vector2(futureWidth, futureHeight);
        }
        else
        {
            infoPanelRectTransform.sizeDelta = new Vector2(infoPanelRectTransform.sizeDelta.x, height);
        }

    }

    private void ActivateAnimation()
    {
        var currentAnchorPosition = infoPanelRectTransform.anchoredPosition;

        var targetPosition = new Vector3(10,10,0);

        infoPanelRectTransform.DOAnchorPos(targetPosition,.3f).SetEase(Ease.OutBounce);
    }
}
