using UnityEngine;

public static class ComponentExtensitons
{
    public static void Pause(this Component component)
    {
        foreach (var t in component.GetComponentsInChildren<Rigidbody2D>())
        {
            t.bodyType = RigidbodyType2D.Static;
        }
    }

    public static void Resume(this Component component, RigidbodyType2D type2D = RigidbodyType2D.Dynamic)
    {
        foreach (var t in component.GetComponentsInChildren<Rigidbody2D>())
        {
            t.bodyType = type2D;
        }
    }

    public static void Bomb(this Component component)
    {
        var joints = component.GetComponentsInChildren<HingeJoint2D>();

        foreach (var j in joints)
        {
            j.enabled = false;
            j.connectedBody = null;
            j.autoConfigureConnectedAnchor = false;
        }

        var rbs = component.GetComponentsInChildren<Rigidbody2D>();
        foreach (var r in rbs)
        {
            var x = UnityEngine.Random.Range(0.0f, Mathf.PI * 2);

            var sin = Mathf.Sin(x);
            var cos = Mathf.Cos(x);

            var speed = 20f;
            var force = new Vector2(sin, cos) * speed;

            r.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
