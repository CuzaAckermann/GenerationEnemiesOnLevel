using System.Collections;
using UnityEngine;

public class ControllerSpawners : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delaySpawn = 2;

    private bool _canSpawning;
    private WaitForSeconds _wait;
    private Spawner _currentSpawner;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Initialize()
    {
        _canSpawning = true;
        _wait = new WaitForSeconds(_delaySpawn);
    }

    private IEnumerator SpawnEnemies()
    {
        while (_canSpawning && TryDetermineSpawner())
        {
            _currentSpawner.SpawnEnemy();
            yield return _wait;
        }
    }

    private bool TryDetermineSpawner()
    {
        if (_spawners.Length > 0)
        {
            int numberSpawner = Random.Range(0, _spawners.Length);
            _currentSpawner = _spawners[numberSpawner];
            return true;
        }

        return false;
    }
}