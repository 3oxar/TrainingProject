using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] private float _speedFlyBullet;

    private Rigidbody _rididbodyBuller { get => GetComponent<Rigidbody>(); }

    private void Start()
    {
        _rididbodyBuller.linearVelocity = _rididbodyBuller.transform.up * _speedFlyBullet;
    }
   
}
