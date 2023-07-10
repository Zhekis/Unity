using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Enemy _template;

    private Transform[] _points;

    private void Start()
    {
        var addEnemyJob = StartCoroutine(AddEnemy());
    }

    private IEnumerator AddEnemy()
    {
        _points = new Transform[_path.childCount];
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
            var spawnedEnemy = Instantiate(_template, _points[i].position, Quaternion.identity);

            yield return waitForTwoSeconds;
        }
    }
}
