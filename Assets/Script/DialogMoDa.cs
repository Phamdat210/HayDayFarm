using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMoDa : MonoBehaviour
{
    public static DialogMoDa instance;
    public Sprite spriteMoDa;
    public Button btnClose, btnMua, btnCloseMua, btnXay, btnThuHoach, btnThongBao;
    public GameObject objMua, objNhaMay;
    public Text txtNuoc, txtDa, txtGo, txtTime, txtThuHoach;
    public int nuoc, da, go;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        btnClose.onClick.AddListener(() => Close());
        btnMua.onClick.AddListener(() => Mua());
        btnCloseMua.onClick.AddListener(() => CloseMua());
        btnXay.onClick.AddListener(() => Xay());
        btnThuHoach.onClick.AddListener(() => ThuHoach());
        btnThongBao.onClick.AddListener(() => ThongBao());
    }

    // Update is called once per frame
    void Update()
    {
        Sl();
        InventoryManager.instance.Go();
        InventoryManager.instance.Nuoc();
        InventoryManager.instance.Da();
    }

    public void Open()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
    }

    public void Close()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
    }

    public void CloseMua()
    {
        objMua.GetComponent<Animator>().SetBool("DialogBool", false);
    }

    public void Mua()
    {
        objMua.GetComponent<Animator>().SetBool("DialogBool", true);
    }

    public void ThongBao()
    {
        InventoryManager.da += thuHoach;
        thuHoach = 0;
    }

    public void Xay()
    {
        Sl();
        if (InventoryManager.nuoc >= 50 && InventoryManager.da >= 50 && InventoryManager.go >= 50)
        {
            objNhaMay.GetComponent<SpriteRenderer>().sprite = spriteMoDa;
            InventoryManager.nuoc -= 50;
            InventoryManager.da -= 50;
            InventoryManager.go -= 50;
            btnMua.gameObject.SetActive(false);
            btnThuHoach.gameObject.SetActive(true);
            StartCoroutine(Time());
            CloseMua();
            Close();
        }
    }

    public void Sl()
    {
        txtNuoc.text = InventoryManager.nuoc.ToString();
        txtDa.text = InventoryManager.da.ToString();
        txtGo.text = InventoryManager.go.ToString();
    }

    public void ThuHoach()
    {
        InventoryManager.da += thuHoach;
        thuHoach = 0;

    }

    int time = 0;
    int thuHoach = 0;
    IEnumerator Time()
    {
        yield return new WaitForSeconds(1f);
        txtTime.text = time.ToString();
        txtThuHoach.text = thuHoach.ToString();
        if (thuHoach <= 20)
        {
            if (time < 15)
            {
                time++;
                StartCoroutine(Time());
                if (time == 15)
                {
                    time = 0;
                    thuHoach += 1;
                    btnThongBao.gameObject.SetActive(true);

                }
                else if (thuHoach == 0)
                {
                    btnThongBao.gameObject.SetActive(false);
                }
            }
        }

    }
}
