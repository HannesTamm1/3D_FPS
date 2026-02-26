using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageNPC : MonoBehaviour
{
    public int HealthNPC = 100;
    public GameObject DestroyEffect;
    public AudioSource DestroySoundNPC;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HealthNPC <= 0)
        {
            GameObject destroyeffect = (GameObject)(Instantiate(DestroyEffect, transform.position, Quaternion.identity));
            Destroy(destroyeffect, 3);
            Destroy(gameObject);
            DestroySoundNPC.Play();
        }
    }

    public void gotHit()
    {
        HealthNPC -= 50;
    }
}
