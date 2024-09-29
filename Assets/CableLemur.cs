using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CableLemur : MonoBehaviour
{
    public static CableLemur Instance;
    
    [SerializeField] int Health;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform wallSpawn;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform waveSpawnLeft;
    [SerializeField] private Transform waveSpawnRight;
    [SerializeField] private GameObject wavePrefab;
    private Animator _animator;
    private bool canHit = true;
    public bool duringBattle = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        _playerMovement = PlayerMovement.Instance;
        _animator = GetComponent<Animator>();

        GlobalSound.StopAllMusic();
        GlobalSound.PlayMusic("FinalBossMusic");
        
        StartBattle();
    }

    [Button]
    public void StartBattle()
    {
        print("BIc sie");
        duringBattle = true;
        StartCoroutine(battle());
    }

    IEnumerator battle()
    {
        print(1);
        yield return new WaitForSeconds(3);
        while (true)
        {
            int attack = Random.Range(1, 4);
            
            print(attack);

            // canHit = false;
            _animator.SetBool("scream", false);

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
            
            _animator.SetBool("scream", true);
            // canHit = true;

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
                SceneManager.LoadScene(6);
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
        
        // _animator.Play("Attack1");
        _animator.SetBool("attack1", true);

        
        yield return new WaitForSeconds(8);
        
        _animator.SetBool("attack1", false);

        Player.instance.SetControl(6, true);
        Player.instance.SetControl(2, true);

        
    }
    IEnumerator Attack2()
    {
        Player.instance.SetControl(1, false);
        Player.instance.SetControl(2, false);
        // Player.instance.SetControl(3, false);

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
        // Player.instance.SetControl(3, true);

        
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
