using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogNhaChinh : MonoBehaviour
{
    public static DialogNhaChinh instance;
    // Start is called before the first frame update
    [SerializeField] Button closeDialog;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        closeDialog.onClick.AddListener(() => Close());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", true);
    }
    public void Close()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogBool", false);
        EffectFalse();
    }

    public void Effect()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void EffectFalse()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }
}
