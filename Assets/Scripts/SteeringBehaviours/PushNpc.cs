using UnityEngine;
using System.Collections;

public static class PushNpc
{

    public static Vector3 Push(float speed)
    {
    
       return (Vector3.forward * -speed);
    }
}

