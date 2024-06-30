using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
  public Transform enemyprefabs;
  public Transform spawnPoint;
  public float timebtwwaves=5f;
  private float countdown=2f;
  private int wavenumber=0;
  public Text wavecountdown;
  void Update()
  {
    if(countdown <= 0f)
    {
      StartCoroutine(SpawnWaves());
      countdown=timebtwwaves;
      return;
    }
    countdown-=Time.deltaTime;
    countdown=Mathf.Clamp(countdown,0f,Mathf.Infinity);
    wavecountdown.text=string.Format("{0:00.00}",countdown);

  }
  IEnumerator SpawnWaves()
  {
    playerstates.rounds++;
     for ( int i=0 ; i< wavenumber ; i++)
     {
        spawnenemy();
        yield return new WaitForSeconds(0.5f);
     }
     wavenumber++;
  }
  void spawnenemy()
  {
    Instantiate(enemyprefabs, spawnPoint.position, spawnPoint.rotation);
  }
}  