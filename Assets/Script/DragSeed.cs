using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BitBenderGames;
public class DragSeed : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startPosition;
    [SerializeField] public GameObject obSeed;
    private GameObject ob;
    public static DragSeed instance;
    public static int IdSeed;
    void Awake()
    {
        instance = this;
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        MobileTouchCamera.checkCamFollow = true;
        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        obSeed.GetComponent<SpriteRenderer>().sprite = ManagerData.instance.dataCay.data[IdSeed].Seed;
        ob = Instantiate(obSeed, startPosition, Quaternion.identity);
        DialogTrongCay.instance.CloseDialog();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ob != null)
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            ob.transform.position = startPosition;
            ob.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y, 0);
        }
        
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ob != null)
        {
            Destroy(ob);
            MobileTouchCamera.checkCamFollow = false;
        }

    }

}
