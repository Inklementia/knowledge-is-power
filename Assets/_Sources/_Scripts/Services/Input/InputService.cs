using UnityEngine;

namespace _Sources._Scripts.Services.Input
{
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Fire = "Fire1";
        
        public Vector2 Axis => new Vector2(UnityEngine.Input.GetAxisRaw(Horizontal), UnityEngine.Input.GetAxisRaw(Vertical));
     

        public bool IsAttackButtonUp() => UnityEngine.Input.GetButtonUp(Fire);
    }
}

