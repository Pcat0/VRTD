using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Custom", "My Custom Node")]
public class CustomNode : CodeFunctionNode {
    public CustomNode() {
        name = "Test shader Node";
    }
    protected override MethodInfo GetFunctionToConvert() {
        return GetType().GetMethod("MyCustomFunction",
            BindingFlags.Static | BindingFlags.NonPublic);
    }
    static string MyCustomFunction(
        [Slot(0, Binding.None)] DynamicDimensionVector A,
        [Slot(1, Binding.None)] DynamicDimensionVector B,
        [Slot(2, Binding.None)] out DynamicDimensionVector Out) {
        return @"{Out = A + B;}";
    }
}
