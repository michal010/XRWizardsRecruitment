using UnityEngine;

public class Forklift : BaseVehicle
{
    [Header("Forklift Settings")]
    public float MaxUpwardForkPosition = 3f;
    public float MaxDownwardForkPosition = 0f;
    public float ForkSpeed = 1f;
    public Transform Fork;

    private float targetPosition;


    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.MouseButtonZeroHold)
        {
            targetPosition = MaxUpwardForkPosition;
            MoveFork();
        }
        else if (PlayerInput.MouseButtonOneHold)
        {
            targetPosition = MaxDownwardForkPosition;
            MoveFork();
        }
    }

    private void MoveFork()
    {
        if (Mathf.Approximately(Fork.localPosition.y, targetPosition))
            return;

        float step = ForkSpeed * Time.deltaTime;
        Fork.localPosition = Vector3.MoveTowards(Fork.localPosition, new Vector3(Fork.localPosition.x, targetPosition, Fork.localPosition.z), step);
    }

}
