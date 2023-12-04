using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int keys = 0;
    public float speed = 5.0f;

    public Text keyAmount;
    public Text youWin;
    public GameObject door;
    

    // Start is called before the first frame update
    void Start()
    {
        // Add the Polygon Collider 2D component to the Player if not added already
        if (GetComponent<PolygonCollider2D>() == null)
        {
            gameObject.AddComponent<PolygonCollider2D>();GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous; 
    GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0; // Adjust gravity scale based on your game's requirements
        }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

    Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    transform.position = transform.position + horizontal * Time.deltaTime;

    Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
    transform.position = transform.position + vertical * Time.deltaTime;

    Debug.Log("hor: " + horizontal.x + ", " + horizontal.y + ", " + horizontal.z);
    Debug.Log("ver: " + vertical.x + ", " + vertical.y + ", " + vertical.z);

    

    // Move the Rigidbody2D using MovePosition for controlled movement
    // rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("Walls");
        }
    }
}
