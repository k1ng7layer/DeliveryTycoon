using System;
using UnityEngine;

namespace Game.Services.Input
{
    public interface IGameInputService
    {
        event Action<bool> CameraMovementUnlockButton;
        Vector3 InputVector { get; }
        void Enable();
        void Disable();
    }
}