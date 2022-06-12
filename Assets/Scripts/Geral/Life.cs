public class Life : Dados.LifePlayer
{
    void Awake()
    {
        if(photonView.IsMine)
        {
            GameController.Instance.localRespawn = this.gameObject;
        }
    }

    public void InputEnable()
    {
        EnableInput();
    }

    public void HealthChange()
    {
        HealthChange();
    }
}
