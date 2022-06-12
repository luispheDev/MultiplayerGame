using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

[SerializeField]
[AddComponentMenu("PhotonNetwork/PhotonView")]
public class ConfigPhanton
{
    #region Conectar Servidor
    public void Conect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Master()
    {
        PhotonNetwork.JoinLobby();
    }

    public  void Lobby()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    #region Pun

    public void Create(string name)
    {
        PhotonNetwork.CreateRoom(name);
    }

    public void Join(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

    public void OnJoin(string Scene)
    {
        PhotonNetwork.LoadLevel(Scene);
    }

    public void NickName(string name)
    {
        PhotonNetwork.NickName = name;
    }
    #endregion
}

