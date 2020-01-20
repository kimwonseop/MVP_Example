using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension {
    public static void LinkComponent<T>(this Transform transform, string node, ref T target) where T : Component {
        Transform trSource = transform.Find(node);
        if (trSource == null) {
            Debug.LogError("Not Found Child : LinkComponent, " + node + " at " + transform.name);
            return;
        }

        T inst = trSource.GetComponent<T>();
        if (inst == null) {
            Debug.LogError("Not Found Component : LinkComponent, " + node + " at " + transform.name);
            return;
        }

        target = inst;
    }

    public static void LinkGameObject(this Transform transform, string node, ref GameObject target) {
        Transform trSource = transform.Find(node);
        if (trSource == null) {
            Debug.LogError("Not Found Child : LinkGameObject, " + node + " at " + transform.name);
            return;
        }

        target = trSource.gameObject;
    }
}