using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CayGrow : MonoBehaviour
{
    //private GameObject[] gameObjects;
    [SerializeField] SpriteRenderer thisSprite;
    int timeCreate;
    int timeGrow;
    DataCay.Cay _cay;
    DataCay.Cay[] _data;
    int _id;
    
    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        _data = ManagerData.instance.dataCay.data;
        _id = int.Parse(this.name);
        foreach (DataCay.Cay a in _data)
        {
            if (_id == a.Id)
            {
                _cay = a;
                timeCreate = (int)_cay.TimeCreate * 10;
                timeGrow = (int)_cay.TimeCreate * 10;
            }
        }
        StartCoroutine(TrongCay());
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.SetActive(false);
    }

    IEnumerator TrongCay()
    {
        yield return new WaitForSeconds(1f);
        timeCreate--;
        if (timeCreate > 0)
        {
            if (timeCreate <= (timeGrow / 1.5f) && timeCreate > (timeGrow) / 2f)
            {
                thisSprite.sprite = _cay.Img1;
            }
            else if (timeCreate <= (timeGrow / 2f) && timeCreate > 0)
            {
                thisSprite.sprite = _cay.Img2;
            }
            StartCoroutine(TrongCay());
        }
        else
        {

            thisSprite.sprite = _cay.Img3;

        }
    }


}
