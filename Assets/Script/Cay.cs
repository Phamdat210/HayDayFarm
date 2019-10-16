using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cay : MonoBehaviour
{
    [SerializeField] Button btnBan, btnMua, btnClose, btnCloseMua;
    // Start is called before the first frame update
    void Start()
    {
        btnBan.onClick.AddListener(() => OpenDialogBan());
        btnClose.onClick.AddListener(() => Close());
        btnCloseMua.onClick.AddListener(() => CloseMua());
        btnMua.onClick.AddListener(() => OpenDialogMua());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0)) {
            
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("1"))
            {

                a.transform.GetChild(0).gameObject.SetActive(false);
                a.transform.tag = "2";
            }
            transform.GetChild(0).gameObject.SetActive(true);
            this.transform.tag = "1";
        }
            
    }

    public void OpenDialogBan()
    {
        DialogCho.instance.gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
        MobileTouchCamera.checkCamFollow = true;
    }

    public void OpenDialogMua()
    {
        DialogToolMuaHang.instance.gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
        MobileTouchCamera.checkCamFollow = true;
    }

    public void CloseMua()
    {
        DialogToolMuaHang.instance.gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
        MobileTouchCamera.checkCamFollow = false;
    }

    public void Close()
    {
        DialogCho.instance.gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
        MobileTouchCamera.checkCamFollow = false;
    }
}
