using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;
    float time;
    public AudioSource NPCshootAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            time = 0;
            transform.LookAt(target.transform);
            GameObject t = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
            NPCshootAudio.Play();
            Destroy(t, 3);
            t.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }
    }
}
