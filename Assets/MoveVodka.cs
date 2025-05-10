using UnityEngine;

public class MoveVodka : MonoBehaviour
{
    public float vector1;
    public Enemye player1;
    public Player player2;
    private void Start()
    {
        player1 = FindAnyObjectByType<Enemye>();
        player2 = FindAnyObjectByType<Player>();
        bool vector = player1.transform.position.x > player2.transform.position.x;
        vector1 = (vector ? 1 : -1);
    }
    private void Update()
    {
        transform.position += new Vector3(vector1*Time.deltaTime*3,0,0);
        transform.Rotate(0,0,5);
    }
}
