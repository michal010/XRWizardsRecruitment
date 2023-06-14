using UnityEngine;

/// <summary>
/// This is Physics-based simple vehicle simulator,
/// all of the forces are calculated in Wheel class: suspension, acceleration and steering force aka "understeer/oversteer"
/// this system takes in count vehicle mass
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class BaseVehicle : MonoBehaviour
{
    [Header("Vehicle Settings")]
    [Tooltip("Power of the engine")]
    public float EnginePower;
    [Tooltip("Max speed at which vehicle may travel.")]
    public float VehicleTopSpeed;
    //Avaliable power at given vehicle speed, aka how much torque can be used
    [Tooltip("Avaliable power (torque) (y-axis) at given vehicle speed (x-axis)")]
    public AnimationCurve EnginePowerCurve;

    [Space(50)]
    public PlayerInput PlayerInput;


    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
