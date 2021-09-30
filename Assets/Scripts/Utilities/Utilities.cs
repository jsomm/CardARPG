using UnityEngine;
using UnityEngine.InputSystem;

public static class Utilities
{
    static readonly Camera _cam = Camera.main;

    public static Vector3 GetMousePosition() => _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

    public static Ray CameraRaycast() => _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
}