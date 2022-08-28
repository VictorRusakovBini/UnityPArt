using System;
using System.Collections.Generic;
using System.Linq;
using Events.Base;
using UnityEngine;

namespace Events
{
    public class EventController: MonoBehaviour
    {
        public static EventController Instance { get; private set; }
        
        private readonly List<BaseUnit> _units = new List<BaseUnit>();
        private readonly List<BaseEvent> _events = new List<BaseEvent>();
        
        private void Awake()
        {
            var unitTypes = typeof(BaseUnit).Assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(BaseUnit)) && !type.IsAbstract)
                .ToList();

            foreach (var type in unitTypes)
            {
                _units.Add((BaseUnit)Activator.CreateInstance(type));
            }
        }

        public void Start()
        {
            Instance = this;
        }

        public void HandleEvent(BaseEvent e)
        {
            lock (_events)
            {
                _events.Add(e);
                Debug.LogWarning($"Add event {e.GetType().Name}");
            }
        }

        private void Update()
        {
            lock (_events)
            {
                if (_events.Count == 0)
                    return;
                
                var events = _events.ToArray();
                _events.Clear();
                foreach (var e in events)
                {
                    foreach (var unit in _units)
                    {
                        unit.OnEvent(e);
                    }
                }
            }
        }
    }
}