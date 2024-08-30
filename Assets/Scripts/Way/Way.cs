using UnityEngine;

public class Way : MonoBehaviour
{
    [SerializeField] private CheckPoint[] _checkPoints;

    public CheckPoint GetNextCheckPoint(CheckPoint currentCheckPoint)
    {
        int numberOfCheckPoint = GetNumberOfCheckPoint(currentCheckPoint);
        numberOfCheckPoint = (numberOfCheckPoint + 1) % _checkPoints.Length;
        return _checkPoints[numberOfCheckPoint];
    }

    private int GetNumberOfCheckPoint(CheckPoint checkPoint)
    {
        int number = -1;

        for (int i = 0; i < _checkPoints.Length; i++)
        {
            if (checkPoint == _checkPoints[i])
            {
                number = i;
            }
        }

        return number;
    }
}