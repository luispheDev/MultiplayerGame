using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameController : MonoBehaviourPun
{
    public GameObject player, sceneCamera, canvasGame, UIdisconnect, respawnMenu;
    public GameObject localRespawn;
    public Text pingTxt, respawnTimerText;
    public float minX,minY,maxX,maxY;
    public static GameController Instance;
    [HideInInspector] public float Timer = 4;
    [HideInInspector] public bool offline = false, runSpawnTimer = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnPlayer();
        canvasGame.SetActive(true);
    }

    void Update() 
    {
        InputConfirmed();
        pingTxt.text = "Ping: " + PhotonNetwork.GetPing();

        if(runSpawnTimer)
        {
            RespawnPlayer();
        }
    }

    void InputConfirmed() 
    {
        if(offline && Input.GetKeyDown(KeyCode.Escape)) 
        {
            UIdisconnect.SetActive(false);
            offline = false;
        }
        else if (!offline && Input.GetKeyDown(KeyCode.Escape)) 
        {
            UIdisconnect.SetActive(true);
            offline = false;
        }
    }

    public void SpawnPlayer() 
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(player.name, randomPos, Quaternion.identity);
        sceneCamera.SetActive(false);
        canvasGame.SetActive(false);

    }

    void RespawnPlayer()
    {
        Timer -= Time.deltaTime;
        respawnTimerText.text = "Você retornará em..." + Timer.ToString("F0");

        if(Timer <= 0)
        {
            RespawnLocation();
            localRespawn.GetComponent<PhotonView>().RPC("Respawn", RpcTarget.AllBuffered);
            localRespawn.GetComponent<Life>().EnableInput();
            respawnMenu.SetActive(false);
            runSpawnTimer = false;
        }
    }

    public void RespawnLocation()
    {
        float Value = Random.Range(-2, 5f);
        localRespawn.transform.localPosition = new Vector2(Value, 3f);
    }

    public void EnableRespawn()
    {
        Timer = 4f;
        runSpawnTimer = true;
        respawnMenu.SetActive(true);
    }

    public void LeaveRoom() 
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(1);
    }
}
