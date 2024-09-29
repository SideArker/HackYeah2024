using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public static Player instance;

    [SerializeField] private Transform spawnpoint;

    [SerializeField] float health = 4;
    
    public UnityEvent onPlrDeath;

    private PlayerMovement _playerMovement;

    [SerializeField] private TMP_Text hp;
    [SerializeField] GameObject heartPrefab;

    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject attackObject;

    private bool isAttacking = false;
    [SerializeField] private float attackDelay = 0.5f;
    [SerializeField] float hitStopDuration = .05f;
    [SerializeField] GameObject runParticle;

    [SerializeField] private float iframeDuration;

    Material PrevMat;
    bool iframes = false;
    SpriteRenderer spriteRenderer;
    Animator anim;

    Rigidbody2D rb;


    public bool grounded = false;
    
    // Rigidbody2D rb;

    Vector2 movement;
    private void Awake()
    {

        if(instance == null)
        instance = this;

        // rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        hp.text = health.ToString();
    }


    void iframeCooldown()
    {
        iframes = false;
        anim.SetBool("Iframe", false);
        PrevMat = null;
    }

    public void KillPlayer()
    {
        health = 0;
        onPlrDeath.Invoke();
    }
    public void DamagePlayer()
    {
        if (iframes) return;
        health--;
        // Destroy(hearts[0]);
        // hearts.RemoveAt(0);
        iframes = true;
        hp.text = health.ToString();
        anim.SetBool("Iframe", true);
        Invoke(nameof(iframeCooldown), iframeDuration);
        
        if(health <= 0)
        {
            if(!CableLemur.Instance.duringBattle)
            {
                onPlrDeath.Invoke();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                health = 5; 
                DamagePlayer();
                instance.gameObject.transform.position = spawnpoint.position;
                StopAllCoroutines();
            }
        }

        Debug.Log("Plr dmaged");
    }

    public void Attack()
    {
        if(isAttacking == false && _playerMovement.ControlsActive[5])
            StartCoroutine(AttackCoroutine());
    }


    IEnumerator AttackCoroutine()
    {
        anim.SetBool("Attacking", true);
        isAttacking = true;
        var temp = Instantiate(attackObject);
        temp.transform.position = attackPoint.position;
        yield return new WaitForSecondsRealtime(attackDelay);
        isAttacking = false;

        anim.SetBool("Attacking", false);
    }

    public void SetControl(int control, bool state)
    {
        _playerMovement.ControlsActive[control] = state;
        _playerMovement.XImages[control].SetActive(!state);
    }
    
    private void Update()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement.LastOnGroundTime == 0.1f) grounded = true;
        else grounded = false;


        if (playerMovement.IsJumping && !grounded) anim.SetBool("Jumping", true);
        else if (grounded) anim.SetBool("Jumping", false);

        if(!grounded) runParticle.gameObject.SetActive(false);
        else runParticle.gameObject.SetActive(true);

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
            anim.Play("Attack");
            anim.SetBool("Attacking", true);
        }

        // _playerMovement.ControlsImages[0].color =
        //     Input.GetKey(KeyCode.W) ? _playerMovement.usedColor : _playerMovement.normalColor;
        // _playerMovement.ControlsImages[1].color =
        //     Input.GetKey(KeyCode.S) ? _playerMovement.usedColor : _playerMovement.normalColor;
        // _playerMovement.ControlsImages[2].color =
        //     Input.GetKey(KeyCode.D) ? _playerMovement.usedColor : _playerMovement.normalColor;
        // _playerMovement.ControlsImages[3].color =
        //     Input.GetKey(KeyCode.A) ? _playerMovement.usedColor : _playerMovement.normalColor;
        // _playerMovement.ControlsImages[4].color =
        //     Input.GetMouseButton(1) ? _playerMovement.usedColor : _playerMovement.normalColor;
        // _playerMovement.ControlsImages[5].color =
        //     Input.GetMouseButton(0) ? _playerMovement.usedColor : _playerMovement.normalColor;
        // _playerMovement.ControlsImages[6].color =
        //     Input.GetKey(KeyCode.Space) ? _playerMovement.usedColor : _playerMovement.normalColor;
    }

}
