using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class CableLemur : MonoBehaviour
{
    
    [SerializeField] int Health;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform wallSpawn;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform waveSpawnLeft;
    [SerializeField] private Transform waveSpawnRight;
    [SerializeField] private GameObject wavePrefab;
    private Animator _animator;
    private bool canHit = true;
    
    private void Start()
    {
        _playerMovement = PlayerMovement.Instance;
        _animator = GetComponent<Animator>();
    }

    [Button]
    public void StartBattle()
    {
        StartCoroutine(battle());
    }

    IEnumerator battle()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            int attack = Random.Range(1, 4);
            
            print(attack);

            canHit = false;
            switch (attack)
            {
                case 1:
                    yield return Attack1();
                    break;
                case 2:
                    yield return Attack2();
                    break;
                case 3:
                    yield return Attack3();
                    break;
            }

            canHit = true;

            yield return new WaitForSeconds(5);
        }
    }

    public void Damage()
    {
        print("I try to damage this guy");
        if (canHit)
        {
            print("Damage Enemy");
            Health--;

            if (Health <= 0)
            {
                Debug.Log("Enemy dies now");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.gameObject.transform.GetComponent<Player>())
        {
            Player.instance.DamagePlayer();
        }
    }

    IEnumerator Attack1()
    {
        Player.instance.SetControl(6, false);
        Player.instance.SetControl(2, false);

        yield return new WaitForSeconds(3);
        
        _animator.Play("Attack1");
        
        yield return new WaitForSeconds(8);
        
        Player.instance.SetControl(6, true);
        Player.instance.SetControl(2, true);

        
    }
    IEnumerator Attack2()
    {
        Player.instance.SetControl(1, false);
        Player.instance.SetControl(2, false);
        Player.instance.SetControl(3, false);

        yield return new WaitForSeconds(3);
        print("after 3 s");
        
        
        for (int i = 0; i < 5; i++)
        {
            // print("in for");
            var wall = Instantiate(wallPrefab, wallSpawn);
            wall.transform.position += new Vector3(0,Random.Range(-3f,3f),0); 
            wall.transform.localScale = new Vector3((float)1/3,(float)1/3,1);
            // print("after inst");

            yield return new WaitForSeconds(3);
            // print("after inst");

        }

        

        
        
        Player.instance.SetControl(1, true);
        Player.instance.SetControl(2, true);
        Player.instance.SetControl(3, true);

        
    }
    IEnumerator Attack3()
    {
        Player.instance.SetControl(4, false);

        yield return new WaitForSeconds(3);
        
        for (int i = 0; i < 5; i++)
        {
            // print("in for");
            var wave = Instantiate(wavePrefab, waveSpawnRight);
            wave = Instantiate(wavePrefab, waveSpawnLeft);
            wave.gameObject.transform.GetComponent<wave>().direction = -1;
            // print("after inst");

            yield return new WaitForSeconds(2);
            // print("after inst");

        }
        
        Player.instance.SetControl(4, true);

        
    }

    [Button]
    public void Test()
    {
        StartCoroutine(Attack3());
    }
}
