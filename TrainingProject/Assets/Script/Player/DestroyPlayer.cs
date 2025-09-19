using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    HealthPlayer _healthPlayer;

    void Start()
    {
        _healthPlayer = GetComponent<HealthPlayer>();
        if (_healthPlayer)
        {
            Debug.LogError("Not component HealthPlayer");
            return;
        }
        _healthPlayer.DamagePlayerAction += CheakHealthPlayer;
    }
  
    private void CheakHealthPlayer()
    {
        if(_healthPlayer.HealthPlayerGet < 1)
        {
            Destroy(gameObject);
        }
    }
}
