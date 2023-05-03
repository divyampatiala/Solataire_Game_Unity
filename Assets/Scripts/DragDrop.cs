using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform rectTransform;
    public Vector3 currentPosition;
    public CanvasGroup canvasGroup;
    [SerializeField]
    public Canvas canvas;
    public GridLayoutGroup holderGridLayoutGroup;
  

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        currentPosition = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }
    public void OnPointerDown(PointerEventData ped)
    {
    }
    public void OnBeginDrag(PointerEventData ped)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData ped)
    {
        rectTransform.anchoredPosition += ped.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData ped)
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
        rectTransform.anchoredPosition = currentPosition;
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        if (this.GetComponent<Image>().color.a == 0)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
