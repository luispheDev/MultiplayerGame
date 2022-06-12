using UnityEngine;
using Photon.Pun;

public class Bullet : Dados.Projectile
{
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OrientaçãoProjetil();
    }
    
    public void OnTriggerEnter2D(Collider2D col) 
    {
        if (!photonView.IsMine)
            return;
        
        PhotonView target = col.gameObject.GetComponent<PhotonView>();
        if(target != null && (!target.IsMine || target.IsRoomView)) 
        {
            if(target.tag == "Player")
            {
                target.RPC("HealthReduce", RpcTarget.AllBuffered, dmgBullet);
            }
            this.GetComponent<PhotonView>().RPC("DestroyObj", RpcTarget.AllBuffered);
        }
    }
}