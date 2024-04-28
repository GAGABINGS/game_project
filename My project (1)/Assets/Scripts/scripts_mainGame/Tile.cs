using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private GameObject _coin;
    // Start is called before the first frame update
    void Start()
    {
        int randomPoinIndex = Random.Range (0, _points.Count);
        GameObject newCoin = Instantiate(_coin, _points[randomPoinIndex].position, Quaternion.identity);
        newCoin.transform.SetParent(transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
    }
}
