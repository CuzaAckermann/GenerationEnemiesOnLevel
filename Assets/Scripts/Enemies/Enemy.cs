using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;

    private Target _target;
    private Collider _collider;
    private Renderer _renderer;

    public Collider Collider => _collider;

    private void Awake()
    {
        SetComponents();
    }

    private void Update()
    {
        if (_target != null)
        {
            MoveToTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Physics.IgnoreCollision(_collider, enemy.Collider);
        }
    }

    public void Initialize(Target target, Color color)
    {
        _target = target;
        _renderer.material.color = color;
    }

    private void SetComponents()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }

    private void MoveToTarget()
    {
        transform.LookAt(_target.transform.position);
        Vector3 velocity = _moveSpeed * Time.deltaTime * Vector3.forward;
        transform.Translate(velocity);
    }
}