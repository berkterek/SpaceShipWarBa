using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Combats;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class ProjectileController : MonoBehaviour,IProjectileController
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] int _direction = 1;
        [SerializeField] float _maxTime = 5f;
        
        Rigidbody2D _rigidbody2D;
        float _currentTime = 0f;
        
        public IAttacker Attacker { get; private set; }

        void Awake()
        {
            Attacker = new Attacker();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            //movement
            _rigidbody2D.velocity = Vector2.up * _moveSpeed * _direction;
        }

        void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(this.gameObject);
        }
    }    
}