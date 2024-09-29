using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    GameObject plr;

    private void Start()
    {

        plr = Player.instance.gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(plr.transform.position.x, plr.transform.position.y);
    }
}
