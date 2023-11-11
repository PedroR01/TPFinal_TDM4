using UnityEngine;
using UnityEngine.UI;

public class Lvl3_Controller : MonoBehaviour
{
    [SerializeField] private Image sunFlower;
    [SerializeField] private Sprite[] sunFlowerFaces;
    [SerializeField] private float gyroMovItemsRange = 0.3f;
    [SerializeField] private GameObject[] items;
    private int index = 0;
    private float lastConfirmationTime;

    private void Start()
    {
        Input.gyro.enabled = true;
        lastConfirmationTime = Time.deltaTime;
    }

    private void Update()
    {
        if (index == 9)
            GameManager.Instance.NextLevel();
        else
        {
            MoveItem();
            ConfirmItem();

            if (index != 9 && !items[index].activeInHierarchy)
                items[index].SetActive(true);

            UIManager.Instance.Updating();
        }
    }

    private void MoveItem()
    {
        // Movimiento de acelerómetro para un lado u otro
        float move = Input.acceleration.x; // - para la izquierda | + para la derecha
        float offsetX = items[index].transform.position.x;

        if (move >= gyroMovItemsRange)
            offsetX = 1.3f;
        else if (move <= -gyroMovItemsRange)
            offsetX = -0.5f;

        items[index].transform.position = new Vector3(offsetX, items[index].transform.position.y, items[index].transform.position.z);
    }

    private void ConfirmItem()
    {
        float gyroConfirmation = Input.gyro.rotationRateUnbiased.x; // para confirmar
        bool correctPlace = false;

        if ((items[index].transform.position.x > 1f && items[index].tag == "Compost") ||
                   (items[index].transform.position.x < 1f && items[index].tag == "Trash"))
        {
            sunFlower.sprite = sunFlowerFaces[1];
            correctPlace = false;
        }
        else if (items[index].transform.position.x < 1f && items[index].tag == "Compost" || (items[index].transform.position.x > 1f && items[index].tag == "Trash"))
        {
            sunFlower.sprite = sunFlowerFaces[0];
            correctPlace = true;
        }

        if (gyroConfirmation < -3 && Time.deltaTime - lastConfirmationTime >= .5f || gyroConfirmation > 3 && Time.deltaTime - lastConfirmationTime >= .5f)
        {
            if (!correctPlace)
                UIManager.Instance.SetScore(-1);
            else
                UIManager.Instance.SetScore(1);

            items[index].SetActive(false);
            index++;
            lastConfirmationTime = Time.deltaTime; // Actualizar el tiempo de la última confirmación
        }
        Debug.Log("SCORE: " + UIManager.Instance.GetScore());
        Debug.Log("GYRO: " + gyroConfirmation);
    }
}