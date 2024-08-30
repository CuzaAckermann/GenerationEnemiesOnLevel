using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Target _target;

    private Renderer _renderer;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        _target.Initialize(_renderer.material.color);
    }

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_prefabEnemy, transform.position, Quaternion.identity);
        enemy.Initialize(_target, _renderer.material.color);
    }

    private void Initialize()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}