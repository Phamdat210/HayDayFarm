using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNhaMay : MonoBehaviour
{
    public static DialogNhaMay instance;
    public Sprite spriteNhaMay;
    public Button btnClose, btnMua, btnCloseMua, btnXay, btnThuHoach, btnThongBao;
    public GameObject objMua, objNhaMay;
    public Text txtNuoc, txtDa, txtGo, txtTime, txtThuHoach;
    public GameObject EffectSmoke;
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
        gameObject.GetComponent<Animator>().SetBool("DialogBool",true);
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
        InventoryManager.nuoc += thuHoach;
        thuHoach = 0;
    }

    public void Xay()
    {
        Sl();
        if (nuoc >= 50 && da >= 50 && go >= 50)
        {
            objNhaMay.GetComponent<SpriteRenderer>().sprite = spriteNhaMay;
            InventoryManager.nuoc -= 50;
            InventoryManager.da -= 50;
            InventoryManager.go -= 50;
            btnMua.gameObject.SetActive(false);
            btnThuHoach.gameObject.SetActive(true);
            EffectSmoke.SetActive(true);
            StartCoroutine(Time());
            CloseMua();
            Close();
        }
    }

    public void Sl()
    {
        nuoc = InventoryManager.nuoc;
        da = InventoryManager.da;
        go = InventoryManager.go;
        txtNuoc.text = nuoc.ToString();
        txtDa.text = da.ToString();
        txtGo.text = go.ToString();
    }

    public void ThuHoach()
    {
        InventoryManager.nuoc += thuHoach;
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
