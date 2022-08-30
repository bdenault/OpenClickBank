﻿using System.Runtime.Serialization;

namespace Ocelli.OpenClickBank.Builder.Data;

public enum TicketStatus
{
    [EnumMember(Value = "nil")] NIL,
    [EnumMember(Value = "OPEN")] OPEN,
    [EnumMember(Value = "REOPENED")] REOPENED,
    [EnumMember(Value = "CLOSED")] CLOSED
}