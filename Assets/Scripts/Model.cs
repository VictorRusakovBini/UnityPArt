using Events;
using NetworkingRealTime;
using NetworkingRealTime.BusinessLogic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public static Model Instance { get; private set; }

    [SerializeField] private EventController eventController;
    [SerializeField] private RealtimeController realtimeController;
    public EventController EventController => eventController;
    public RealtimeController RealtimeController => realtimeController;

    private void Awake()
    {
        Instance = this;
    }
        
        
}