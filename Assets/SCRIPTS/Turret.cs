using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
   [Header("Attributes")]

   private Transform target;
   public float range=15f;
   public float firerate=1f;
   public LineRenderer linerenderer;

   [Header("Unity Setup Field")]

   private float firecountdown=0f;
   public string enemyTag="Enemy";
   public Transform parttorotate;
   public float turnspeed=5f;
   public GameObject bulletprefab;
   public Transform firepoint;
   public bool uselaser;
   public ParticleSystem impacteffect;
   public int damageovertime=30;
   private enemy enemytarget;
   void Start()
   {
    InvokeRepeating("UpdateTarget",0f,0.5f);
   }
   void Update()
   {
    if( target == null)
       {
         if(uselaser)
         {
            if(linerenderer.enabled)
            linerenderer.enabled=false;
            impacteffect.Stop();
         }
         return;
       }
      Lockontarget();
   if (uselaser)
   {
      laserbem();
   }
   else
   {
      if (firecountdown <= 0)
      {
        shoot();
        firecountdown= 1f / firerate;
      }
     firecountdown=-Time.deltaTime;
   }
   }
   void Lockontarget()
   {
    Vector3 dir=target.position - transform.position;
    Quaternion lookRotation = Quaternion.LookRotation(dir);
    Vector3 rotation = Quaternion.Lerp(parttorotate.rotation,lookRotation,Time.deltaTime * turnspeed).eulerAngles;
    parttorotate.rotation = Quaternion.Euler(0f , rotation.y , 0f);
   }
   void OnDrawGizmosSelected()
   {
    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position, range);
   }
   void UpdateTarget()
   {
     GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
     float shortDistance =Mathf.Infinity;
     GameObject nearestEnemy=null;
     foreach (GameObject enemy in enemies)
     {
        float distanceToEnemy=Vector3.Distance (transform.position,enemy.transform.position);
        if (distanceToEnemy < shortDistance)
        {
            shortDistance=distanceToEnemy;
            nearestEnemy=enemy;
        }
     }
     if (nearestEnemy != null && shortDistance <= range)
     {
        target=nearestEnemy.transform;
        enemytarget=nearestEnemy.GetComponent<enemy>();
     }
   }
   void shoot()
   {
     GameObject bulletgo=(GameObject)Instantiate(bulletprefab,firepoint.position,firepoint.rotation);
     bullet bullets=bulletgo.GetComponent<bullet>();
     if(bullets!=null)
     {
      bullets.seek(target);
     }
   }
   void laserbem()
   {
      enemytarget.takedamage(damageovertime * Time.deltaTime);
      if(!linerenderer.enabled)
      {
         linerenderer.enabled=true;
         impacteffect.Play();
      }
      linerenderer.SetPosition(0,firepoint.position);
      linerenderer.SetPosition(1,target.position);
      Vector3 dir=firepoint.position-target.position;
      impacteffect.transform.position=target.position + dir.normalized * 0.5f;
      impacteffect.transform.rotation=Quaternion.LookRotation(dir);
  
   }
}
