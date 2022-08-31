using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeCreator : MonoBehaviour
{
    [SerializeField] private string _objectName;
    [SerializeField] private Color _color;
    [SerializeField] private Vector3 _size;
    private Shape _shape;
    [SerializeField] private Shapes _shapes;
    enum Shapes
    {
        Square, Circle
    }
    
    private void Awake()
    {
        var scalable = new Scalable();
        var colorable = new Colorable();
        ShapeSelection(colorable, scalable, _shapes);
    }

    private void ShapeSelection(Colorable colorable, Scalable scalable, Shapes shapes)
    {
        _shape = shapes switch
        {
            Shapes.Square => new Square(colorable, scalable, _objectName),
            Shapes.Circle => new Circle(colorable, scalable, _objectName),
            _ => throw new ArgumentOutOfRangeException(nameof(shapes), shapes, null)
        };
    }

    private void Start()
    {
        _shape.DrawShape(_color, _size);
    }
}

public interface IColorable
{
    public void PaintColor(Color color, Material material);
}

class Colorable : IColorable
{
    public void PaintColor(Color color, Material material)
    {
        material.color = color;
    }
}

public interface IScalable
{
    public void ChangeSize(Vector3 vector3, Transform transform);
}

class Scalable : IScalable
{
    public void ChangeSize(Vector3 vector3, Transform transform)
    {
        transform.localScale = vector3;
    }
}

[Serializable]
public abstract class Shape
{
    protected IColorable _colorable;
    protected IScalable _scalable;

    protected Shape(IColorable colorable, IScalable scalable)
    {
        _colorable = colorable;
        _scalable = scalable;
    }

    public abstract GameObject DrawShape(Color color, Vector3 vector3);
}

public class Square : Shape
{
    private readonly string _name;
    private float _sizeFactor;

    public Square(IColorable colorable, IScalable scalable, string name) : base(colorable, scalable)
    {
        _name = name;
    }

    public override GameObject DrawShape(Color color, Vector3 vector3)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    
        _colorable.PaintColor(color,  cube.GetComponent<Renderer>().material);
        _scalable.ChangeSize(vector3, cube.transform);
        return cube;
    }
}

public class Circle : Shape
{
    private readonly string _name;
    private float _sizeFactor;

    public Circle(IColorable colorable, IScalable scalable, string name) : base(colorable, scalable)
    {
        _name = name;
    }

    public override GameObject DrawShape(Color color, Vector3 vector3)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    
        _colorable.PaintColor(color,  cube.GetComponent<Renderer>().material);
        _scalable.ChangeSize(vector3, cube.transform);
        return cube;
    }
}