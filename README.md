# SelfDeleteEx
Универсальное само удаление программы

В данном проекте работают два метода:\
Первый метод удаляет файл через командную строку по определённому времени ( 0 - это мгновенное )
```csharp
SelfEx.CmdInit($"/C choice /C Y /N /D Y /T 0 &Del {GlobalPaths.AssemblyPath}", "cmd.exe");
```
Второй метод удаляет файл через батник, `.bat` файл спрятан в `%AppData%` от лишних глаз.
```csharp
SelfEx.BatInit(SelfHelper, AssemblyPath);
```
