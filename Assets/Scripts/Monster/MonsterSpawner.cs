using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Monster> monsters;
    [SerializeField]
    private Bounds spawnBounds;
    [SerializeField]
    private Bounds safezoneBounds;
    private void Start()
    {
        foreach (var item in monsters)
        {
            if (item != null)
                SpawnMonsterOnRandomPoint(item);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + spawnBounds.center, spawnBounds.size);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + safezoneBounds.center, safezoneBounds.size);
    }

    private void SpawnMonsterOnRandomPoint(Monster m)
    {
        List<Vector2> v2 = new List<Vector2>();
        Vector2 a, b, rez;

        a = spawnBounds.min;
        b = safezoneBounds.max;
        b.y = safezoneBounds.min.y;
        if (GenerateRandomVector2(a, b, out rez))
            v2.Add(rez);

        a = safezoneBounds.max;
        a.y = spawnBounds.min.y;
        b = spawnBounds.max;
        if (GenerateRandomVector2(a, b, out rez))
            v2.Add(rez);

        a = safezoneBounds.min;
        a.x = spawnBounds.min.x;
        b.x = safezoneBounds.min.x;
        b.y = spawnBounds.max.y;
        if (GenerateRandomVector2(a, b, out rez))
            v2.Add(rez);

        a.x = safezoneBounds.min.x;
        a.y = safezoneBounds.max.y;
        b.x = safezoneBounds.max.x;
        b.y = spawnBounds.max.y;
        if (GenerateRandomVector2(a, b, out rez))
            v2.Add(rez);

        if (v2.Count == 0)
            return;

        Vector3 p = v2[Random.Range(0, v2.Count)];
        p.z = m.transform.position.z;
        m.transform.position = p;
        m.gameObject.SetActive(true);
    }

    private static bool GenerateRandomVector2(Vector2 a, Vector2 b, out Vector2 rez)
    {
        rez = Vector2.zero;
        if (a.x > b.x)
            return false;
        if (a.y > b.y)
            return false;
        rez = new Vector2(Random.Range(a.x, b.x), Random.Range(a.y, b.y));
        return true;
    }
}
