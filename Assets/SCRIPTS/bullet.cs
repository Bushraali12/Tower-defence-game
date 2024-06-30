
using UnityEngine;

public class bullet : MonoBehaviour
{
  private Transform target;
  public float speed =70f;
  public float explosionradius=0f;
  public GameObject impacteffect;
  public int damage=100;
  public void seek(Transform _target)
  {
     target=_target;
  }
  void Update()
  {
    if (target==null)
    {
        Destroy(gameObject);
        return;
    }
    Vector3 dir=target.position-transform.position;
    float distanceframe=speed * Time.deltaTime;
    if(dir.magnitude <= distanceframe)
    {
        HitTarget();
        return;
    }
    transform.Translate(dir.normalized * distanceframe,Space.World);
    transform.LookAt(target);
  }
  void HitTarget()
{
    GameObject effectins = (GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
    Destroy(effectins, 5f);
    if (explosionradius > 0)
    {
        Explode();
    }
    else
    {
        Damage(target);
    }

    enemy e = target.GetComponent<enemy>();
    if (e != null)
    {
        e.takedamage(damage);
        if (e.health <= 0)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
    else
    {
        Destroy(gameObject);
    }
}
void Explode()
  {
    Collider[] colliders=Physics.OverlapSphere(transform.position,explosionradius);
    foreach( Collider collider in colliders)
    {
      if (collider.tag == "enemy")
      {
        Damage(collider.transform);
      }
    }

  }
void Damage(Transform enemy)
{
    enemy e = enemy.GetComponent<enemy>();
    if (e != null)
    {
        e.takedamage(damage);
    }
}
  void OndrawGizmos()
  {
    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position,explosionradius);
  }
  
}