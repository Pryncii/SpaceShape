using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 touchPosition;
    public Rigidbody2D rb;
    private Vector3 direction;
    public float speed;
    public Transform shotPoint;
    public GameObject laser;
    public float wait;
    public float start;
   
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wait >= 0)
        {
            wait -= Time.deltaTime;
        }

        if(wait <= 0)
        {
            Instantiate(laser, shotPoint.position, transform.rotation);

            wait = start;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * speed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
}
