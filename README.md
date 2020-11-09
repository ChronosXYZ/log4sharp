# Log4Sharp

Dead-simple colorful logger for C#/.NET Core.

I have not found any simple loggers in the .NET Core ecosystem that are not framework-specific and have easy usage, so I decided to write this one. Mostly inspired by various Golang loggers.

![](./assets/log.png)

## Install

```
dotnet add package Log4Sharp
```

## Usage

```c#
using Log4Sharp;
...
Log.Debug("Hello World!");
Log.Info("Hello World!");
Log.Warning("Hello World!");
Log.Error("Hello World!");
Log.Fatal("Hello World!");
```

You can also change log level output filter (by default it's set to `LogLevel.Error`):

```c#
Log.SetLogLevel(LogLevel.Debug); // Allow output of all log levels
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

MIT © ChronosX88
