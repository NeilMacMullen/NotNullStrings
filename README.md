# NotNullStrings

This library conatains a small set of useful C# string extension methods aimed at making string manipulation and handling less painful.

Methods follow the null-object pattern; i.e. the library will return  *empty* strings or arrays rather than null. When null strings are supplied as arguments they will be treated as if empty. E.g. 

```CSharp
var blank = null.IsBlank() ;  // returns true 
```
