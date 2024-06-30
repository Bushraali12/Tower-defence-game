using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildmanager : MonoBehaviour
{
    private turretblueprints turrettobuild;
    private Node selectednode;
    public static buildmanager instance;
    public nodeUI nodeui;

    public GameObject buildeffect;
    void Awake()
    {
        if (instance !=null)
        {
            Debug.LogError("two buildmanagers");
            return;
        }
        instance=this;
    }
    public void buildturreton(Node node)
    {
      if(playerstates.money < turrettobuild.cost)
       {
        Debug.Log("no money left");
        return;
       }
       playerstates.money-=turrettobuild.cost;
       GameObject turret=(GameObject)Instantiate(turrettobuild.prefab,node.Getbuildposition(),Quaternion.identity);
       node.turret=turret;
       GameObject effect=(GameObject)Instantiate(buildeffect,node.Getbuildposition(),Quaternion.identity);
       Destroy(effect,5f);
       Debug.Log("turret build:Money left"+ playerstates.money);
      
        
    } 
   
    public bool canbuild { get { return turrettobuild != null; } }
    public bool hasmoney { get { return playerstates.money >= turrettobuild.cost;} }
    public void selectsetturrettobuild(turretblueprints turret)
    {
       turrettobuild=turret;
    }
    public void selectnode(Node node)
    {
        selectednode=node;
        turrettobuild=null;
        nodeui.settarget(node);
        // nodeui.hide();

    }
}
