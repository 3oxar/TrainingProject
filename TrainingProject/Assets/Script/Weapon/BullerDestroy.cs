using UnityEngine;

public class BullerDestroy : MonoBehaviour
{
    [SerializeField] private float _timeBullerDestroy;
    
    void Update()
    {
        _timeBullerDestroy -= Time.deltaTime;
        if(_timeBullerDestroy < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
