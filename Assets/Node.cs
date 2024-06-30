using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hovercolor;
    public Color startcolor;
    private Renderer rend;
    public Color notenoughmoneycolor;
     [Header("Optional")]
    public GameObject turret;
    public Vector3 positionofset;
    buildmanager Buildmanager;
    void Start()
    {
       
        rend=GetComponent<Renderer>();
        startcolor=rend.material.color;
        Buildmanager=buildmanager.instance;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!Buildmanager.canbuild)
        {
            return;
        }
        if ( turret!=null)
        {
            Buildmanager.selectnode(this);
            return;
        }
        Buildmanager.buildturreton(this);
    }
    void OnMouseEnter()
    {
        if ( EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!Buildmanager.canbuild)
        {
            return;
        }
        if(Buildmanager.hasmoney)
        {
            rend.material.color=hovercolor;
        }
        else
        {
            rend.material.color=notenoughmoneycolor;
        }
    }
    void  OnMouseExit()
    {
        rend.material.color=startcolor;
    }
    public Vector3 Getbuildposition()
    {
        return transform.position + positionofset;
    }
}
