using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private Transform _path;

    public GameObject Template;
    private Transform[] _points;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for(int i = 0; i < _path.childCount; i++) 
        {
            _points[i] = _path.GetChild(i);
            GameObject newObject = Instantiate(Template, new Vector3(0,0,0), Quaternion.identity);
            Transform newObjectTransform = newObject.GetComponent<Transform>();
            newObjectTransform.position = _points[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
