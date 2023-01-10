
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;
    public int MaxAmmo = 30;
    public float FireRate = 15f;
    public int CurrentAmmo;
    public Text ammoDisplay;
    public Camera FPSCam;
    public ParticleSystem muzzleFlash;
    private float nextTimeToFire = 0f;
    public AudioSource shootSound;

    // Update is called once per frame
    void Start()
    {
        CurrentAmmo = MaxAmmo;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            if (CurrentAmmo == 0)
            {
                return;
            }
            else
            {
                nextTimeToFire = Time.time + 1f / FireRate;
                Shoot();
                CurrentAmmo -= 1;
            }
        }
        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }
        ammoDisplay.text = CurrentAmmo + "/" + MaxAmmo;
    }
    void Shoot(){
        muzzleFlash.Play();
        shootSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, Range)){
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null){
                target.TakeDamage(Damage);
            }
        }
    }
    void Reload()
    {
        CurrentAmmo = MaxAmmo;
    }
}
