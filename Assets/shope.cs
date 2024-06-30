using UnityEngine;

public class shope : MonoBehaviour
{
    buildmanager Buildmanager;
    public turretblueprints standardTurret;
    public turretblueprints missilelauncher;
    public turretblueprints laserbemmer;

    void Awake()
    {
        Buildmanager = buildmanager.instance;
    }

    public void selectpurchasestandardturret()
    {
        if (Buildmanager != null)
        {
            Debug.Log("first turret is selected");
            Buildmanager.selectsetturrettobuild(standardTurret);
        }
        else
        {
            Debug.LogWarning("Buildmanager is not properly initialized.");
        }
    }

    public void selectpurchasemissilelauncher()
    {
        if (Buildmanager != null)
        {
            Debug.Log("purchase for missile is selected");
            Buildmanager.selectsetturrettobuild(missilelauncher);
        }
        else
        {
            Debug.LogWarning("Buildmanager is not properly initialized.");
        }
    }
    public void selectlasserbemmer()
    {
        if (Buildmanager != null)
        {
            Debug.Log("purchase for laser bemer is selected");
            Buildmanager.selectsetturrettobuild(laserbemmer);
        }
        else
        {
            Debug.LogWarning("Buildmanager is not properly initialized.");
        }
    }
}
