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
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
