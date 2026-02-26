using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    Camera MainCamera;
    Ray rayFromPlayer;
    RaycastHit hit;
    public GameObject sparksAtImpact;
    public int WeaponAmmo = 25;
    public Text AmmoCount;
    public AudioSource ShootAudio;
    public ParticleSystem muzzleflash;

    // Start is called before the first frame update
    void Start()
    {
        AmmoCount.GetComponent<Text>();
        AmmoCount.text = "Ammo: " + WeaponAmmo;

        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rayFromPlayer = MainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(rayFromPlayer.origin, rayFromPlayer.direction * 1000, Color.red);

        if (Input.GetKeyDown(KeyCode.Mouse0) && WeaponAmmo > 0)
        {
            if (Physics.Raycast(rayFromPlayer, out hit, 1000))
            {
                print("The object " + hit.collider.gameObject.name + " is in front of the player");
                Vector3 positionOfImpact;
                positionOfImpact = hit.point;
                Instantiate(sparksAtImpact, positionOfImpact, Quaternion.identity);
                GameObject objectTargeted;
                if (hit.collider.gameObject.tag == "target")
                {
                    objectTargeted = hit.collider.gameObject;
                    objectTargeted.GetComponent<ManageNPC>().gotHit();
                }

            }

            WeaponAmmo--;
            AmmoCount.text = "Ammo: " + WeaponAmmo;

            ShootAudio.Play();

            muzzleflash.Play();
        }
    }

    public void WeaponAmmoAdd()
    {
        WeaponAmmo += 25;
        AmmoCount.text = "Ammo: " + WeaponAmmo;
    }
}
