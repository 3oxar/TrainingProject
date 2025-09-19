using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int HealthPlayerGet { get => _healthPlayer; }
    
    [SerializeField] private int _healthPlayer;

    public Action DamagePlayerAction;

    public void DamagePlayer(int changedPointsHealth)
    {
        _healthPlayer -= changedPointsHealth;
        DamagePlayerAction?.Invoke();
    }

    public void UpHealth(int changedPointshealth)
    {
        _healthPlayer += changedPointshealth;
    }
}
