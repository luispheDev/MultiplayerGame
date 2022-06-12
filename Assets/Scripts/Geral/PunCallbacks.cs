using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PunCallbacks : MonoBehaviourPunCallbacks
{
    public ConfigPhanton config = new ConfigPhanton();
    public GameObject ConnectedScreen, DisconnectedScreen;

    private void Start()
    {
        config.Conect();
    }

    public override void OnConnectedToMaster()
    {
        config.Master();
    }

    public override void OnJoinedLobby()
    {
        config.Lobby();
    }


    #region ConfigPhotonAntiga 
    /*public GameObject ConnectedScreen;
    public GameObject DisconnectedScreen;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(1);
    }*/
    #endregion
}
