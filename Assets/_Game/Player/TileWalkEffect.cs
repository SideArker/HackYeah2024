using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TileEffectData
{
    public TileBase tile;
    public AudioSource soundEffect;
}


public class TileWalkEffect : MonoBehaviour
{

    [SerializeField] Tilemap map;
    [SerializeField] float tickTime = .5f;

    public List<TileEffectData> tiles = new List<TileEffectData>(0);



    void Start()
    {
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true) {

            Vector3Int gridPos = map.WorldToCell(transform.position);
            TileBase tile = map.GetTile(gridPos);

            if (tile)
            {
                Debug.Log("Walking on tile: " + tile.name);
            }

            yield return new WaitForSeconds(tickTime);
        }
    }
}
