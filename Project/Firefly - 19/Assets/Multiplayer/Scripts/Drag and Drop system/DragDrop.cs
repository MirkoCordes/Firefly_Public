using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop: MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public GameObject slot;
    private ItemSlot itemSlot;

    SpawnEnemiesOnClick spawnEnemiesOnClick;
    //Touch touch;
    //Vector3 touchPosition;

    public GameObject DragOverlay;

    public bool handIsSet;

    private void Awake()
    {
        itemSlot = slot.GetComponent<ItemSlot>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        spawnEnemiesOnClick = SpawnEnemiesOnClick.FindObjectOfType<SpawnEnemiesOnClick>();
        //DragOverlay.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragOverlay.SetActive(true);
        //Debug.Log("On Begin Drag");
        canvasGroup.alpha = 0.6f;
        GetComponent<Transform>().localScale = new Vector3(0.75f, 0.75f, 1);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On Drag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("On End Drag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        
        Vector3 vect = Camera.main.ScreenToWorldPoint(Input.mousePosition); //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
        if (!itemSlot.IsNull())
        {
            if (handIsSet)
            {
                spawnEnemiesOnClick.OnClickSpawnHand(vect);
            }
            else
            {
                spawnEnemiesOnClick.OnClickSpawnSwatter(vect);
            }
        }
        
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
        GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1);
        DragOverlay.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("On Pointer Down");
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    void FixedUpdate()
    {
        /*if (touch.tapCount > 0)
        {
            touchPosition = touch.position;
        }*/
    }
}
