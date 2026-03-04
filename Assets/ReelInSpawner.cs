using System.Collections;
using UnityEngine;

public class ReelInSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject reelInPrefab;

    [Header("Sprites to choose from")]
    public Sprite[] possibleSprites;

    [Header("Spawn")]
    public Transform spawnPoint;          
    public float respawnDelay = 1.0f;

    GameObject currentInstance;
    bool isRespawning;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRespawning)
        {
            StartCoroutine(DespawnAndRespawn());
        }
    }

    IEnumerator DespawnAndRespawn()
    {
        isRespawning = true;

        if (currentInstance != null)
        {
            Destroy(currentInstance);
            currentInstance = null;
        }

        yield return new WaitForSeconds(respawnDelay);

        Spawn();

        isRespawning = false;
    }

    void Spawn()
    {
        if (!reelInPrefab) return;

        Transform t = spawnPoint ? spawnPoint : transform;
        currentInstance = Instantiate(reelInPrefab, t.position, t.rotation);

        // Choose sprite in spawner
        Sprite chosen = ChooseRandomSprite();

        // Apply to spawned instance
        var sr = currentInstance.GetComponent<SpriteRenderer>();
        if (sr != null && chosen != null)
        {
            sr.sprite = chosen;
        }
    }

    Sprite ChooseRandomSprite()
    {
        if (possibleSprites == null || possibleSprites.Length == 0) return null;
        return possibleSprites[Random.Range(0, possibleSprites.Length)];
    }
}