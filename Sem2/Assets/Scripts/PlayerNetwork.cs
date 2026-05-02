using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode.Components;
using Unity.Cinemachine;

[DisallowMultipleComponent]
public class PlayerNetwork : NetworkTransform
{

    protected override bool OnIsServerAuthoritative()
    { return false;
    }
}