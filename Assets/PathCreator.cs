using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] List<GameObject> path = new List<GameObject>();

    
    void Start()
    {
        StartCoroutine(CoroutinePath());
    }

 

    IEnumerator CoroutinePath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            yield return new WaitForSeconds(0.5f);
            path[i].SetActive(true);
        }
       
    }
}
