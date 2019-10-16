using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerData : MonoBehaviour
{
    public DataVatNuoi dataVatNuoi;
    public DataCay dataCay;
    public DataTool dataTool;
    public static ManagerData instance;
    public GameObject LuoiCua;

    public GameObject TextMeshExp, CoinText, Effect, EffectPick, EffectCoin, EffectSeed, Go, Nuoc, Da;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

}
