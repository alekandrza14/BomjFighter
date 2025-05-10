using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public Enemye player;
    public Player sec;
    public int playerteam = 1;
    public SpriteRenderer spriteRenderer;
    public GameObject vodka;
    public GameObject Udar;
    public GameObject deleteobj;
    int vodkaCount = 1;
    int udarCount = 250;
    public Sprite[] states;
    bool attackcooldown;
    bool dolbljum;
    int n = 6;
    Collision2D c;
    private void OnCollisionStay2D(Collision2D collision)
    {
        n = 6;
        c = collision;
        if ((int)Input.GetAxisRaw("Vertical") * 2 != 0&& playerteam == 1) body.AddForceY(1, ForceMode2D.Impulse);
        if ((int)Input.GetAxisRaw("Vertical2") * 2 != 0&& playerteam == 2) body.AddForceY(1, ForceMode2D.Impulse);
        dolbljum = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DeadTrigger>())
        {
            SceneManager.LoadScene(2);
        }
    }
    void Update()
    {
        if (player)
        {
            bool vector = player.transform.position.x > transform.position.x;
            spriteRenderer.flipX = !vector;
            body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (5 + (BubhnutVodku.boostspeed ? 1 : 0)), body.velocity.y);
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attackcooldown && udarCount > 0)
            {
                GameObject result = Instantiate(Udar, transform.position + new Vector3((vector ? 1 : -1), 0, 0), Quaternion.identity);
                result.GetComponent<SpriteRenderer>().flipX = !vector;
                deleteobj = result;
                StartCoroutine(stateAttack());
                attackcooldown = true;
                udarCount--;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && !attackcooldown && vodkaCount > 0)
            {
                Instantiate(vodka, transform.position + new Vector3((vector ? 1 : -1), 0, 0), Quaternion.identity);
                StartCoroutine(stateAttack());
                attackcooldown = true;
                vodkaCount--;
            }
        }
        else if (sec)
        {
            bool vector = sec.transform.position.x > transform.position.x;
            spriteRenderer.flipX = !vector;
            if (playerteam == 1) body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (5 + (BubhnutVodku.boostspeed ? 1 : 0)), body.velocity.y);
            if (playerteam == 2) body.velocity = new Vector2(Input.GetAxisRaw("Horizontal2") * (5 + (BubhnutVodku.boostspeed ? 1 : 0)), body.velocity.y);
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attackcooldown && udarCount > 0)
            {
                GameObject result = Instantiate(Udar, transform.position + new Vector3((vector ? 1 : -1), 0, 0), Quaternion.identity);
                result.GetComponent<SpriteRenderer>().flipX = !vector;
                deleteobj = result;
                StartCoroutine(stateAttack());
                attackcooldown = true;
                udarCount--;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && !attackcooldown && vodkaCount > 0)
            {
                Instantiate(vodka, transform.position + new Vector3((vector ? 1 : -1), 0, 0), Quaternion.identity);
                StartCoroutine(stateAttack());
                attackcooldown = true;
                vodkaCount--;
            }
        }
        if (c == null) 
        {   if (playerteam == 1) if (Input.GetKeyDown(KeyCode.W) && dolbljum)
            {
                body.AddForceY(15, ForceMode2D.Impulse);
                dolbljum = false;
            }
            if (playerteam == 2) if (Input.GetKeyDown(KeyCode.U) && dolbljum)
            {
                body.AddForceY(15, ForceMode2D.Impulse);
                dolbljum = false;
            } 
        }
        n--;
        if (n <= 0) 
        {
            c = null; 
        }
    }
    IEnumerator stateAttack()
    {
        
        spriteRenderer.sprite = states[1];
        yield return new WaitForSeconds(1);
        if (vodkaCount > 0) spriteRenderer.sprite = states[0];
        if (vodkaCount <= 0) spriteRenderer.sprite = states[2];
        if (deleteobj!=null)  Destroy(deleteobj);
        Destroy(deleteobj);
        attackcooldown = false;
    }
}
