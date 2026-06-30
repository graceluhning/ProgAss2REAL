using UnityEngine;
using System.Collections;

public class NPCCoroutine : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private Transform[] npcSpawns;

    private void Start()
    {
        StartCoroutine(SpawnNPCS());
    }

    private IEnumerator SpawnNPCS()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 7f));

            int randomIndex = Random.Range(0, npcSpawns.Length);

            SpawnPoints spawnPoint = npcSpawns[randomIndex].GetComponent<SpawnPoints>();

            if (spawnPoint.occupied)
                continue;

            spawnPoint.occupied = true;

            GameObject npcObj = Instantiate(
                npcPrefab,
                npcSpawns[randomIndex].position,
                Quaternion.identity
            );

            NPClogic npc = npcObj.GetComponent<NPClogic>();
            npc.spawnPoint = spawnPoint;
        }
    }
}