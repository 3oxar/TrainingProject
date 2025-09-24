using System;
using UnityEngine;

public class MovmentPlayer : MonoBehaviour
{
    [HideInInspector] public Vector2 MoveInput { get => _moveInput; }
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jerkForse;
    [SerializeField] private float _jerkSecondReload;
    

    private PlayerInput _playerInput;
    private Rigidbody _playerRigidbody { get => GetComponent<Rigidbody>(); }

    private Vector2 _moveInput;
    private float _jerk;
    private float _jerkReloadTime;
    

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    private void OnEnable()
    {
        _playerInput.Player.Move.performed += context => _moveInput = context.ReadValue<Vector2>();
        _playerInput.Player.Move.canceled += context => _moveInput = Vector2.zero;

        _playerInput.Player.Jerk.performed += context => _jerk = context.ReadValue<float>();
        _playerInput.Player.Jerk.canceled += context => _jerk = 0;

        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
   
    private void FixedUpdate()
    {
        if (_moveInput != Vector2.zero)
        {
            Vector3 newMoveInput = new Vector3(_moveInput.x, 0, _moveInput.y);
            MovePlayer(newMoveInput);
            RotatePlayer(newMoveInput);

            if (_jerk != 0 && _jerkReloadTime == 0)
            {
                JerkPLayer(newMoveInput);
                _jerkReloadTime = _jerkSecondReload;
            }
           
        }

        if(_jerk == 0)
        {
            _playerRigidbody.angularVelocity = Vector3.zero;
        }

        if(_jerkReloadTime > 0)
        {
            _jerkReloadTime -= Time.deltaTime;
        }
        else
        {
            _jerkReloadTime = 0;
        }
       
    }

    private void JerkPLayer(Vector3 moveInput)
    {
        _playerRigidbody.AddForce(moveInput * _jerkForse, ForceMode.Impulse);
    }

    private void MovePlayer(Vector3 moveInput)
    {
        Vector3 offset = moveInput * _moveSpeed * Time.deltaTime;
        _playerRigidbody.MovePosition(_playerRigidbody.position + offset);
    }

    private void RotatePlayer(Vector3 moveInput)
    {
        if(Vector3.Angle(transform.forward, _moveInput) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveInput, _rotateSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
