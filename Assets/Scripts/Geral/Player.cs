using UnityEngine;
using Photon.Pun;

public class Player : Dados
{
    //Dados dados = new Dados();
    
    void Awake() 
    { 
        if (pv.IsMine)
        {
            nome.text = PhotonNetwork.NickName;
            playerCamera.SetActive(true);
        }
        else
        {
            nome.text = photonView.Owner.NickName;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (pv.IsMine && !disableInput)
        {
            //CheckInput();
            Inputs();
        }
    }

    /*void CheckInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-8, 8, 1);
            directionRight = false;
            directionLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(8, 8, 1);
            directionRight = true;
            directionLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true) 
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pv.IsMine) 
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }          
        }  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(pv.IsMine) 
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }
    }
    void Shoot() 
    {
        //PhotonNetwork.Instantiate(bullet.name, pivot.position, pivot.transform.rotation);
        Shooter();
    }

    void Jump() 
    {
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Jumper();
    }
}
