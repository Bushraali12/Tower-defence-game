using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text roundtext;
    void OnEnable()
    {
        roundtext.text=playerstates.rounds.ToString();
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void menu()
    {
        Debug.Log("Go to menu");
    }
}
