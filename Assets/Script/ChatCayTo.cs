using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatCayTo : MonoBehaviour
{
    public Sprite thatSprite;
    public Sprite thisSprite;
    [SerializeField] Button btnCut;
    [SerializeField] Text txtThongBao, txtSL, txtHet;
    public int time = 0;
    public static ChatCayTo instance;
    public static int id;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        btnCut.onClick.AddListener(() => ChatCay());
        thisSprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        SL();
    }

    int show = 0;
    

    IEnumerator Moc()
    {
        Debug.Log(time);
        yield return new WaitForSeconds(1f);
        time--;

        if (time > 0)
        {

            show = 1;
            StartCoroutine(Moc());

        }
        else
        {

            GetComponent<SpriteRenderer>().sprite = thisSprite;
            show = 0;
            Debug.Log(show);
        }
    }

    int thongBao = 3;
    IEnumerator ThongBao()
    {
        yield return new WaitForSeconds(1f);
        thongBao--;

        if (thongBao > 0)
        {
            
            StartCoroutine(ThongBao());

        }
        else
        {
            txtThongBao.gameObject.SetActive(false);

        }
    }

    int thongBaoHet = 3;
    IEnumerator ThongBaoHet()
    {
        yield return new WaitForSeconds(1f);
        thongBaoHet--;

        if (thongBaoHet > 0)
        {

            StartCoroutine(ThongBaoHet());

        }
        else
        {
            txtHet.gameObject.SetActive(false);

        }
    }
    
    void ChatCay()
    {
        if (show == 0)
        {
            if(ManagerData.instance.dataTool.data[0].SoLuong > 0)
            {
                GetComponent<SpriteRenderer>().sprite = thatSprite;
                time = 300;
                OpenDialog.instance.Close();
                ManagerData.instance.dataTool.data[0].SoLuong -= 1;
                InventoryManager.go += 2;
                InventoryManager.number += 1;
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(4).gameObject.SetActive(true);
                InventoryManager.instance.Go();
                gameObject.GetComponent<Animator>().enabled = true;
                StartCoroutine(Moc()); 
            } else
            {
                txtHet.gameObject.SetActive(true);
                StartCoroutine(ThongBaoHet());
            }
            

        }
        else if (show == 1)
        {
            txtThongBao.gameObject.SetActive(true);
            OpenDialog.instance.Close();
            StartCoroutine(ThongBao());
            
        }
    }

    void SL()
    {
        txtSL.text = ManagerData.instance.dataTool.data[0].SoLuong.ToString();
    }
}
