using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogChuong : MonoBehaviour
{
    public static DialogChuong instance;
    public Text edtGiaTien, edtExp, edtTime, edtThuHoach, edtHeader;
    [SerializeField] Button[] arrayButton;
    [SerializeField] Button congAnimal;
    [SerializeField] Button truAnimal;
    [SerializeField] Button muaAnimal;
    

    GameObject chuong;
    public int max;
    public Image imgChuong,imgAnimal1, imgAnimal2, imgAnimal3, imgAnimal4;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for (int i = 0; i < ManagerData.instance.dataVatNuoi.data.Length; i++)
        {
            
            int id = i;
            arrayButton[i].onClick.AddListener(() => ButtonSeed(id));
            
        }
    
        congAnimal.onClick.AddListener(() => CongGa());
        truAnimal.onClick.AddListener(() => TruGa());
        muaAnimal.onClick.AddListener(() => MuaAnimal());
        
    }
    public void Open(GameObject ob)
    {
        chuong = ob;
        gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
        
    }
    public void Close()
    {

        gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
        
    }
    void Update()
    {
        
    }
    public void ButtonSeed(int idHG)
    {
        idVatNuoi = idHG;
        MoveEgg.id = idHG;
        edtHeader.text = ManagerData.instance.dataVatNuoi.data[idHG].Name;
        edtGiaTien.text = ManagerData.instance.dataVatNuoi.data[idHG].GiaTien.ToString();
        edtExp.text = ManagerData.instance.dataVatNuoi.data[idHG].KinhNghiem.ToString();
        edtTime.text = ManagerData.instance.dataVatNuoi.data[idHG].Time;
        edtThuHoach.text = ManagerData.instance.dataVatNuoi.data[idHG].ThuHoach;
        imgChuong.sprite = ManagerData.instance.dataVatNuoi.data[idHG].Chuong;
        imgAnimal1.sprite = ManagerData.instance.dataVatNuoi.data[idHG].Animal;
        imgAnimal2.sprite = ManagerData.instance.dataVatNuoi.data[idHG].Animal2;
        imgAnimal3.sprite = ManagerData.instance.dataVatNuoi.data[idHG].Animal3;
        imgAnimal4.sprite = ManagerData.instance.dataVatNuoi.data[idHG].Animal4;

        //if (count == 2)
        //{
        //    edtGiaTien.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien + ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 2).ToString();
        //    edtExp.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem + ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem * 2).ToString();
        //}
        //else if (count == 3)
        //{
        //    edtGiaTien.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien + ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 3).ToString();
        //    edtExp.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem + ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem * 3).ToString();
        //}
        //else if (count == 4)
        //{
        //    edtGiaTien.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien + ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * 4).ToString();
        //    edtExp.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem + ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem * 4).ToString();
        //}

        CongGa();
        TruGa();

    }
    int idVatNuoi;
    int count = 1;
    public void CongGa()
    {
        
        if (count == 1) {

            imgAnimal2.gameObject.SetActive(true);
            count++;

        }
        else if (count == 2) {

            imgAnimal3.gameObject.SetActive(true);
            count++;

        }
        else if (count == 3)
        {

            imgAnimal4.gameObject.SetActive(true);
            count++;

        }
        edtGiaTien.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien + ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * (count-1)).ToString();
        edtExp.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem + ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem * (count-1)).ToString();
    }
    
    public void TruGa()
    {
       
        if (count == 1)
        {
           imgAnimal2.gameObject.SetActive(false);           
        }
        else if (count == 2)
        {

            imgAnimal2.gameObject.SetActive(false);
            count--;

        }
        else if (count == 3)
        {

            imgAnimal3.gameObject.SetActive(false);
            count--;

        }
        else if (count == 4)
        {

            imgAnimal4.gameObject.SetActive(false);
            count--;

        }
        edtGiaTien.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien + ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien * (count-1)).ToString();
        edtExp.text = (ManagerData.instance.dataVatNuoi.data[idVatNuoi].GiaTien + ManagerData.instance.dataVatNuoi.data[idVatNuoi].KinhNghiem * (count-1)).ToString();
    }

    public void MuaAnimal()
    {
        chuong.GetComponent<Chuong>().idVatNuoi = idVatNuoi;
        chuong.GetComponent<Chuong>().count = count;
        chuong.GetComponent<Chuong>().ThaVatNuoi();
    }

    

}
