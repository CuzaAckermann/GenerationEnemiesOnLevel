using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_prefabEnemy, transform.position, Quaternion.identity);
        enemy.Initialize(GenerateRotation(), _renderer.material.color);
    }

    private Quaternion GenerateRotation()
    {
        return Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
}