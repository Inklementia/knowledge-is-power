using _Sources.Scripts.Data;
using _Sources.Scripts.Services;
using _Sources.Scripts.Services.Input;
using _Sources.Scripts.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Sources.Scripts.Player
{
    public class TopDownCharacterController : MonoBehaviour,ISavedProgress
    {
        private const string IsMoving = "IsMoving";
        private const string X = "x";
        private const string Y = "y";
        
        [SerializeField] private float speed;
        
        private IInputService _inputService;
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        
        private static readonly int Y1 = Animator.StringToHash(Y);
        private static readonly int X1 = Animator.StringToHash(X);
        private static readonly int Moving = Animator.StringToHash(IsMoving);
        
        private static string CurrentLevel() => SceneManager.GetActiveScene().name;
              
        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        

        private void Update()
        {
            Vector2 dir = Vector2.zero;
            dir.x = _inputService.Axis.x;
                dir.y = _inputService.Axis.y;
            _animator.SetInteger(X1,  (int)dir.x);
            _animator.SetInteger(Y1,  (int)dir.y);

            _animator.SetBool(Moving, dir.magnitude > 0);

           _rigidbody.velocity = speed * dir;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() != progress.WorldData.PositionOnLevel.Level) return;
            
            var savedPosition = progress.WorldData.PositionOnLevel.Position;
            if (savedPosition != null)
            {
                Warp(savedPosition);
            }
        }

        private void Warp(Vector3Data savedPosition)
        {   
            // disable physics
            
            transform.position = savedPosition.AsUnityVector();
            //addY for 3D space
            // enable physics
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        }
    }
}
