# Proef proeve groep 3

# Contributions

# Code conventions

### **General conventions**

Code lines are not allowed to exceed **120 characters** so that code wil always be readable on most screen sizes. 

------

### **Namespaces**

The namespace name is written in UpperCamelCase.
Every class needs to be inside of a namespace.
```cs
namespace ExampleNamespace
{
    public class ExampleScript : MonoBehaviour
    {

    }
}
```

------

### **Code seperation**

To seperate code between private, public and functions we a sperator. If there are no for example private's we dont use a seperator for it. 
```cs
//-------------------Private-------------------//
private int _exampleInt;

//-------------------Public-------------------//
public int ExampleInt
{
    get => _exampleInt;
    set => _exampleInt = value;
}

//-------------------Functions-------------------//
public void ExampleFunction
{

}
```

------

### **Classes**

The Class name is written in UpperCamelCase.
```cs
public class ExampleScript : MonoBehaviour
{

}
```

------

### **Functions**

The Function name is written in UpperCamelCase.
```cs
private void ExampleFunction()
{
    
}
```

**Public functions** require a summary including the parameters and returns.
```cs
/// <summary>
/// Function description.
/// </summary>
/// <param name="parameter">Parameter value to pass.</param>
/// <returns>What the function return.</returns>
public int ExampleFunction(string parameter)  
{
    Return 0;
}
```

When there is only 1 line of code inside of an function you can use a lambda expresion.
```cs
public void ExampleFunction() => SecondExampleFunction();
```

------

### **Variables**

**Private variable** names always start with an '_' (Even when serialized) after which it is written in lowerCamelCase.
```cs
private Object _variableExample;

[SerializeField]
private Object _secondVariableExample;
```

**Public variable** names are written in lowerCamelCase.
```cs
public Object variableExample;
```

**Constant variable** names are written in FULL_CAPITALS
```cs
public const VARIABLE_EXAMPLE
```

**Temporary variables** inside of an function always need to be in lowerCamelCase
```cs
private void ExampleFunction()
{
    float floatExample = 1f;
    int intExample = 1; 
}
```

**Temporary constants** inside of an function always need to be written out and are written in FULL_CAPITALS.
```cs
private void ExampleFunction()
{
    const float FLOAT_EXAMPLE = 1f;
    const int INT_EXAMPLE = 1; 
}
```

**Lists** are written the same as public or private variables and are always assigned in using '= new()'.
```cs
private List<GameObject> _exampleList = new();
```

**Propertie** names are written in UpperCamelCase and if they are 1 line use lambda expression.
if the **propertie** has a if statement it doesnt use lambda it uses a scope
```cs
public int ExampleInteger
{
    get => _exampleInterger;
    set =>  _exampleInterger = value;
}

public int ExampleInterger
{
    get => _exampleInterger;
    set{
        if(value < 0)
            _exampleInterger = 0;
    }
}
```

------

### **If statements**

When there is only 1 line of code after an if statement it needs to be tabbed under the if statement and does not need brackets and same with the else.
```cs
if(_exampleBoolean)
    ExampleFunction();
else
    SeccondExampleFunction();

if(!_exampleBoolean)
    ThirdExampleFunction();
```

If either the if or the else in the statement contains multiple lines of code both the if and the else need brackets.
```cs
if(_exampleBoolean)
{
    ExampleFunction();
}
else
{
    SeccondExampleFunction();
    ThirdExampleFunction();
}
```

------

### **For loops**

**For** loops are written using the same rules as if statements, When there is only 1 line inside of it it can be written without brackets.

```cs
for (int i = 0; i < _exampleList.Count; i++)
    ExampleFunction(_exampleList[i]);

for (int i = 0; i < _exampleList.Count; i++)
{
    ExampleFunction(_exampleList[i]);
    SecondExampleFunction(_exampleList[i]);
}
```

**For Each** are written using the same rules as for loops.

```cs
foreach(GameObject gameObject in ExampleList)
    ExampleFunction(gameObject);

foreach(GameObject gameObject in ExampleList)
{
    ExampleFunction(gameObject);
    SecondExampleFunction(gameObject);
}
```

------

### **Events**

The Unity event / Action name is written in UpperCamerCase and wil almost always start with 'On'.

```cs
public UnityEvent OnExampleEvent;

public Action OnSecondExampleEvent; 
```

------

### **Structs**

The struct name is written in UpperCamelCase and everything inside the struct follows the usual code conventions.
```cs
public struct ExampleStruct
{
    public double x;
    public double y;
}
```

------

### **Enums**

The enum name is written in UpperCamelCase while the constants are in FULL_CAPITALS.
```cs
enum ExampleEnum
{
    FIRST_CONSTANT,
    SECOND_CONSTANT
}
```