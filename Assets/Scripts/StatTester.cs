using System;
using System.Collections;
using System.Collections.Generic;
using core.Networking.Generated;
using UnityEngine;
using UnityEngine.UI;

public class StatTester : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Start()
    {
        Model.Instance.RealtimeController.Initialize("192.168.0.103", 5577);
        Model.Instance.RealtimeController.Stat += SetText;
    }

    public void Connect()
    {
        #if UNITY_EDITOR
        Model.Instance.RealtimeController.JoinRoom("1", 1);
        #else
        Model.Instance.RealtimeController.JoinRoom("1", 2);
        #endif

    }

    public void Send1()
    {
        Model.Instance.RealtimeController.Send(new PckSendStat1(){Stat = "stat1"});
    }
    
    public void Send2()
    {
        Model.Instance.RealtimeController.Send(new PckSendStat2(){Stat = 100});

    }
    
    public void Send3()
    {
        Model.Instance.RealtimeController.Send(new PckSendStat3(){Stat = new SomeBigStat()
        {
            Stat1 = 12,
            Stat2 = 12.4f,
            Stat3 = "Stat3"
        }});

    }
    
    public void Send4()
    {
        Model.Instance.RealtimeController.Send(new PckSendStat4(){Stat1 = new SomeBigStat()
        {
            Stat1 = 123,
            Stat2 = 123.4f,
            Stat3 = "Stat4"
        },
            Stat2 = 123
        });
    }

    public void SetText(string txt)
    {
        text.text = txt;
    }
}
