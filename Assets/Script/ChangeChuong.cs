using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChuong : MonoBehaviour
{
    public Sprite chuongGa, chuongLon;
    public static ChangeChuong instance;

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
        chuongGa = this.GetComponent<SpriteRenderer>().sprite;
    }

    public void chuongLonn()
    {
        GetComponent<SpriteRenderer>().sprite = chuongLon;
    }

    public void chuongGaa()
    {
        chuongLon = GetComponent<SpriteRenderer>().sprite;
    }
}
