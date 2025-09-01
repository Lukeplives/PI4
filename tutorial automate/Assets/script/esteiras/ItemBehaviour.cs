using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemBehaviour : MonoBehaviour
{
    /**
     * <summary>
     * Speed
     * </summary>
     */
    private float _speed = 1;

    public float speed
    {
        set
        {
            this._speed = value;
        }

        get
        {
            return this._speed;
        }
    }



    public UnityEvent itemColect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Extractor"))
        {
            itemColect.Invoke();
            
            Destroy(gameObject);
        }
    }

        public void TestMethod()
    {
        print("Item extraído");

    }

    private Bounds _bounds;



    // Start is called before the first frame update
    private void Start()
    {
        itemColect.AddListener(GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().UpFerro);
        itemColect.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIcontroller>().UpdtadenumFerro);

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {

    }





    public void MoveLeft()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x - this.speed * Time.deltaTime,
            this.transform.position.y,
            this.transform.position.z
        );

        this.transform.position = nextPosition;
    }

    /**
     * <summary>
     * Move right
     * </summary>
     *
     * <returns>
     * void
     * </returns>
     */
    public void MoveRight()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x + this.speed * Time.deltaTime,
            this.transform.position.y,
            this.transform.position.z
        );

        this.transform.position = nextPosition;
    }

    /**
     * <summary>
     * Move down
     * </summary>
     *
     * <returns>
     * void
     * </returns>
     */
    public void MoveDown()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y - this.speed * Time.deltaTime,
            this.transform.position.z
        );

        this.transform.position = nextPosition;
    }

    /**
     * <summary>
     * Move up
     * </summary>
     *
     * <returns>
     * void
     * </returns>
     */
    public void MoveUp()
    {
        Vector3 nextPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y + this.speed * Time.deltaTime,
            this.transform.position.z
        );

        this.transform.position = nextPosition;
    }




}
