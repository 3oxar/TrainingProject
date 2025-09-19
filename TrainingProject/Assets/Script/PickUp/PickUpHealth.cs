using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    [SerializeField] private int _healthUp;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HealthPlayer>().UpHealth(_healthUp);
            Destroy(gameObject);
        }
    }
}
