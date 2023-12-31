using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private Rigidbody2D rig;
    public int Fruta;
    private Vector3 olhandoDireita;
    private Vector3 olhandoEsquerda;
    private float direcao;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
       
    }

    void Move()
    { 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        if (direcao > 0 ) 
        {
            transform.localScale = olhandoDireita;
        }
        if (direcao < 0)
        {
            transform.localScale = olhandoEsquerda;
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruta")
        {
            Destroy(collision.gameObject);
            Fruta = Fruta + 1;
        }
    }
   
}
