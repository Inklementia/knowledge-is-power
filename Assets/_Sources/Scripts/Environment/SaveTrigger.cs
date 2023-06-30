using _Sources.Scripts.Services;
using _Sources.Scripts.Services.SaveLoad;
using UnityEngine;

namespace _Sources.Scripts.Environment
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;
        public BoxCollider2D Collider;

        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Saved progress");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!Collider) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(transform.position.x / 2, transform.position.y , transform.position.z), Collider.size);
        }
    }
}