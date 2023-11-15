using UnityEngine;
using UnityEngine.UI;

public class Lvl3_Controller : MonoBehaviour
{
    [SerializeField] private Image sunFlower;
    [SerializeField] private Sprite[] sunFlowerFaces;
    [SerializeField] private GameObject[] items;
    private int index = 0;
    private bool confirm = false;
    private float lastConfirmationTime;

    private void Start()
    {
        Input.gyro.enabled = true;
        lastConfirmationTime = Time.time;
    }

    private void Update()
    {
        if (index == 9)
            GameManager.Instance.NextLevel();
        else
        {
            MoveItem();
            ConfirmItem();

            if (index != 9 && !items[index].activeInHierarchy) items[index].SetActive(true);

            UIManager.Instance.Updating();
            confirm = false;
        }
    }

    private void MoveItem()
    {
        // Movimiento de acelerómetro para un lado u otro
        float move = Input.acceleration.x; // - para la izquierda | + para la derecha

        if (move >= 0.1f)
        {
            items[index].transform.position = new Vector3(1.3f, items[index].transform.position.y, items[index].transform.position.z);
        }
        else
        {
            items[index].transform.position = new Vector3(-0.5f, items[index].transform.position.y, items[index].transform.position.z);
        }

        if ((items[index].transform.position.x > 1f && items[index].tag == "Compost") || (items[index].transform.position.x < 1f && items[index].tag == "Trash"))
            sunFlower.sprite = sunFlowerFaces[1];
        else
            sunFlower.sprite = sunFlowerFaces[0];
    }

    private void ConfirmItem()
    {
        float confirmation = Input.gyro.rotationRateUnbiased.x; // para confirmar

        if (confirmation > 7 && Time.time - lastConfirmationTime >= 1f)
        {
            if ((items[index].transform.position.x > 1f && items[index].tag == "Compost") ||
                    (items[index].transform.position.x < 1f && items[index].tag == "Trash"))
            {
                if (UIManager.Instance.GetScore() > 0)
                    UIManager.Instance.SetScore(-1);
            }
            else if (items[index].transform.position.x < 1f && items[index].tag == "Compost")
            {
                UIManager.Instance.SetScore(1);
            }

            items[index].SetActive(false);
            index++;
            lastConfirmationTime = Time.time; // Actualizar el tiempo de la última confirmación
        }
    }
}