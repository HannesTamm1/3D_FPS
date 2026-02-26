using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    public Transform PlayerTransform;
    public float MoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, PlayerTransform.position, MoveSpeed * Time.deltaTime);

        // Rotate towards the player
        transform.LookAt(PlayerTransform);
    }
}
