using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class Config : MonoBehaviourPunCallbacks
{
    ConfigPhanton config = new ConfigPhanton();
    public InputField criarSala;
    public InputField entrarSala;
    public InputField digitarNome;
    public Button confirmarNome;

    #region Pun
    public void CreateRoom()
    {
        config.Create(criarSala.text);
    }

    public void JoinRoom()
    {
        config.Join(entrarSala.text);
    }

    public override void OnJoinedRoom()
    {
        config.OnJoin("CenaGame1");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Sala falhou" + returnCode + "message" + message);
    }

    public void OnNameChange() 
    {
        if(digitarNome.text.Length > 2) 
        {
            confirmarNome.interactable = true;
        }
        else 
        {
            confirmarNome.interactable = false;
        }
    }
    public void OnClickName() 
    {
        config.NickName(digitarNome.text);
    }
    #endregion
}
