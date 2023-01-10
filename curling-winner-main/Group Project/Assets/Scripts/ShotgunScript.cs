using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Damage = 10f;
    public float Range = 100f;
    public int MaxAmmo = 6;
    public int CurrentAmmo;
    float timeForNextAttack;
    public float Cooldown;

    

    public int bulletsPerShot = 6;
    public float inaccuracyDistance = 5f;
    //private float nextTimeToFire = 0f;
    
    public Text ammoDisplay;
    public Camera FPSCam;
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;

    
    void Start()
    {
        CurrentAmmo = MaxAmmo;
        Cooldown = 1;
        timeForNextAttack = Cooldown;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeForNextAttack > 0)
        {
            timeForNextAttack -= Time.deltaTime;
        }
        else if(timeForNextAttack <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (CurrentAmmo == 0)
                {
                    return;
                }
                else
                {
                    Shoot();
                    CurrentAmmo -= 1;
                    timeForNextAttack = Cooldown;
                }
            }
        }
        
        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }
        ammoDisplay.text = CurrentAmmo + "/" + MaxAmmo;
    }
    void Shoot()
    {
        muzzleFlash.Play();
        shootSound.Play();
        for (int i = 0; i < bulletsPerShot; i++) {
            RaycastHit hit;
            if (Physics.Raycast(FPSCam.transform.position, GetShootingDirection(), out hit, Range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(Damage);
                }
            }
            
        }
        
    }

    Vector3 GetShootingDirection()
    {
        Vector3 TargetPos = FPSCam.transform.position + FPSCam.transform.forward * Range;
        TargetPos = new Vector3(
          TargetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
          TargetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
          TargetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)

          );

        Vector3 direction = TargetPos - FPSCam.transform.position;
        return direction.normalized;
    }
    void Reload()
    {
        CurrentAmmo = MaxAmmo;
    }
}
