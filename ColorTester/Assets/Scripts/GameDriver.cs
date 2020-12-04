using UnityEngine;

public class GameDriver : MonoBehaviour
{
    [SerializeField] GameObject[] circles;
    [SerializeField] GameObject cChanger;
    [SerializeField] Transform ballPos;
    [SerializeField] GameObject refSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawner()
    {
        int r = Random.Range(0, 5);

        GameObject circle = Instantiate(circles[r]);
        circle.SetActive(true);
        circle.transform.position = new Vector3(0, ballPos.position.y + 6, 0);

        GameObject changer = Instantiate(cChanger);
        changer.SetActive(true);
        changer.transform.position = new Vector3(0, ballPos.position.y + 12, 0);
        changer.GetComponent<Collider2D>().enabled = true;

        refSlider.transform.position = new Vector3(0, ballPos.position.y, 0);
        
    }
}
