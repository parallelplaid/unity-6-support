using UnityEngine;

internal class NullConditionalOperatorsTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("<color=yellow>Null-conditional Operators:</color>");

        int[] foo = null;
        Debug.Log("foo[10] = " + (foo?[10] ?? -1));

        string baz = "Test";
        Debug.Log("Baz length: " + (baz?.Length ?? 0));


		string qux = null;
		Debug.Log("Qux length: " + (qux?.Length ?? 0));

        Debug.Log("");
    }
}