using System;
namespace TestCode
{
    public enum State1{

        OffHook,
        Connecting,
        Connected,
        OnHold


    }

    public enum Trigger
    {

        CallDialed,
        HangUp,
        CallConnected,
        PlaceOnHold,
        TakeOffHold,
        LeftMessages

    }

    public enum State2
    {
        Unlocked,
        Failed,
        Locked
    }
}
