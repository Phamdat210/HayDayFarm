using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogToolMuaHang : MonoBehaviour
{
    public static DialogToolMuaHang instance;
    public Text edtName, edtDonGia, edtContent, edtSL;
    [SerializeField] Button[] arrayButton;
    [SerializeField] Button btnMua;
    public Image img;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ManagerData.instance.dataTool.data.Length; i++)
        {

            int id = i;
            arrayButton[i].onClick.AddListener(() => ButtonTool(id));

        }

        btnMua.onClick.AddListener(() => BtnMua());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonTool(int idTool)
    {
        ChatCayTo.id = idTool;
        idMua = idTool;
        edtName.text = ManagerData.instance.dataTool.data[idTool].Name;
        edtDonGia.text = ManagerData.instance.dataTool.data[idTool].GiaTien.ToString();
        edtContent.text = ManagerData.instance.dataTool.data[idTool].Content;
        edtSL.text = ManagerData.instance.dataTool.data[idMua].SoLuong.ToString();
        img.sprite = ManagerData.instance.dataTool.data[idTool].Img;
    }
    
    public void Open()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", true);

    }
    int idMua;
    public void BtnMua()
    {
        if(InventoryManager.gold > 10)
        {
            InventoryManager.gold -= 10;
            InventoryManager.instance.Gold();
            ManagerData.instance.dataTool.data[idMua].SoLuong += 1;
            edtSL.text = ManagerData.instance.dataTool.data[idMua].SoLuong.ToString();
        }
    }
}
