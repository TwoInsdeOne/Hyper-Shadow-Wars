using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D cc;
    public GameObject bullet;
    public Transform player;
    public float timer1;
    private float timer2;
    public float speed;
    public Transform bulletExit;
    public float angle;
    public int HP;
    public Animator ani;
    private bool alive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        timer2 = 2f;
        alive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        if(timer1 >= 0)
        {
            rb.velocity = new Vector2(-speed, 0);
            timer1 -= Time.deltaTime;
        } else
        {
            rb.velocity = Vector2.zero;
        }
        angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) ;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg*angle);
    }
    public void Shot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = bulletExit.position;
        b.transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg*(angle + Mathf.PI));
        b.GetComponent<bullet>().direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            HP = HP - collision.gameObject.GetComponent<bullet>().damage;
            if(HP <= 0)
            {
                alive = false;
                ani.SetTrigger("destroy");
                Destroy(gameObject, 1f);
            }
        }else if(collision.gameObject.tag == "wall2")
        {
            alive = false;
            ani.SetTrigger("destroy");
            Destroy(gameObject, 1f);
        }
    }
}
