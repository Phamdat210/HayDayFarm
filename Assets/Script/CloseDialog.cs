using BitBenderGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialog : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeOdat()
    {
        DialogTrongCay.instance.Close();
        MobileTouchCamera.checkCamFollow = false;
        
    }

    public void closeChuong()
    {
        DialogChuong.instance.Close();
        MobileTouchCamera.checkCamFollow = false;
    }

}
