using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TileEffectData
{
    public TileBase tile;
    public AudioSource soundEffect;
    public Color color1;
    public Color color2;
}


public class TileWalkEffect : MonoBehaviour
{

    [SerializeField] Tilemap map;
    [SerializeField] float tickTime = .5f;
    [SerializeField] GameObject runParticle;

    [SerializeField] GameObject checkPoint;

    public List<TileEffectData> tiles = new List<TileEffectData>(0);



    void Start()
    {
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true) {




            Vector3Int gridPos = map.WorldToCell(checkPoint.transform.position);
            TileBase tile = map.GetTile(gridPos);

            if (tile)
            {
                Debug.Log("Walking on tile: " + tile.name);

                TileEffectData currentTile = tiles.Find(x => x.tile == tile);

                if(currentTile != null)
                {
                    ParticleSystem particleSystem = runParticle.GetComponent<ParticleSystem>();

                    ParticleSystem.MainModule runPSettings = particleSystem.main;
                    runPSettings.startColor = new ParticleSystem.MinMaxGradient(currentTile.color1, currentTile.color2);
                }

            }





            yield return new WaitForSeconds(tickTime);
        }
    }
}
