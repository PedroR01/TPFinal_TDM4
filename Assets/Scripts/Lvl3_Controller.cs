using UnityEngine;
using UnityEngine.UI;

public class Lvl3_Controller : MonoBehaviour
{
    [SerializeField] private Image sunFlower;
    [SerializeField] private Sprite[] sunFlowerFaces;
    [SerializeField] private GameObject[] items;
    private int index = 0;
    private bool confirm = false;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        if (!items[index].activeInHierarchy)
            items[index].SetActive(true);

        // Si no separaba en estos 2 grandes condicionales, habia un error en un bucle y hacia que el index se sume hasta irse por afuera del array
        if (items[index].transform.position.x < 1 && items[index].transform.position.x > -1)
            MoveItem();
        else
        {
            MoveItem();
            ConfirmItem();
            if (items[index].transform.position.x >= 1f && items[index].tag == "Compost" || items[index].transform.position.x <= -1f && items[index].tag == "Trash")
            {
                sunFlower.sprite = sunFlowerFaces[1];
                if (confirm)
                {
                    UIManager.Instance.SetScore(-1);
                    items[index].gameObject.SetActive(false);
                    index++;
                    confirm = false;
                }
            }
            else
            {
                sunFlower.sprite = sunFlowerFaces[0];
                if (confirm)
                {
                    UIManager.Instance.SetScore(1);
                    items[index].gameObject.SetActive(false);
                    index++;
                    confirm = false;
                }
            }
        }

        if (index > 8)
            GameManager.Instance.NextLevel();
    }

    private void MoveItem()
    {
        // Movimiento de acelerometro para un lado o para otro
        float move = Input.gyro.rotationRateUnbiased.y; // - para la izq | + para la der

        if (move >= 1.5f)
        {
            items[index].transform.position = new Vector3(1.1f, items[index].transform.position.y, items[index].transform.position.z);
        }
        else if (move <= -1.5f)
        {
            items[index].transform.position = new Vector3(-0.7f, items[index].transform.position.y, items[index].transform.position.z);
        }
    }

    private void ConfirmItem()
    {
        // Velocidad de giroscopio para confirmar
        float confirmation = -Input.gyro.rotationRateUnbiased.x; // para confirmar

        if (confirmation >= 7)
            confirm = true;
    }
}