using BitBenderGames;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chuong : MonoBehaviour
{
    public GameObject img1, img2, img3, img4, img5, img6, img7, img8, img9, img10, img11, img12, img13, img14, img15, img16;
    public Sprite thisSprite, thatSprite;
    public Text txtThongBao, txtTime;
    public Image Img1, Img2; 
    public int idVatNuoi;
    public int count;
    public GameObject objThoiGian;
    public Button BtnThuHoach;
    int timeNuoi;
    int show = 0;
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>().sprite;
        Img1.gameObject.SetActive(false);
        BtnThuHoach.onClick.AddListener(() => ThuHoach());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            if (show == 0)
            {
                DialogChuong.instance.Open(gameObject);
                MobileTouchCamera.checkCamFollow = true;
                OpenDialog.instance.Close();
            }
            else if (show == 1)
            {
                Debug.Log(timeNuoi);
                img1.gameObject.SetActive(false);
                img2.gameObject.SetActive(false);
                img3.gameObject.SetActive(false);
                img4.gameObject.SetActive(false);
                img5.gameObject.SetActive(false);
                img6.gameObject.SetActive(false);
                img7.gameObject.SetActive(false);
                img8.gameObject.SetActive(false);
                img9.gameObject.SetActive(false);
                img10.gameObject.SetActive(false);
                img11.gameObject.SetActive(false);
                img12.gameObject.SetActive(false);
                img13.gameObject.SetActive(false);
                img14.gameObject.SetActive(false);
                img15.gameObject.SetActive(false);
                img16.gameObject.SetActive(false);
                Img1.gameObject.SetActive(false);
                if(ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong == 0)
                {
                    ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong += (ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong + 1) * count;
                } else
                {
                    ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong += ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong * count;
                }
                
                transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
                transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
                GameObject _obj = Instantiate(ManagerData.instance.EffectPick);
                _obj.transform.SetParent(transform);
                _obj.transform.localPosition = Vector3.zero;
                Destroy(_obj, 2);
                show = 0;
            } else if (show == 2)
            {
                ShowTime();
            }
        }
        
        
    }

    void ThuHoach()
    {
        img1.gameObject.SetActive(false);
        img2.gameObject.SetActive(false);
        img3.gameObject.SetActive(false);
        img4.gameObject.SetActive(false);
        img5.gameObject.SetActive(false);
        img6.gameObject.SetActive(false);
        img7.gameObject.SetActive(false);
        img8.gameObject.SetActive(false);
        img9.gameObject.SetActive(false);
        img10.gameObject.SetActive(false);
        img11.gameObject.SetActive(false);
        img12.gameObject.SetActive(false);
        img13.gameObject.SetActive(false);
        img14.gameObject.SetActive(false);
        img15.gameObject.SetActive(false);
        img16.gameObject.SetActive(false);
        Img1.gameObject.SetActive(false);
        if (ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong == 0)
        {
            ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong += (ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong + 1) * count;
        }
        else
        {
            ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong += ManagerData.instance.dataVatNuoi.data[idVatNuoi].SoLuong * count;
        }

        transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        GameObject _obj = Instantiate(ManagerData.instance.EffectPick);
        _obj.transform.SetParent(transform);
        _obj.transform.localPosition = Vector3.zero;
        Destroy(_obj, 2);
        show = 0;
    }

    int time = 2;

    public void ThaVatNuoi()
    {
        
        timeNuoi = ManagerData.instance.dataVatNuoi.data[idVatNuoi].TimeNuoi * 10;
        
        if (count == 1 )
        {
            if(InventoryManager.gold > ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien)
            {
                if(idVatNuoi == 0)
                {
                    img1.gameObject.SetActive(true);
                } else if(idVatNuoi == 1)
                {
                    img5.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 2)
                {
                    img9.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 3)
                {
                    img13.gameObject.SetActive(true);
                }

                //GaAnimation.instance.An();
                InventoryManager.gold -= ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien;
                InventoryManager.instance.Gold();
                DialogChuong.instance.Close();
                if (idVatNuoi > 0)
                {
                    GetComponent<SpriteRenderer>().sprite = thatSprite;
                    ChangeChuong.instance.chuongLonn();
                }
                else
                {
                    thisSprite = GetComponent<SpriteRenderer>().sprite;
                    ChangeChuong.instance.chuongGaa();
                }
                MobileTouchCamera.checkCamFollow = false;
                show = 2;
                StartCoroutine(HideAnimal());
            }else
            {
                txtThongBao.gameObject.SetActive(true);
                StartCoroutine(ThongBao());
            }
            
        }
        else if (count == 2 )
        {
            if(InventoryManager.gold > ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 2)
            {
                if (idVatNuoi == 0)
                {
                    img1.gameObject.SetActive(true);
                    img2.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 1)
                {
                    img5.gameObject.SetActive(true);
                    img6.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 2)
                {
                    img9.gameObject.SetActive(true);
                    img10.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 3)
                {
                    img13.gameObject.SetActive(true);
                    img14.gameObject.SetActive(true);
                }
                                
                //GaAnimation.instance.An();
                InventoryManager.gold -= ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 2;
                InventoryManager.instance.Gold();
                DialogChuong.instance.Close();
                if (idVatNuoi > 0)
                {
                    GetComponent<SpriteRenderer>().sprite = thatSprite;
                    ChangeChuong.instance.chuongLonn();
                }
                else
                {
                    thisSprite = GetComponent<SpriteRenderer>().sprite;
                    ChangeChuong.instance.chuongGaa();
                }
                MobileTouchCamera.checkCamFollow = false;
                show = 2;
                StartCoroutine(HideAnimal());
            }else
            {
                txtThongBao.gameObject.SetActive(true);
                StartCoroutine(ThongBao());
            }
            
        }
        else if (count == 3 )
        {
            if (InventoryManager.gold > ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 3)
            {
                if (idVatNuoi == 0)
                {
                    img1.gameObject.SetActive(true);
                    img2.gameObject.SetActive(true);
                    img3.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 1)
                {
                    img5.gameObject.SetActive(true);
                    img6.gameObject.SetActive(true);
                    img7.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 2)
                {
                    img9.gameObject.SetActive(true);
                    img10.gameObject.SetActive(true);
                    img11.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 3)
                {
                    img13.gameObject.SetActive(true);
                    img14.gameObject.SetActive(true);
                    img15.gameObject.SetActive(true);
                }
                
                //GaAnimation.instance.An();
                InventoryManager.gold -= ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 3;
                InventoryManager.instance.Gold();
                DialogChuong.instance.Close();
                if (idVatNuoi > 0)
                {
                    GetComponent<SpriteRenderer>().sprite = thatSprite;
                    ChangeChuong.instance.chuongLonn();
                }
                else
                {
                    thisSprite = GetComponent<SpriteRenderer>().sprite;
                    ChangeChuong.instance.chuongGaa();
                }
                MobileTouchCamera.checkCamFollow = false;
                show = 2;
                StartCoroutine(HideAnimal());
            }else
            {
                txtThongBao.gameObject.SetActive(true);
                StartCoroutine(ThongBao());
            }
            
        }
        else if (count == 4)
        {
            if(InventoryManager.gold > ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 4)
            {
                if (idVatNuoi == 0)
                {
                    img1.gameObject.SetActive(true);
                    img2.gameObject.SetActive(true);
                    img3.gameObject.SetActive(true);
                    img4.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 1)
                {
                    img5.gameObject.SetActive(true);
                    img6.gameObject.SetActive(true);
                    img7.gameObject.SetActive(true);
                    img8.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 2)
                {
                    img9.gameObject.SetActive(true);
                    img10.gameObject.SetActive(true);
                    img11.gameObject.SetActive(true);
                    img12.gameObject.SetActive(true);
                }
                else if (idVatNuoi == 3)
                {
                    img13.gameObject.SetActive(true);
                    img14.gameObject.SetActive(true);
                    img15.gameObject.SetActive(true);
                    img16.gameObject.SetActive(true);
                }
                //GaAnimation.instance.An();
                InventoryManager.gold -= ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 4;
                InventoryManager.instance.Gold();
                DialogChuong.instance.Close();
                if (idVatNuoi > 0)
                {
                    GetComponent<SpriteRenderer>().sprite = thatSprite;
                    ChangeChuong.instance.chuongLonn();
                }
                else
                {
                    thisSprite = GetComponent<SpriteRenderer>().sprite;
                    ChangeChuong.instance.chuongGaa();
                }
                MobileTouchCamera.checkCamFollow = false;
                show = 2;
                StartCoroutine(HideAnimal());
            } else
            {
                txtThongBao.gameObject.SetActive(true);
                StartCoroutine(ThongBao());
            }
            
        }
        
    }

    IEnumerator ThongBao()
    {

        yield return new WaitForSeconds(1f);
        time--;

        if (time > 0)
        {
            StartCoroutine(ThongBao());
        }
        else
        {
            txtThongBao.gameObject.SetActive(false);
        }

    }

    IEnumerator HideAnimal()
    {
        Debug.Log(timeNuoi);
        yield return new WaitForSeconds(1f);
        timeNuoi--;
        txtTime.text = (timeNuoi / 60).ToString() + " : " + (timeNuoi % 60).ToString();
        if (timeNuoi > 0)
        {
                       
            if (timeleft > 0)
            {
                timeleft--;

            }
            else
            {
                objThoiGian.gameObject.SetActive(false);
            }
            show = 2;
            StartCoroutine(HideAnimal());
        }
        else
        {
            show = 1;
            Img2.sprite = ManagerData.instance.dataVatNuoi.data[idVatNuoi].ThuHoachDe;
            Img1.gameObject.SetActive(true);
            foreach(Transform a in transform.GetChild(0))
            {

                GaAnimation anim = a.gameObject.GetComponent<GaAnimation>();
                anim.No();
            }
            
        }          
        
    }

    int timeleft = 0;
    public void ShowTime()
    {
        objThoiGian.gameObject.SetActive(true);
        timeleft = 2;
    }
}
