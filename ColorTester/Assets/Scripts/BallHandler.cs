using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public SpriteRenderer sp;
    public Color Blue, Yellow, Pink, Purple;
    string ballColor;
    int score = 0;
    public GameDriver gd;
    public Text textRef;

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;
        chooseRandomColor();
    }

    void chooseRandomColor()
    {
        int r = Random.Range(0, 4);
        switch (r)
        {
            case 0:
                sp.color = Blue;
                ballColor = "Blue";
                break;
            case 1:
                sp.color = Yellow;
                ballColor = "Yellow";
                break;
            case 2:
                sp.color = Pink;
                ballColor = "Pink";
                break;
            case 3:
                sp.color = Purple;
                ballColor = "Purple";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = 1;
            push(force);
        }
    }

    void push(float frc)
    {
        rb.velocity = new Vector2(0, 1 * frc);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            chooseRandomColor();

            //instantiating a null(destroyed) object throws a null reference exception in my unity version so cannot destroy object
            //Destroy(collision.gameObject);

            collision.gameObject.SetActive(false);
            gd.spawner();
            return;
        }

        if (collision.tag == "Star")
        {
            score++;
            textRef.text = "Score = " + score.ToString();
            collision.gameObject.SetActive(false);
            return;
        }

        if (collision.tag == "Slider")
        {
            push(4);
            return;
        }

        if (ballColor != collision.tag)
        {
            SceneManager.LoadScene(0);
        }
    }
}
