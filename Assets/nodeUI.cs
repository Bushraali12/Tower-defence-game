using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeUI : MonoBehaviour
{
  public GameObject ui;
  private Node target;
  public void settarget(Node _target)
  {
    target=_target;
    transform.position = target.Getbuildposition();
    ui.SetActive(true);
  }
  public void hide()
  {
    ui.SetActive(false);
  }
}
