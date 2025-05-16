using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public SpriteRenderer spriteRenderer;
    public GameObject explosionFX;
    public ParticleSystem ps;
    private CircleCollider2D cc;
    public int damage;
    public int score;
    private PlayerShot player;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        player = GameObject.Find("Player").GetComponent<PlayerShot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "EnemyBullet" && collision.gameObject.tag == "PlayerBullet")
        {
            player.IncreaseScore(score);
        }
        spriteRenderer.enabled = false;
        Destroy(rb);
        Destroy(cc);
        Destroy(gameObject, 0.5f);
        GameObject fx = Instantiate(explosionFX);
        fx.transform.position = transform.position;
        ParticleSystem.EmissionModule emi = ps.emission;
        emi.rateOverTime = 0;
    }
}
