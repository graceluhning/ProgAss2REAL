using UnityEngine;
using System.Collections;

public class NPCCoroutine : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private Transform[] npcSpawns;

    public DayCounter dayCounter;


    private void Start()
    {
        StartCoroutine(SpawnNPCS());
    }


    private IEnumerator SpawnNPCS()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetSpawnTime());


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


    private float GetSpawnTime()
    {
        int day = dayCounter.dayCount;


        float baseMin = 3f;
        float baseMax = 7f;

        float decreasePerDay = 1f;


        float minTime = baseMin - ((day - 1) * decreasePerDay);
        float maxTime = baseMax - ((day - 1) * decreasePerDay);


        return Random.Range(minTime, maxTime);
    }
}