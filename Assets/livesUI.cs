using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class livesUI : MonoBehaviour
{
    public Text livetext;
    void Update()
    {
        livetext.text=playerstates.lives.ToString() + "Lives";
    }
}
