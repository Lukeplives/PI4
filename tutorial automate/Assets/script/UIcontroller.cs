using UnityEngine;
using TMPro;

public class UIcontroller : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI numFerro;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    public void UpdtadenumFerro()
    {
        numFerro.text = gameManager.QtdFerro.ToString();
    }
}
