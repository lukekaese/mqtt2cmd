# MQTT Command Line Publisher

This Project is a small C# Progamm to send Messages via a MQTT topic of a MQTT Server.

## Requirements

The following requirements needs to be installed in order to Build the Project 

1.  **.NET SDK**:

- Version 5.0 or higher is required. The Build Project should run without the famework if you use the provided Buildscript

- [Download .NET SDK](https://dotnet.microsoft.com/download)

## Build Project

Open a command line and type the following command:
```bash
.\build.cmd
```
The Compiled Project is located in the 
```
.out
```
Directory

## Usage

After building the project, you can use the created executable to send a JSON message to an MQTT topic.

### Syntax

Run the program with the following arguments:
```bash
mqtt2commandline_<version>.exe  --server  <server-address>  --topic  <MQTT-topic>  --message  <JSON-message>
```
### Parameters
-  `--server` or `-s`: The address of the MQTT server, e.g., `127.0.0.1`.

-  `--topic` or `-t`: The MQTT topic to which the message will be published.

-  `--message` or `-m`: The JSON message to be sent. It must be enclosed in single quotes (`'`) to be read correctly by the command line.  

### Example

#### Sending simple Text
```bash
mqtt2commandline.exe  --server  127.0.0.1  --topic  esb01/LED/1  --message  "red"
```

This command sends the JSON message `red` to the topic `esb01/LED/1` on the specified MQTT server (localhost).


#### Sending a JSON
```bash
mqtt2commandline.exe  --server  127.0.0.1  --topic  esb01/LED/1  --message  "{\"color\":{\"hex\":\"#FF0000\"}}"
```

This command sends the JSON message `{"color":{"hex":"#FF0000"}}` to the topic `esb01/LED/1` on the specified MQTT server (localhost).

### Notes

-  **JSON Input**: Ensure that the JSON message is enclosed in single quotes (`"`)  and quotes used within the message are escaped (``\"``)so the command line correctly interprets the message as a single argument.

-  **Error Messages**: If invalid JSON or a failed connection occurs, the program will display appropriate error messages.

---

 I hope my program is usefull for you