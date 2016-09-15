using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] typePrefabs;

    private GameObject selectedPrefab;

    // Use this for initialization
    void Start()
    {
        SetSelectedType(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(selectedPrefab, mousePos, Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float range = 10f;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, range);
            foreach (var col in colliders)
            {
                Rigidbody2D rigidbody = col.attachedRigidbody;
                if (rigidbody != null)
                {
                    Vector2 direction = (rigidbody.position - mousePos);
                    float distance = range - direction.magnitude;
                    float force = distance * 20.0f;
                    rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
                }
            }
        }
    }

    public void SetSelectedType(int value)
    {
        selectedPrefab = typePrefabs[value];
    }
}
