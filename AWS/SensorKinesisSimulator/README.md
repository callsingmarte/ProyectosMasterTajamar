# SensorKinesisSimulator

Simula sensores que envían datos a un stream de Amazon Kinesis en tiempo real.

## 🚀 Requisitos

- .NET 6 SDK
- AWS CLI configurado o credenciales válidas en `~/.aws/credentials`
- Un stream activo de Amazon Kinesis

## ⚙️ Configuración

Edita `Program.cs` y cambia la línea:

```csharp
const string streamName = "mi-stream-kinesis";
```

A tu stream real.

## 🛠️ Instalación y ejecución

```bash
dotnet restore
dotnet run
```

## 🧪 Ejemplo de evento generado

```json
{
  "deviceId": "sensor-002",
  "temperature": 28.7,
  "humidity": 52.4,
  "location": "Zona 2",
  "timestamp": "2025-04-21T19:00:01Z",
  "batteryLevel": 88.1,
  "status": "OK"
}
```
