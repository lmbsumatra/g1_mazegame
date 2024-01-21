using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int keys = 0;


    public Text keyAmount;
    public Text youWin;
    public GameObject door;

    private Animator anim;

    private float x, y;
    private bool is_walking;
    public float speed = 5.0f;

    [SerializeField] private AudioClip walkSound;

    private bool canMove = true; // Add a flag to control player movement

    // Start is called before the first frame update
    void Start()
    {
        // Add the Polygon Collider 2D component to the Player if not added already
        if (GetComponent<PolygonCollider2D>() == null)
        {
            gameObject.AddComponent<PolygonCollider2D>(); GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0; // Adjust gravity scale based on your game's requirements

        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;

            Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
            transform.position = transform.position + vertical * Time.deltaTime;

            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
            {
                if (!is_walking)
                {
                    is_walking = true;
                    anim.SetBool("is_walking", is_walking);
                    SoundManager.instance.PlaySound(walkSound);
                }

                Move();


            }
            else
            {
                if (is_walking)
                {
                    is_walking = false;
                    anim.SetBool("is_walking", is_walking);
                }
            }
        }


    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    private void Move()
    {
        anim.SetFloat("X", x);
        anim.SetFloat("Y", y);

        transform.Translate(x * Time.deltaTime * speed, y * Time.deltaTime * speed, 0);
    }
}
