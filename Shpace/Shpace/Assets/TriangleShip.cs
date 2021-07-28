using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleShip : MonoBehaviour
{

    public int damage = 1;
    public int health = 3;
    public float speed;
    public GameObject effect;
    public GameObject Tp;
    public float wait;
    public float start;
    public Transform shotPoint;
    public Transform Player;
    public Rigidbody2D rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        if (Vector2.Distance(transform.position, Player.position) > 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
        if (wait >= 0)
        {
            wait -= Time.deltaTime;
        }

        if (wait <= 0)
        {
            Instantiate(Tp, shotPoint.position, transform.rotation);

            wait = start;
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {

            other.GetComponent<laser>().health -= damage;
            Debug.Log(other.GetComponent<laser>().health);

        }
    }

}

