using System;
using _Sources._Scripts.Infrastructure;
using _Sources._Scripts.Services.Input;
using UnityEngine;

namespace _Sources._Scripts.Player
{
    public class TopDownCharacterController : MonoBehaviour
    {
        private const string IsMoving = "IsMoving";
        private const string X = "x";
        private const string Y = "y";
        
        [SerializeField] private float speed;
        
        private IInputService _inputService;
        private Animator _animator;
        private Rigidbody2D _rigidbody;
     

        private void Awake()
        {
            _inputService = Game.InputService;
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        

        private void Update()
        {
            Vector2 dir = Vector2.zero;
            dir.x = _inputService.Axis.x;
                dir.y = _inputService.Axis.y;
            _animator.SetInteger(X,  (int)dir.x);
            _animator.SetInteger(Y,  (int)dir.y);

            _animator.SetBool(IsMoving, dir.magnitude > 0);

           _rigidbody.velocity = speed * dir;
        }
    }
}
