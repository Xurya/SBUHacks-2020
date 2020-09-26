using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public float turnSmoothTime;
    public Transform cam;

    public Animator animator;

    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;
            rb.velocity = movedir * speed * Time.deltaTime;
        }else{
            rb.velocity = Vector3.zero;
        }

        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY", vertical);
    }
}
