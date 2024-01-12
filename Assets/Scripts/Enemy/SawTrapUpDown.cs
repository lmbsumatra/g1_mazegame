using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapUpDown : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private bool movingUp;
    private float topEdge;
    private float bottomEdge;

    private void Awake()
    {
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        if (movingUp)
        {
            if (transform.position.y < topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y > bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
