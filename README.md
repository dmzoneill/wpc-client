# WPC Client

The client agent for Workstation Policy Control (WPC), which shows up as Windows
Process Controller.

## What it does

It reads its settings and a list of allowed processes from the registry under
`HKEY_LOCAL_MACHINE\SOFTWARE\WPK`, then watches running processes and stops any
that are not allowed. It can add itself to the Windows `Run` key so it starts at
logon.

The settings are managed with
[wpc-administrator](https://github.com/dmzoneill/wpc-administrator).

## Tech

- Visual Basic .NET (Windows Forms)

## Building

Open `WindowsApplication3.sln` in Visual Studio and build it. Windows only.

## License

Licensed under the Apache License 2.0. See [LICENSE](LICENSE).
