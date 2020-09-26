using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Controller : MonoBehaviour
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

    public GameObject player;
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
        HP = 5 * stat_Con;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, player.gameObject.transform.position) < 10) {
            this.transform.LookAt(player.transform);
        }
        if (Vector3.Distance(this.gameObject.transform.position, player.gameObject.transform.position) < 1) {
            // anim.SetBool()
        }
    }
}
