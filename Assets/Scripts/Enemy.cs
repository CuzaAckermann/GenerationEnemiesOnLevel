using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), enemy.gameObject.GetComponent<Collider>());
        }
    }

    public void Initialize(Quaternion rotation, Color color)
    {
        transform.rotation = rotation;
        _renderer.material.color = color;
    }
}