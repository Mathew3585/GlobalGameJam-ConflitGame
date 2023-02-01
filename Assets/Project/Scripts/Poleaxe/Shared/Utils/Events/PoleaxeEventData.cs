using System;

namespace Poleaxe.Utils.Events
{
    internal struct PoleaxeEventData<key>
    {
        public key Key;
        public Delegate Delegate;
        public bool RemoveOnCall;
        public bool Freeze;
    }
}