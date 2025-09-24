using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private MovmentPlayer _movmentPlayer;
    private FirePlayer _firePlayer;
    private Animator _playerAnimator;
   

    void Start()
    {
        _movmentPlayer = GetComponent<MovmentPlayer>();
        _firePlayer = GetComponent<FirePlayer>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_movmentPlayer.MoveInput != Vector2.zero)
            _playerAnimator.SetBool("Move", true);
        else
            _playerAnimator.SetBool("Move", false);

        if(_firePlayer.Fire != 0)
            _playerAnimator.SetBool("Attack", true);
        else
            _playerAnimator.SetBool("Attack", false);


    }
}
