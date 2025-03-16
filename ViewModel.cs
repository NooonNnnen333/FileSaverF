using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;
using System.Windows.Input;
using AngleSharp;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.Input;

namespace lab3;

public enum ShapeType
{
    Point = 1,
    Line = 2,
    Rectangle = 3,
    Ellipse = 4
}

public class Shape
{
    public ShapeType Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}

public class Graphics : GraphicsView, IDrawable
{
    public List<Shape> ShapesE { get; } = new();

    public Graphics()
    {
        Drawable = this;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;

        foreach (var shape in ShapesE)
        {
            switch (shape.Type)
            {
                case ShapeType.Point:
                    canvas.FillCircle(shape.X, shape.X, 5);
                    break;
                case ShapeType.Line:
                    canvas.DrawLine(shape.X, shape.Y, shape.X + 50, shape.Y + 50);
                    break;
                case ShapeType.Rectangle:
                    canvas.DrawRectangle(shape.X, shape.Y, 100, 60);
                    break;
                case ShapeType.Ellipse:
                    canvas.DrawEllipse(shape.X, shape.Y, 100, 60);
                    break;
            }
        }
    }

    // Храним фигуры
    public List<Shape> Shapes { get; } = new();

    // Метод добавления фигуры и перерисовка
    public void AddShape(ShapeType type, int x, int y)
    {
        ShapesE.Add(new Shape { Type = type, X = x, Y = y });
        Invalidate();
    }
}

//================================================================================================================================================================    



public partial class ViewModel : ObservableObject
{
    private readonly Graphics _graphics;

    [ObservableProperty] private int x;
    [ObservableProperty] private int y;

    public ViewModel(Graphics graphics)
    {
        _graphics = graphics;
        X = 0;
        Y = 0;
    }

    [RelayCommand]
    public void CreateTochka()
    {
        _graphics.AddShape(ShapeType.Point, X, Y);
    }

    [RelayCommand]
    public void CreateLiniya()
    {
        _graphics.AddShape(ShapeType.Line, X, Y);
    }

    [RelayCommand]
    public void CreateKvadrat()
    {
        _graphics.AddShape(ShapeType.Rectangle, X, Y);
    }

    [RelayCommand]
    public void CreateEllips()
    {
        _graphics.AddShape(ShapeType.Ellipse, X, Y);
    }
}