using ObjectPool;
using UnityEngine;

namespace Ship
{
    public class Bullet : MonoBehaviour
    {
        private SimplePool<Bullet> _pool;
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Constructor(SimplePool<GameObject> pool)
        {
            
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            
        }
    }
}
