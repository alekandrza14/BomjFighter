using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemye : MonoBehaviour
{
    public Rigidbody2D body;
    public Player player;
    public SpriteRenderer spriteRenderer;
    public float hp = 100;
    public TMP_Text Hp;
    private void OnCollisionStay2D(Collision2D collision)
    {
        body.AddForceY(1, ForceMode2D.Impulse);
        if (collision.collider.GetComponent<Player>())
        {
            SceneManager.LoadScene(2);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<DamageObject>())
        {
            hp -= 1; Hp.text = "" + hp;
        }
        if (hp<=0)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<DeadTrigger>())
        {
            SceneManager.LoadScene(1);
        }
    }
    void Update()
    {
        bool vector = player.transform.position.x > transform.position.x;
        spriteRenderer.flipX = vector;
        body.velocity = new Vector2(((vector ? 1 : -1) * 0.2f)+ Input.GetAxisRaw("Horizontal") * -5, body.velocity.y);

    }
}
