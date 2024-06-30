using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstates : MonoBehaviour
{
  public static int money;
  public int startmoney=400;
  public static int lives;
  public int startlives=20;
  public static int rounds;
  void Start()
  {
    money=startmoney;
    lives= startlives;
    rounds=0;
  }

}
