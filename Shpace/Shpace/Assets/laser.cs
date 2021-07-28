using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    public int damage = 1;
    public int health = 1;
    public float speed;
    public GameObject effect;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

      
        if (other.CompareTag("TP"))
        {
            other.GetComponent<TriangleProj>().health -= damage;
            Debug.Log(other.GetComponent<TriangleProj>().health);
            
        }

        if (other.CompareTag("TS"))
        {
            other.GetComponent<TriangleShip>().health -= damage;
            Debug.Log(other.GetComponent<TriangleShip>().health);
        }

        if (other.CompareTag("Asteroid"))
        {
            other.GetComponent<Asteroid>().health -= damage;
            Debug.Log(other.GetComponent<Asteroid>().health);
        }
    }
}
