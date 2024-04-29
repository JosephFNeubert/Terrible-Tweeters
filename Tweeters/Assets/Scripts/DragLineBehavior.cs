using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLineBehavior : MonoBehaviour
{
    public LineRenderer _lr;
    public BirdBehavior _bird;

    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _bird = FindObjectOfType<BirdBehavior>();
        Vector3 lineZeroPosition = new Vector3(
            _bird.transform.position.x,
            _bird.transform.position.y,
            -0.1f);
        _lr.SetPosition(0, lineZeroPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(_bird.IsDragging)
        {
            _lr.enabled = true;
            _lr.SetPosition(1, _bird.transform.position);
        }
        else {
            _lr.enabled = false;
        }

    }
}
