using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject dialogTrongCay, dialogBanHang;
    public static DialogController instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        dialogTrongCay.gameObject.SetActive(true);
    }

    public void OpenBanHang()
    {
        dialogBanHang.gameObject.SetActive(true);
    }

    public void Close()
    {
        dialogTrongCay.gameObject.SetActive(false);
        dialogBanHang.gameObject.SetActive(false);
    }
}
