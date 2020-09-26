using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Dependencies")]
    public Rigidbody rb;
    public float speed;
    public float turnSmoothTime;
    public Transform cam;
    public Animator animator;
    public float attackActive;

    [Header("State")]
    public int state = 0;
    public int args = 0;
    public float horizontal = 0f;
    public float vertical = 0f;
    public float cooldown = 0f;

    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }
        /*
         * State Controller
         * 
         * 0: Default
         * 1: Attack
         */
        switch (state) {
            case 1:
                // Attack();
                // InputUpdate();
                // Movement();
                // Transition();
                // break;
            default:
                InputUpdate();
                Movement();
                Transition();
                break;
        }
    }

    void Attack(){
        if(args == 3){
            args = 0;
        }else{
            args++;
            cooldown = attackActive;
        }
        animator.SetInteger("Attack", args);
    }

    void Transition() {
        if(Input.GetAxisRaw("Fire1") != 0){
            state = 1;
            args = -1;
        }
    }

    void InputUpdate(){
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void Movement(){
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
    }
}
