using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NhaMay : MonoBehaviour
{
    public static int show;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            if (show == 1)
            {

                DialogNhaMay.instance.gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
             
            }
        }
            
    }

    
}
