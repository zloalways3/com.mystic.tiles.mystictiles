using UnityEngine;

public class AxisAligner : MonoBehaviour
{
    // Публичные параметры сетки
    public int GridX { get; private set; }
    public int GridY { get; private set; }
    public string SquareTag { get; private set; }

    // Приватные переменные для расчета позиции
    private const float _squareSpacing = 0.23f;
    private const float _offsetX = 0.0733539388f;
    private const float _offsetY = 0.0605170019f;

    private void Start()
    {
        // Присваиваем тэг сразу при старте
        SquareTag = gameObject.tag;
    }

    /// <summary>
    /// Инициализация квадрата с координатами сетки.
    /// </summary>
    public void SetupTile(int x, int y)
    {
        GridX = x;
        GridY = y;
    }

    /// <summary>
    /// Перемещение квадрата на новую позицию на основе координат сетки.
    /// </summary>
    public void ShiftToCoordinates(int x, int y)
    {
        GridX = x;
        GridY = y;

        Vector3 newPosition = new Vector3(
            x * (_offsetX + _squareSpacing),
            y * (_offsetY + _squareSpacing),
            0);

        transform.position = newPosition;
    }

    /// <summary>
    /// Обработка клика по квадрату.
    /// </summary>
    private void OnMouseDown()
    {
        QuadraxPilot quadraxPilot = GetComponentInParent<QuadraxPilot>();
        if (quadraxPilot != null)
        {
            quadraxPilot.ProcessTileSelection(this);
        }
    }
}