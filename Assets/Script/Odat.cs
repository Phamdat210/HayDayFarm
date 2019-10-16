using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BitBenderGames;

public class Odat : MonoBehaviour
{
    SpriteRenderer thisSprite;
    int timeCreate;
    int timeGrow;
    public static int id, soLuong;
    public static Odat instance;
    int show = 0;
    public GameObject objThoiGian;
    public Text txtTime, txtThongBao;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        thisSprite.gameObject.SetActive(false);

    }

    public void setTime(int id)
    {
        timeCreate = ManagerData.instance.dataCay.data[id].TimeCreate * 10;
        timeGrow = ManagerData.instance.dataCay.data[id].TimeCreate * 10;
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.SetActive(false);
    }

    IEnumerator TrongCay()
    {
        Debug.Log("aaaaaaaaaaaa" + timeCreate);

        yield return new WaitForSeconds(1f);
        timeCreate--;
        txtTime.text = (timeCreate / 60).ToString() + " : " + (timeCreate % 60).ToString();
        if (timeCreate > 0)
        {
            if (timeCreate <= (timeGrow / 2f))
            {
                thisSprite.sprite = ManagerData.instance.dataCay.data[id].Img2;
            }
            show = 1;

            if (timeleft > 0)
            {
                timeleft--;

            } else
            {
                objThoiGian.gameObject.SetActive(false);
            }
            StartCoroutine(TrongCay());
        }
        else
        {

            thisSprite.sprite = ManagerData.instance.dataCay.data[id].Img3;
            show = 2;
        }
    }


    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            if (show == 0)
            {
                DialogTrongCay.instance.Open(gameObject);
                MobileTouchCamera.checkCamFollow = true;
                OpenDialog.instance.Close();

            }
            else if (show == 1)
            {
                ShowTime();
            }
            else if (show == 2)
            {
                thisSprite.gameObject.SetActive(false);
                show = 0;
                InventoryManager.number = InventoryManager.number + ManagerData.instance.dataCay.data[id].KinhNghiem;
                ManagerData.instance.dataCay.data[id].SoLuong = ManagerData.instance.dataCay.data[id].SoLuong + 5;
                GameObject _obj = Instantiate(ManagerData.instance.EffectPick);
                _obj.transform.SetParent(transform);
                _obj.transform.localPosition = Vector3.zero;
                Destroy(_obj, 2);
                transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("hg"))
        {
            if (show == 0)
            {
                if (InventoryManager.gold > ManagerData.instance.dataCay.data[DragSeed.IdSeed].GiaTien)
                {
                    thisSprite.gameObject.SetActive(true);
                    thisSprite.sprite = ManagerData.instance.dataCay.data[DragSeed.IdSeed].Img1;
                    InventoryManager.gold -= ManagerData.instance.dataCay.data[DragSeed.IdSeed].GiaTien;
                    InventoryManager.instance.Gold();
                    GameObject _obj = Instantiate(ManagerData.instance.EffectSeed);
                    _obj.transform.SetParent(transform);
                    _obj.transform.localPosition = Vector3.zero;
                    Destroy(_obj, 2);
                    show = 1;
                    setTime(id);
                    StartCoroutine(TrongCay());
                } else
                {
                    txtThongBao.gameObject.SetActive(true);
                    StartCoroutine(ThongBao());
                }
            }

        }
    }
    int time = 2;
    IEnumerator ThongBao()
    {
        yield return new WaitForSeconds(1f);
        time--;
        if (time > 0)
        {
            StartCoroutine(ThongBao());
        }
        else {
            txtThongBao.gameObject.SetActive(false);
        }
    }

    public void muaCay()
    {
        if (show == 0)
        {
            thisSprite.gameObject.SetActive(true);
            thisSprite.sprite = ManagerData.instance.dataCay.data[id].Img1;
            setTime(id);
            StartCoroutine(TrongCay());
        }
    }

    int timeleft = 0;
    public void ShowTime()
    {
        objThoiGian.gameObject.SetActive(true);
        timeleft = 2;
    }
}
