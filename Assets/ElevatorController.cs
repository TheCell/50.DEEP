using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private GameObject firstPosition;
    [SerializeField] private GameObject secondPosition;
    [SerializeField] private float speed;

    private GameObject targetPostion;

    // Start is called before the first frame update
    void Start()
    {
        targetPostion = firstPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPostion.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetPostion = secondPosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targetPostion = firstPosition;
    }
}
