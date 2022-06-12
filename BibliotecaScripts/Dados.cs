using Microsoft.VisualBasic;
using System.ComponentModel;
using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

[SerializeField]
[AddComponentMenu("PhotonView")]
public class Dados: MonoBehaviourPun
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] public PhotonView pv;
    [SerializeField] public GameObject playerCamera, bullet;
    [SerializeField] public Transform pivot;
    [SerializeField] public Text nome;
    [SerializeField] public float speed, jumpForce;
    public Rigidbody2D rb;
    [HideInInspector] public bool isGrounded = false;
    [HideInInspector] public bool directionRight, directionLeft, disableInput;
    
#region Funções do Player
    public void Inputs()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        rb.transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.transform.localScale = new Vector3(-8, 8, 1);
            directionRight = false;
            directionLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.transform.localScale = new Vector3(8, 8, 1);
            directionRight = true;
            directionLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            Jumper();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooter();
        }
    }

    public void Jumper()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Shooter()
    {
        PhotonNetwork.Instantiate(bullet.name, pivot.position, pivot.transform.rotation);
    }
#endregion

public class LifePlayer: MonoBehaviourPun
{
    #region Funções de Vida

    public Image Fill;
    public BoxCollider2D bx;
    public SpriteRenderer sp;
    public GameObject PlayerCanvas;
    public Player pMove;
    public float Health;
    
    Rigidbody2D rig;

    public void HealthChange(float amount)
    {
        if(photonView.IsMine)
        {
            Health -= amount; 
            Fill.fillAmount -= amount;
        }
        else
        {
            Health -= amount; 
            Fill.fillAmount -= amount; 
        }

        HealthCheck();
    }

    public void HealthCheck()
    {
        Fill.fillAmount = Health /100f;
        if(photonView.IsMine && Health <= 0)
        {
            pMove.disableInput = true;
            this.GetComponent<PhotonView>().RPC("Death", RpcTarget.AllBuffered);
            GameController.Instance.EnableRespawn();
        }
    }

    public void EnableInput()
    {
        pMove.disableInput = false;
    }

    [PunRPC]
    public void HealthReduce(float amount)
    {
        HealthChange(amount);
    }

    [PunRPC]
    public void Death()
    {
        rig.gravityScale = 0;
        bx.enabled = false;
        sp.enabled = false;
        PlayerCanvas.SetActive(false);
    }

    [PunRPC]
    public void Respawn()
    {
        rig.gravityScale = 1;
        bx.enabled = true;
        sp.enabled = true;
        PlayerCanvas.SetActive(true);
        Fill.fillAmount = 1;
        Health = 100f;
    }
#endregion
}

#region Funções do Projetil
public class Projectile: MonoBehaviourPun
{
    public float speedBullet = 10f, dmgBullet = 1f;
    public Rigidbody2D rb;

    public void OrientaçãoProjetil()
    {
        rb.velocity = transform.up * speedBullet;
        Destroy(gameObject, 3f);
    }

    [PunRPC]
    public void DestroyObj() 
    {
        Destroy(gameObject);
    }
}
#endregion
}
