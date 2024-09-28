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
                    break;
                case 3:
                    break;
            }

            canHit = true;

            yield return new WaitForSeconds(10);
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

    [Button]
    public void Test()
    {
        StartCoroutine(Attack1());
    }
}
