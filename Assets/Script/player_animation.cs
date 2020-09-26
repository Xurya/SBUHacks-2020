using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour
{
    private int level = 1;
    private int exp = 100;
    private int stat_Con;
    private int stat_Agi;
    private int stat_Str;
    private int stat_Dex;
    private int stat_Int;
    private int stat_Luc;
    private int HP;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        stat_Agi = Random.Range(1, 6*2*level);
        stat_Con = Random.Range(1, 6*2*level);
        stat_Dex = Random.Range(1, 6*2*level);
        stat_Int = Random.Range(1, 6*2*level);
        stat_Luc = Random.Range(1, 6*2*level);
        stat_Str = Random.Range(1, 6*2*level);
        HP = 10 * stat_Con;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(horizontal, vertical);
        if (Input.GetKey(KeyCode.J)) {
            slash();
        }
        else {
            anim.SetBool("slash", false);
        }
        if (Input.GetKey(KeyCode.K)) {
            wide_slash();
        }
        else {
            anim.SetBool("wide_slash", false);
        }
        if (Input.GetKey(KeyCode.L)) {
            lunge();
        }
        else {
            anim.SetBool("lunge", false);
        }
    }
    private void Move(float x, float y) {
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
    private void slash() {
        anim.SetBool("slash", true);
    }
    private void wide_slash() {
        anim.SetBool("wide_slash", true);
    }
    private void lunge() {
        anim.SetBool("lunge", true);
    }
}
