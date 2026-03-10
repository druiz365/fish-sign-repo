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

    [Header("Finish Object")]
    public GameObject doneObject;

    GameObject currentInstance;
    bool isRespawning;

    int spriteIndex = 0;
    bool finished = false;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRespawning && !finished)
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

        if (spriteIndex >= possibleSprites.Length)
        {
            finished = true;

            if (doneObject != null)
                doneObject.SetActive(true);

            return;
        }

        Transform t = spawnPoint ? spawnPoint : transform;
        currentInstance = Instantiate(reelInPrefab, t.position, t.rotation);

        Sprite chosen = possibleSprites[spriteIndex];
        spriteIndex++;

        var sr = currentInstance.GetComponent<SpriteRenderer>();
        if (sr != null && chosen != null)
        {
            sr.sprite = chosen;
        }
    }
}