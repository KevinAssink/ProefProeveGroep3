<h1> Naam Spel </h1>
Top Down 3D endless runner waar je coins en op pakt terwijl je voorwaarst blijft bewegen op “lanes”. Lanes zijn bepaalde lijnen waar de speler voorwaarts op beweegt en tussen kan bewegen, op deze lanes spawnen ook de obstakels. De coins doen we om de aandacht bij het spel te houden en meteen dopamine af te leveren aan te speler. Ondertussen komen er obstacle's op je af om een uitdaging te creëren voor de speler. Als je geraakt wordt door een obstakel ben je af en krijg je een score. Deze score komt op een (leaderboard) en die kan je delen met je vrienden. De coins die in het spel verdient kan je in een shop uitgeven voor rewards die de speler graag wil, of in het Game Over Scherm een extra leven kopen. 

<h2>Rollen</h2>

* **Lead Developer:** Olli Appelt 
* **Lead Artist:** Ryan van Ingen 
* **Product Owner:** Ihsan Topcuoglu 
* **SCRUM Master:** Thom Koper 

<h2>Conventies</h2>

* **Unity Versie:** 2022.3.19f 

* **Commits:** Duidelijke korte benaming. Beschrijving in detail; Changed, Added, Removed, Fixed. Mechanic duidelijk uitgelegd in initial commit. 

* **Branches:** Elke mechanic nieuwe; mechanic/swiping. Mechanic duidelijke naamgeving, uitleg over mechanic wordt aangegeven in OnePage of Commits op GitHub. Develop: MET TOESTEMMING LEADDEVELOPER. Pull Request aanmaken en bespreken. Implementeren en testen met andere mechanics. Master: Einde van de sprint wordt hierin alles gepushed, zonder Errors and Bugs. 

* **Pull Requests:** Voor mergen van features pull request aanmaken en laten controleren van de LeadDeveloper. Bij goedkeuring Naam en beschrijving duidelijk en dan mergen. Na het mergen direct nieuwe feature/mechanics implementeren in Develop. Bij afkeur moet de pull request nog eens worden gecontroleerd op: Naam, Beschrijving, Errors, Merge Conflicts, etc. 
* **README:** Zodra een nieuwe feature/mechanic is geimplenteerd DIRECT OnePage en code toevoegen aan ReadMe in Github in hierarchy;  

* **SceneManagement:** Master: Eind Scene met alle mechanics af en getest, Develop: Voor implementeren van features en mechanics met elkaar. Testen wordt ook in deze scene gedaan, Duidelijke naam voor scene van elke nieuwe mechanic. In deze scene wordt de mechanic gemaakt.

* **Hierarchy**
    <ul>
      <li>Assets -> Scripts -> MechanicScripts -> Swiping -> Swipe.script</li>
      <li>Assets -> Models -> EnvironmentModels -> Props -> Rocks -> Rock01.Model</li>
    </ul>

<h2> Documentatie & Links </h2>
<h3><ul>
  <li>Planning</li>
    <ul>
      <li><a href="https://trello.com/invite/b/pN6tEbCG/ATTI890300962e007b2909ba038b068e63d4C0BD6994/product-backlog" target="_blank">Trello</a></li>
	  <li><a href="/Documentatie/Notule Sprint Planning 1.pdf">Notule Sprint 01</a></li>
    </ul>
  <li>Documenten</li>
    <ul>
      <li><a href="/Documentatie/Debriefing.pdf">Debriefing / KickOff</a></li>
      <li><a href="/Documentatie/Game Concept.pdf">Game Concept</a></li>
      <li><a href="/Documentatie/Game Scope.pdf">Game Scope</a></li>
    </ul>
  <li>Conventies</li>
    <ul>
      <li><a href="/Documentatie/Pipeline.pdf">Pipeline</a></li>
      <li><a href="/Documentatie/Style guide.pdf">Style Guide</a></li>
    </ul>
</ul></h3>

<h2> Werk Van Studenten </h2>
<h3><ul>
  <li>Developers</li>
    <ul>
      <li><a href="/Documentatie/Studenten/Olli Appelt/">Olli Appelt</a></li>
      <li><a href="/Documentatie/Studenten/Kevin Assink/">Kevin Assink</a></li>
      <li><a href="/Documentatie/Studenten/Thom Koper/">Thom Koper</a></li>
    </ul>
  <li>Artists
    <ul>
      <li><a href="/Documentatie/Studenten/Ruben Ros/">Ruben Ros</a></li>
      <li><a href="/Documentatie/Studenten/Ihsan Topcuoglu/">Ihsan Topcuoglu</a></li>
      <li><a href="/Documentatie/Studenten/Ryan van Ingen/">Ryan van Ingen</a></li>
      <li><a href="/Documentatie/Studenten/Abdul Rocha/">Abdul Rocha</a></li>
    </ul>
</ul></h3>

<h2>Code Conventies</h2>

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
