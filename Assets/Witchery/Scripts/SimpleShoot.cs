using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using FMODUnity;


[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]

    public GameObject IcePrefab;
    public GameObject EarthPrefab;
    public GameObject FirePrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


   // public AudioSource source;
   // public AudioClip fireGunSound;
   // public AudioClip reload;
   // public AudioClip gunDryfire;
    public Ammo ammo;
    public XRBaseInteractor socketInteractor;
    public int FireAmmoLeft= 0;
    public int IceAmmoLeft = 0;
    public int EarthAmmoLeft = 0;



    [SerializeField] EventReference WandFire;
    [SerializeField] EventReference WandIce;
    [SerializeField] EventReference WandEarth;
    [SerializeField] EventReference WandChargeUp;
    [SerializeField] EventReference WandDryfire;

    void Start()
    {
        
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

       // socketInteractor.onSelectEntered.AddListener(AddMagazine);
       // socketInteractor.onSelectExited.AddListener(RemoveMagazine);
    }

    public void FireGun()
    {
        // if the gun have bullets left then call the animator to fire the gun
        if (FireAmmoLeft > 0)
        {
            Debug.Log("Fired The gun");
            // gunAnimator.SetTrigger("Fire"); 
            ShootFire();

        }
        else if (IceAmmoLeft > 0)
        {
            ShootIce();
        }

        else if (EarthAmmoLeft > 0)
        {
            ShootEarth();
        }


        else
        {
            RuntimeManager.PlayOneShot(WandDryfire);
            Debug.Log("Dry fired");
         //   source.PlayOneShot(gunDryfire);
        }
   
    }


    //This function creates the bullet behavior
    void ShootFire()
    {
        // Plays the fireGunsound 
       // source.PlayOneShot(fireGunSound);
        RuntimeManager.PlayOneShot(WandFire);

        if (muzzleFlashPrefab)
        {
            FireAmmoLeft--;
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!FirePrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(FirePrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    void ShootIce()
    {
        // Plays the fireGunsound 
        // source.PlayOneShot(fireGunSound);
        RuntimeManager.PlayOneShot(WandIce);

        if (muzzleFlashPrefab)
        {
            IceAmmoLeft--;
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!IcePrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(IcePrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    void ShootEarth()
    {
        // Plays the fireGunsound 
        // source.PlayOneShot(fireGunSound);
        RuntimeManager.PlayOneShot(WandEarth);

        if (muzzleFlashPrefab)
        {
            EarthAmmoLeft--;
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!EarthPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(EarthPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }


    public void AddMagazine(XRBaseInteractable interactable)
    {
        // when magazine is added to the gun then get the component ammo.
        ammo = interactable.GetComponent<Ammo>();

        // player the reload sound
      //  source.PlayOneShot(reload);
    }

    /*   public void RemoveMagazine(XRBaseInteractable interactable)
       {
           // reset the ammo when the magazine is removed.
           ammo = null;


       } */

    public void PaternRecognition(string patternName)
    {
        if (patternName == "Fire")
        {
            RuntimeManager.PlayOneShot(WandChargeUp);
            Debug.Log("Fire was drawn");
            FireAmmoLeft++;
        }

        if (patternName == "Earth")
        {
            RuntimeManager.PlayOneShot(WandChargeUp);
            Debug.Log("Earth was drawn");
            EarthAmmoLeft++;
        }

        if (patternName == "Ice")
        {
            RuntimeManager.PlayOneShot(WandChargeUp);
            Debug.Log("Ice was drawn");
            IceAmmoLeft++;
        }


    }

}
