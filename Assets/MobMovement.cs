using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    private Transform goblin_transform;
    private Animator goblin_animator;
    private Rigidbody goblin_rigidbody;
    private Transform player_transform;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        goblin_transform = gameObject.GetComponent<Transform>();
        goblin_animator = gameObject.GetComponent<Animator>();
        goblin_rigidbody = gameObject.GetComponent<Rigidbody>();
        goblin_rigidbody.angularVelocity.magnitude = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // goblin_transform.position = Vector3.MoveTowards(player_transform.position, goblin_transform.position, speed);
        goblin_transform.LookAt(player_transform);

        goblin_animator.SetFloat("VelX", goblin_transform.position.x);
        goblin_animator.SetFloat("VelY", goblin_transform.position.y);

    }
}