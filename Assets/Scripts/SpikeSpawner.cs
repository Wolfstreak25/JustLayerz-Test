using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_spikePrefab;
    [SerializeField] private Vector3 m_spawnPosition;
    public void SpawnSpike()
    {
        GameObject.Instantiate(m_spikePrefab,m_spawnPosition,Quaternion.identity);
    }
}
