using System.Collections.Generic;
using UnityEngine;

public class FrozenPickUp : MonoBehaviour
{
    [SerializeField] private List<Shader> _shaderPlayerList;
    [SerializeField] private float _secondReturnBackStandartEffect;

    private Renderer _player;
    private float _timeReturnBackStandartEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(_shaderPlayerList.Count == 0)
        {
            Debug.LogError("List Shader 0 cout.");
            return;
        }

        if (_timeReturnBackStandartEffect == 0)
        {
            _player = other.GetComponentInChildren<Renderer>();
            if(_player == null)
            {
                Debug.LogError("Null shader player component.");
                return;
            }
            _player.material.shader = _shaderPlayerList[1];
            _timeReturnBackStandartEffect = _secondReturnBackStandartEffect;
        }
    }

    private void Update()
    {
        if(_timeReturnBackStandartEffect > 0)
        {
            _timeReturnBackStandartEffect -= Time.deltaTime;
        }
        else if(_timeReturnBackStandartEffect <= 0 && _player != null)
        {
            _player.material.shader = _shaderPlayerList[0];
            _timeReturnBackStandartEffect = 0;
        }
    }
}
