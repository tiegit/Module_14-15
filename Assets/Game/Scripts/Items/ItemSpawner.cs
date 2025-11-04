using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private List<SpawnPoint> _spawnPoints;
    private Item[] _itemPrefabs;

    private float _cooldown;
    private float _timer;

    public void Initialize(IEnumerable<SpawnPoint> spawnPoints, IEnumerable<Item> itemPrefabs, float cooldown)
    {
        _spawnPoints = new List<SpawnPoint>(spawnPoints);
        _itemPrefabs = itemPrefabs.ToArray();
        _cooldown = cooldown;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
            InstantiateItem();
    }

    private void InstantiateItem()
    {
        List<SpawnPoint> emptyPoints = GetEmptyPoints();

        if (emptyPoints.Count == 0)
        {
            _timer = 0;
            return;
        }

        SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

        Item randomItem = _itemPrefabs[Random.Range(0, _itemPrefabs.Length)];

        if (randomItem == null)
            return;

        Item item = Instantiate(randomItem, spawnPoint.Position, Quaternion.identity);

        spawnPoint.Occupy(item);

        _timer = 0;
    }

    private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in _spawnPoints)
        {
            if (point.IsEmpty)
                emptyPoints.Add(point);
        }

        return emptyPoints;
    }
}
