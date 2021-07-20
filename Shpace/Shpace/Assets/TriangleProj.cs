using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleProj : MonoBehaviour
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
