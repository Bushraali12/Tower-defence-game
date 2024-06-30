using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
   public static bool Gameover= false;
   public GameObject gameoverUi;
   void Start()
    {
        Gameover = false;
    }
   void Update()
   {
    if(Gameover)
    {
        return;
    }
    if ( Input.GetKeyDown("e"))
    {
        Endgame();
    }
    if( playerstates.lives <= 0)
    {
        Endgame();
    }
   }
   void Endgame()
   {
     Gameover = true;
     gameoverUi.SetActive(true);
   
   }
}
