using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrongCay : MonoBehaviour
{
    public static DialogTrongCay instance;
    public Text edtGiaTien, edtExp, edtTime, edtSanPham, edtCapDo, edtHeader, txtCapDo;
    [SerializeField] Button[] arrayButton;
    public GameObject btnAll;
    [SerializeField] Button btnMua, btnClose;
    GameObject odat;
    Vector3 temp;
    public Image img;
    public Image imgDat;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for (int i = 0; i < ManagerData.instance.dataCay.data.Length; i++)
        {
            int id = i;
            arrayButton[i].onClick.AddListener(() => ButtonSeed(id));
            
        }

        btnMua.onClick.AddListener(() => muaCay());
        btnClose.onClick.AddListener(() => Close());
    }

    void Update()
    {
       
    }

    public void Open(GameObject ob)
    {
        odat = ob;
        //gameObject.transform.localScale = new Vector3(1f, 1f, 0);
        gameObject.GetComponent<Animator>().SetBool("DialogBool", true);

    }

    public void CloseDialog()
    {

        gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
        
        //gameObject.transform.localScale = Vector3.zero;
    }

    public int idSeed;

    public void Close()
    {

        gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
        //gameObject.transform.localScale = Vector3.zero;
        MobileTouchCamera.checkCamFollow = false;
        
    }

    public void ButtonSeed(int idHG)
    {
        img.sprite = ManagerData.instance.dataCay.data[idHG].Img3;
        if (idHG == 0)
        {
            if(InventoryManager.lv > 0)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        } else if (idHG == 1)
        {
            if (InventoryManager.lv > 1)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 2)
        {
            if (InventoryManager.lv > 3)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 3)
        {
            if (InventoryManager.lv > 5)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 4)
        {
            if (InventoryManager.lv > 6)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 5)
        {
            if (InventoryManager.lv > 8)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 6)
        {
            if (InventoryManager.lv > 11)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG ==7)
        {
            if (InventoryManager.lv > 14)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 8)
        {
            if (InventoryManager.lv > 17)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        else if (idHG == 9)
        {
            if (InventoryManager.lv > 19)
            {
                btnMua.gameObject.SetActive(true);
                imgDat.gameObject.SetActive(true);
                txtCapDo.gameObject.SetActive(false);
            }
            else
            {
                btnMua.gameObject.SetActive(false);
                imgDat.gameObject.SetActive(false);
                txtCapDo.gameObject.SetActive(true);
            }
        }
        idSeed = idHG;
        DragSeed.IdSeed = idSeed;
        Odat.id = idHG;
        InventoryManager.id = idHG;
        DialogCho.id = idHG;
        MoveCoinExp.id = idHG;
        edtHeader.text = ManagerData.instance.dataCay.data[idHG].Name;
        edtGiaTien.text = ManagerData.instance.dataCay.data[idHG].GiaTien.ToString();
        edtExp.text = ManagerData.instance.dataCay.data[idHG].KinhNghiem.ToString();
        edtTime.text = ManagerData.instance.dataCay.data[idHG].Time;
        edtSanPham.text = ManagerData.instance.dataCay.data[idHG].Sp;
        edtCapDo.text = ManagerData.instance.dataCay.data[idHG].LvUnLock.ToString();
        
    }

    void muaCay()
    {
        odat.GetComponent<Odat>().muaCay();
        Close();
    }

}
