using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDa : MonoBehaviour
{
    public bool move;
    GameObject CoinText;
    GameObject StarText;
    GameObject Exp;
    GameObject Coin;

    Vector2 OldPosCoin;
    Vector2 OldPosStar;


    // star is called before the first frame update
    void Start()
    {
        CoinText = transform.GetChild(4).gameObject;
        StarText = transform.GetChild(3).gameObject;
        OldPosCoin = CoinText.transform.position;
        OldPosStar = StarText.transform.position;
        move = true;
        Exp = ManagerData.instance.TextMeshExp.gameObject;
        Coin = ManagerData.instance.Da.gameObject;



    }



    // Update is called once per frame
    void FixedUpdate()
    {

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
            CoinText.SetActive(false);
            CoinText.transform.position = OldPosCoin;
            //Debug.Log("a");
            //Destroy(Instantiate(ManagerData.instance.Effect, Coin.transform.position, Quaternion.identity), 2);
            //Destroy(CoinText);

        }
        if (StarText != null && Vector2.Distance(StarText.transform.position, Exp.transform.position) <= 1)
        {
            StarText.SetActive(false);
            StarText.transform.position = OldPosStar;

            //StarText.SetActive(false);
            //Debug.Log("b");
            //Destroy(Instantiate(ManagerData.instance.Effect, Exp.transform.position, Quaternion.identity), 2);
            //Destroy(StarText);
        }

        //if (!CoinText.active && !StarText.active && gameObject.active)
        //{
        //    Destroy(gameObject);
        //}


    }

    void ResetPos()
    {
        CoinText.SetActive(true);
        StarText.SetActive(true);
        CoinText.transform.position = OldPosCoin;
        StarText.transform.position = OldPosStar;
    }
}
