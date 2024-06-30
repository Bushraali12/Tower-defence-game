using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class moneyui : MonoBehaviour
{
    public Text moneytext;

    void Update()
    {
       moneytext.text="$" + playerstates.money.ToString(); 
    }
}
