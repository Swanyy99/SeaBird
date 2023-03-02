using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    [Range(0.1f, 5f)]
    private float repeatTime = 1.5f;

    [SerializeField]
    [Range(0f, 3f)]
    private float randomRange;


    Coroutine spawnRoutine = null;

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnFunc());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnRoutine);
    }

    private IEnumerator SpawnFunc()
    {
        for(;;)
        {
            yield return new WaitForSeconds(repeatTime);
            float random = Random.Range(-1 * randomRange, +1 * randomRange);
            Instantiate(pipe, spawnPosition.position + random * Vector3.up, spawnPosition.rotation);
        }
    }
}
