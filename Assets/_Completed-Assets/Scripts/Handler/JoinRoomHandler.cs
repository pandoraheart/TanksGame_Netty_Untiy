﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JoinRoomHandler : BaseHandler
{

    public event MessageEventHandler JoinRoomEvent;

    public override void Awake()
    {
        actionCode = ActionCode.MsgJoinRoom;
        base.Awake();
    }

    public void JoinRoom(string roomId)
    {
        ProtocalData data = new ProtocalData(actionCode, new RoomData() { Id = roomId });
        Send(data);
    }

    public override void OnResponse(ProtocalData msg)
    {
        base.OnResponse(msg);
        if (JoinRoomEvent != null)
            JoinRoomEvent(this, msg);
    }
}