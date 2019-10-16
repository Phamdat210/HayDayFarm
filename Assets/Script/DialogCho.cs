using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCho : MonoBehaviour
{
    public static DialogCho instance;
    [SerializeField] Button[] arrayButton, arrayButton1;
    [SerializeField] Button BtnBan, BtnBanAnimal;
    [SerializeField] List<Sprite> arrayImage;
    public Text edtHeader, edtSoLuong, edtDonGia, edtTongTien;
    public Image img1, img2;
    public static int id;
    [SerializeField] Button changeBtn;
    public GameObject btnAll, btnAll2;
    bool check = true;

    private void Awake()
    {
        instance = this;
        arrayImage = new List<Sprite>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ManagerData.instance.dataCay.data.Length; i++)
        {
            int id = i;
            arrayButton[i].onClick.AddListener(() => ButtonSeed(id));

        }

        for (int i = 0; i < ManagerData.instance.dataVatNuoi.data.Length; i++)
        {
            int id = i;
            arrayButton1[i].onClick.AddListener(() => ButtonAnimal(id));

        }

        BtnBan.onClick.AddListener(() => ButtonBan());
        BtnBanAnimal.onClick.AddListener(() => ButtonBanVatNuoi());
        changeBtn.onClick.AddListener(() => ChangeButton());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ManagerData.instance.dataCay.data.Length; i++)
        {
            int id = i;
            if(ManagerData.instance.dataCay.data[id].SoLuong > 0)
            {
                //arrayImage.Add(ManagerData.instance.dataCay.data[id].Seed);
                arrayButton[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            } else
            {
                //arrayImage.Add(ManagerData.instance.dataCay.data[id].SeedLock);
                arrayButton[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }          
        }

        for (int i = 0; i < ManagerData.instance.dataVatNuoi.data.Length; i++)
        {
            int id = i;
            if (ManagerData.instance.dataVatNuoi.data[id].SoLuong > 0)
            {
                //arrayImage.Add(ManagerData.instance.dataCay.data[id].Seed);
                arrayButton1[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                //arrayImage.Add(ManagerData.instance.dataCay.data[id].SeedLock);
                arrayButton1[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }


        }
    }

    public void Open()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
        
    }

    public void Close()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", false);

    }

    public void ButtonSeed(int id)
    {
        idSL = id;
        edtHeader.text = ManagerData.instance.dataCay.data[id].Name;
        edtDonGia.text = ManagerData.instance.dataCay.data[id].DonGia.ToString();
        edtSoLuong.text = ManagerData.instance.dataCay.data[id].SoLuong.ToString();
        edtTongTien.text = (ManagerData.instance.dataCay.data[id].SoLuong * ManagerData.instance.dataCay.data[id].DonGia).ToString();
        img1.sprite = ManagerData.instance.dataCay.data[id].Seed;
        img2.sprite = ManagerData.instance.dataCay.data[id].Seed;
       
    }

    public void ButtonAnimal(int id)
    {
        idAnimal = id;
        edtHeader.text = ManagerData.instance.dataVatNuoi.data[id].Name;
        edtDonGia.text = ManagerData.instance.dataVatNuoi.data[id].DonGia.ToString();
        edtSoLuong.text = ManagerData.instance.dataVatNuoi.data[id].SoLuong.ToString();
        edtTongTien.text = (ManagerData.instance.dataVatNuoi.data[id].SoLuong * ManagerData.instance.dataVatNuoi.data[id].DonGia).ToString();
        img1.sprite = ManagerData.instance.dataVatNuoi.data[id].ThuHoachDe;
        img2.sprite = ManagerData.instance.dataVatNuoi.data[id].ThuHoachDe;

    }
    int idAnimal;
    int idSL;
    public void ButtonBan()
    {
        if(ManagerData.instance.dataCay.data[idSL].SoLuong > 0)
        {
            InventoryManager.gold += ManagerData.instance.dataCay.data[idSL].SoLuong * ManagerData.instance.dataCay.data[idSL].DonGia;
            InventoryManager.instance.Gold();
            ManagerData.instance.dataCay.data[idSL].SoLuong = 0;
            edtSoLuong.text = ManagerData.instance.dataCay.data[idSL].SoLuong.ToString();
            edtTongTien.text = (ManagerData.instance.dataCay.data[idSL].SoLuong * ManagerData.instance.dataCay.data[idSL].DonGia).ToString();
            transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(Tat());
        }       
    }

    public void ButtonBanVatNuoi()
    {
        if(ManagerData.instance.dataVatNuoi.data[idAnimal].SoLuong > 0)
        {
            InventoryManager.gold += ManagerData.instance.dataVatNuoi.data[idAnimal].SoLuong * ManagerData.instance.dataVatNuoi.data[idAnimal].DonGia;
            InventoryManager.instance.Gold();
            ManagerData.instance.dataVatNuoi.data[idAnimal].SoLuong = 0;
            edtSoLuong.text = ManagerData.instance.dataVatNuoi.data[idAnimal].SoLuong.ToString();
            edtTongTien.text = (ManagerData.instance.dataVatNuoi.data[idAnimal].SoLuong * ManagerData.instance.dataVatNuoi.data[idAnimal].DonGia).ToString();
            transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(Tat());
        }
        
    }

    public void ChangeButton()
    {
        if (check == true)
        {
            btnAll.gameObject.SetActive(true);
            btnAll2.gameObject.SetActive(false);
            BtnBan.gameObject.SetActive(true);
            BtnBanAnimal.gameObject.SetActive(false);
            check = false;
        }
        else
        {
            btnAll.gameObject.SetActive(false);
            btnAll2.gameObject.SetActive(true);
            BtnBan.gameObject.SetActive(false);
            BtnBanAnimal.gameObject.SetActive(true);
            check = true;
        }
    }
    int time = 2;
    IEnumerator Tat()
    {
        yield return new WaitForSeconds(1f);
        time--;
        if(time > 0)
        {
            StartCoroutine(Tat());
        } else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
