using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;

    private Collider _collider;
    private Renderer _renderer;

    public Collider Collider => _collider;

    private void Awake()
    {
        SetComponents();
    }

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_collider != null && enemy.Collider != null)
                Physics.IgnoreCollision(_collider, enemy.Collider);
        }
    }

    public void Initialize(Quaternion rotation, Color color)
    {
        transform.rotation = rotation;
        _renderer.material.color = color;
    }

    private void SetComponents()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }
}