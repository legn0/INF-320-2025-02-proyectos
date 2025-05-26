# INF-320 Proyecto 1: Color


Integrantes:
- Pablo Contreras
- Nangel Coello
- Diego Veas

---

- Paso 1: Clonar el repositorio.
- Paso 2: Levantar el emulador de Android en el computador con el comando
```
C:\AndroidSDK\emulator\emulator.exe -avd MyAndroidVirtualDevice-API34 -netdelay none -netspeed full
```
- Paso 3: En una consola ejecute el siguiente comando
```
dotnet build -t:Run -f net8.0-android -p:AndroidDevice=emulator-5554
```
- Paso Extra: En caso de tener problemas en la ejecución del programa debido a problemas de conexión con el emulador, se pueden ejecutar los siguientes comandos
```
C:\AndroidSDK\platform-tools
.\adb.exe devices -l
```

*Aviso:* El programa puede tardar en ejecutarse.
