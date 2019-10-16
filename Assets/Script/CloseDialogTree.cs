using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialogTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Click here");
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
