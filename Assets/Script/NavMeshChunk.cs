using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;


[Serializable]
public struct navMeshChank
{
    public Vector3 EulerRotation;

    public NavMeshData Data;
    public bool Enabled;
}

public class NavMeshChunk : MonoBehaviour
{
    [SerializeField]
    private List<navMeshChank> _navMeshChunks;
    [SerializeField]
    private List<NavMeshDataInstance> _instances= new List<NavMeshDataInstance>();
    [SerializeField]
    private Transform _pivot;

    public void OnEnable()
    {
        RemoveAllNavMeshLoaderData();

        LoadNavmeshData();
    }

    public void RemoveAllNavMeshLoaderData()
    {
        NavMesh.RemoveAllNavMeshData();
    }
    public void LoadNavmeshData()
    {
        foreach (var chunk in _navMeshChunks)
        {
            if (chunk.Enabled)
            {
                _instances.Add(NavMesh.AddNavMeshData(chunk.Data, _pivot.transform.position,Quaternion.Euler(chunk.EulerRotation)));
            }
        }
    }

    public void OnDisable()
    {
        foreach(var instance in _instances)
        {
            instance.Remove();
        }
    }
}
