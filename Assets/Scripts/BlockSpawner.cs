using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour
{
    private float _lastSpawnTime;
    public float SpawnRate = 0.5f;
    public Vector2 SpawnAreaSize = new Vector2(1f, 1f);
    public float SpawnHeight = 20f;
    public GameObject BlockPrefab;

    public void SpawnBlock()
    {
        var spawnOffset = new Vector3(Random.Range(-SpawnAreaSize.x * 0.5f, SpawnAreaSize.x * 0.5f), 0f, Random.Range(-SpawnAreaSize.y * 0.5f, SpawnAreaSize.y * 0.5f));
        var spawnPos = transform.position + Vector3.up * SpawnHeight + spawnOffset;
        var spawnRotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up);

        var newBlock = Instantiate<GameObject>(BlockPrefab);
        newBlock.transform.position = spawnPos;
        newBlock.transform.rotation = spawnRotation;
        var meshRenderer = newBlock.GetComponent<MeshRenderer>();

        meshRenderer.material.SetColor("_EmissionColor", Utilities.HSVToRGB(Random.Range(0f, 1f), 1, 1));

        _lastSpawnTime = Time.time;
    }

    private void Update()
    {
        var timeSinceLastSpawn = Time.time - _lastSpawnTime;

        if (timeSinceLastSpawn > 1f / SpawnRate)
        {
            SpawnBlock();
        }
    }
}
