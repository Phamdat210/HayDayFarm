using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCoinExp : MonoBehaviour
{
    public bool move;
    public Image CoinText;
    GameObject StarText;
    GameObject Exp;
    GameObject Coin;
    public static int id;
    Vector2 OldPosCoin;
    Vector2 OldPosStar;

    
    // star is called before the first frame update
    void Start()
    {
                       
        StarText = transform.GetChild(2).gameObject;
        OldPosCoin = CoinText.transform.position;
        OldPosStar = StarText.transform.position;
        move = true;
        Exp = ManagerData.instance.TextMeshExp.gameObject;
        Coin = ManagerData.instance.CoinText.gameObject;
        
        

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        CoinText.sprite = ManagerData.instance.dataCay.data[id].Seed; 
            if (move)
            {
                if (CoinText != null && CoinText.gameObject.active)
                {
                    CoinText.transform.position = Vector2.MoveTowards(CoinText.transform.position, Coin.transform.position, 7 * Time.deltaTime);
                }
                    
                if (StarText != null && StarText.active)
                {
                    StarText.transform.position = Vector2.MoveTowards(StarText.transform.position, Exp.transform.position, 7 * Time.deltaTime);                    
                }
                    
            }
            if (CoinText != null && Vector2.Distance(CoinText.transform.position, Coin.transform.position) <= 1)
            {
                CoinText.gameObject.SetActive(false);
                CoinText.transform.position = OldPosCoin;
                //Debug.Log("a");
               
                //Destroy(CoinText);

            }
            if (StarText != null && Vector2.Distance(StarText.transform.position, Exp.transform.position) <= 1)
            {
                StarText.SetActive(false);
                StarText.transform.position = OldPosStar;

                //StarText.SetActive(false);
                //Debug.Log("b");
                
                //Destroy(StarText);
            }

            //if (!CoinText.active && !StarText.active && gameObject.active)
            //{
            //    Destroy(gameObject);
            //}
        
        
    }

    void ResetPos()
    {
        CoinText.gameObject.SetActive(true);
        StarText.SetActive(true);
        CoinText.transform.position = OldPosCoin;
        StarText.transform.position = OldPosStar;
    }
}
