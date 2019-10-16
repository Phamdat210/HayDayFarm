using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaiTao : MonoBehaviour
{
    public Sprite thatSprite;
    public Sprite thisSprite;
    [SerializeField] Button btnCut;
    [SerializeField] Text txtThongBao, txtHet, txtSL;
    public int time = 0;
    

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

    void SL()
    {
        txtSL.text = ManagerData.instance.dataTool.data[1].SoLuong.ToString();
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

    int thongBao = 5;
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

    int thongBaoHet = 5;
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
        if(show == 0)
        {
            if (ManagerData.instance.dataTool.data[1].SoLuong > 0)
            {
                GetComponent<SpriteRenderer>().sprite = thatSprite;
                time = 300;
                OpenDialog.instance.Close();
                ManagerData.instance.dataTool.data[1].SoLuong -= 1;
                InventoryManager.da += 2;
                InventoryManager.number += 1;
                InventoryManager.instance.Da();
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(4).gameObject.SetActive(true);
                GameObject _obj = Instantiate(ManagerData.instance.EffectCoin);
                _obj.transform.SetParent(transform);
                _obj.transform.localPosition = Vector3.zero;
                Destroy(_obj, 2);
                StartCoroutine(Moc());
            } else
            {
                txtHet.gameObject.SetActive(true);
                StartCoroutine(ThongBaoHet());
            }

        } else if (show == 1)
        {
            txtThongBao.gameObject.SetActive(true);
            OpenDialog.instance.Close();
            StartCoroutine(ThongBao());
        }
    }

    
}
