using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCoverCircle : MonoBehaviour
{
    public LineRenderer circleRenderer;
    public int resolution = 100;  
    public float radius = 1f;
    Vector2 pos;
    [SerializeField] private EdgeCollider2D _collider;

    private readonly List<Vector2> _points = new List<Vector2>();
    void Start()
    {
        _collider.transform.position = transform.position;
        DrawCircle();
    }

    void DrawCircle()
    {
        circleRenderer.loop = true; 
        circleRenderer.positionCount = resolution;

        float angle = 0f;
        
        for (int i = 0; i < resolution; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            pos = new Vector2(x, y);
            circleRenderer.SetPosition(i, pos);

            angle += 2f * Mathf.PI / resolution;
            _points.Add(pos);

            _collider.points = _points.ToArray();
        }

        //_collider.edgeRadius = radius;
    }
}
