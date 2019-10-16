using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static int number, id;
    public static int gold = 200;
    public static int go = 200;
    public static int da = 200;
    public static int nuoc = 200;
    public static int dau = 0;
    public static int lv = 1;
    [SerializeField] Text TxtLv, TxtExp, TxtGold, TxtDa, TxtGo, TxtNuoc;
    public static InventoryManager instance;

    public Sprite secondSprite, spriteGo,  spriteDa,  spriteVang;
    public GameObject bienThongBao, bienThongBao2, bienThongBao3, bienThongBao4, bienThongBao5, bienThongBao6, bienThongBao7, bienThongBao8;
    public GameObject datLock, datLock2, datLock3, datLock4 , datLock5 , datLock6, datLock7, datLock8;
    public GameObject ChuongGa1, ChuongGa2, ChuongGa3, ChuongGa4, ChuongGa5;
    public GameObject Lock1, Lock2, Lock3, Lock4, Lock5;
    public Text txt1, txt2, txt3, txt4, txt5, txt6, txtExpMax;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Gold();
        Go();
        Nuoc();
        Da();
        txt2.text = "+ Lúa";
        txt3.text = "+ Đất động vật";
        txtExpMax.text = "/ 50";
    }

    // Update is called once per frame
    void Update()
    {
        UpLv();

    }

    void UpLv()
    {
        TxtExp.text = number.ToString();
        if (number > 50 && lv == 1)
        {
            lv = 2;
            TxtLv.text = lv.ToString();
            number = 0;
            txt1.text = "2";
            txt2.text = "+ Nhà máy nước";
            txt3.text = "+ Mỏ vàng";
            txt4.text = "+ Mỏ đá";
            txt5.text = "+ Mỏ gỗ";
            txt6.text = "+ Khoai tây";
            txtExpMax.text = "/ 200";
            DialogNhaChinh.instance.Open();
            DialogNhaChinh.instance.Effect();
            datLock.GetComponent<SpriteRenderer>().sprite = secondSprite;
            datLock2.GetComponent<SpriteRenderer>().sprite = spriteGo;
            datLock3.GetComponent<SpriteRenderer>().sprite = spriteDa;
            datLock4.GetComponent<SpriteRenderer>().sprite = spriteVang;
            bienThongBao.SetActive(false);
            bienThongBao2.SetActive(false);
            bienThongBao3.SetActive(false);
            bienThongBao4.SetActive(false);
            NhaMay.show = MoGo.show = MoDa.show = MoVang.show = 1;
        } else if (number > 200 && lv == 2)
        {
            lv = 3;
            number = 0;
            TxtLv.text = lv.ToString();
            txt1.text = "3";
            txtExpMax.text = "/ 500";
            DialogNhaChinh.instance.Open();
            DialogNhaChinh.instance.Effect();

        } else if (number > 500 && lv == 3)
        {
            lv = 4;
            number = 0;
            TxtLv.text = lv.ToString();
            txt1.text = "4";
            txt2.text = "+ Ngô";
            txtExpMax.text = "/ 800";
            DialogNhaChinh.instance.Open();
            DialogNhaChinh.instance.Effect();
        } else if (number > 800 && lv == 4)
        {
            lv = 5;
            number = 0;
            TxtLv.text = lv.ToString();
            txt1.text = "5";
            txt2.text = "+ Chuồng";
            txtExpMax.text = "/ 1100";
            ChuongGa1.gameObject.SetActive(true);
            datLock.gameObject.SetActive(false);
            DialogNhaChinh.instance.Open();
            DialogNhaChinh.instance.Effect();
        } 
    }

    public void Gold()
    {
        TxtGold.text = gold.ToString();
    }

    public void Go()
    {
        TxtGo.text = go.ToString();
    }

    public void Da()
    {
        TxtDa.text = da.ToString();
    }

    public void Nuoc()
    {
        TxtNuoc.text = nuoc.ToString();
    }
}
