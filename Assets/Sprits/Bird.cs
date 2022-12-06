using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator animator;
    public float fuerzaSalto;
    public Rigidbody2D rigidbody2D;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));

            System.Threading.Thread.Sleep(30);
            animator.SetBool("estaSaltando", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            
            gameManager.gameOver = true;
        }
    }
}
