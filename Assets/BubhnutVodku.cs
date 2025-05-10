using UnityEngine;

public class BubhnutVodku : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] animation;
    public int animationIndex = 0;
    static public bool boostspeed;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Player>()&&animationIndex==0)
        {
            boostspeed = true;
            animationIndex = 1;
        }
    }
    private void Update()
    {
        sr.sprite = animation[animationIndex];
        
    }
}
