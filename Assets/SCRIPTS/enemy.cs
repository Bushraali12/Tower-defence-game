using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed=10f;
    private Transform target;
    private int wavepointindex=0;
    public float health;
    public int value=50;
    public void takedamage(float amount)
    {
       health -= amount;
       if( health <= 0)
       {
        Die();
       }
    }
    void Die()
{ 
    playerstates.money += value;
    Debug.Log("Money we have now is: " + playerstates.money);
    Destroy(gameObject);
    }
    void Start()
    {
        target= waypoints.points[0];
    }
    void Update()
    {
        Vector3 dir=target.position-transform.position;
        transform.Translate(dir.normalized * speed *Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position,target.position)<=0.2f)
        {
           GetNextWayPoint();
        }
    }
   void GetNextWayPoint()
   {
    if (wavepointindex >= waypoints.points.Length - 1)
    {
        Endpath();
        return; // Exit the method after calling Endpath()
    }

    wavepointindex++;
    target = waypoints.points[wavepointindex];
    }
    void Endpath()
    {
        playerstates.lives--;
        Destroy(gameObject);
    }
}
