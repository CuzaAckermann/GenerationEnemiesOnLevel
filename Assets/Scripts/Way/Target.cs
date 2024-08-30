using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Target : MonoBehaviour
{
    [SerializeField] private Way _way;
    [SerializeField] private CheckPoint _currentCheckPoint;
    [SerializeField] private float _moveSpeed;

    private float _distance;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetNextCheckPoint();
    }

    private void Update()
    {
        if (_distance == 0)
        {
            SetNextCheckPoint();
        }
        
        MoveToCheckPoint();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
        }
    }

    public void Initialize(Color color)
    {
        _renderer.material.color = color;
    }

    private void MoveToCheckPoint()
    {
        transform.LookAt(_currentCheckPoint.transform.position);
        Vector3 velocity = _moveSpeed * Time.deltaTime * Vector3.forward;
        transform.Translate(velocity);

        if (_distance > _moveSpeed * Time.deltaTime)
        {
            _distance = Vector3.Distance(transform.position, _currentCheckPoint.transform.position);
        }
        else
        {
            _distance = 0;
        }
    }

    private void SetNextCheckPoint()
    {
        _currentCheckPoint = _way.GetNextCheckPoint(_currentCheckPoint);
        _distance = Vector3.Distance(transform.position, _currentCheckPoint.transform.position);
    }
}