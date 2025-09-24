using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    [HideInInspector] public float Fire { get => _fire; }

    [SerializeField] private GameObject _spawnBuller;
    [SerializeField] private GameObject _prefabBuller;

    [SerializeField] private float _fireSecondReload;

    private PlayerInput _playerInput;

    private float _fire;
    private float _firekReloadTime;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    private void OnEnable()
    {
        _playerInput.Player.Fire.performed += context => _fire = context.ReadValue<float>();
        _playerInput.Player.Fire.canceled += context => _fire = 0;

        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    void Update()
    {
        if(_fire > 0 && _firekReloadTime == 0)
        {
            Instantiate(_prefabBuller, _spawnBuller.transform.position, _spawnBuller.transform.rotation);
            _firekReloadTime = _fireSecondReload;
        }

        if(_firekReloadTime > 0)
        {
            _firekReloadTime -= Time.deltaTime;
        }
        else
        {
            _firekReloadTime = 0;
        }
    }
}
