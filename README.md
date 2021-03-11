# SStorage

This is a simple `C#` library that allows you save data in a binary format.

## Features

*Write*: You can write any data type to disk at runtime with any name you want.
```cs
IStorage storage = HelperFactory.SStorage();

storage.Write("Title", "MyAwesomeApp");
storage.Write("Height", 800);

// The values have now been written to disk.

```

*Read*: You can read any data type from the name you assigned it when writing it.
```cs
IStorage storage = HelperFactory.SStorage();

storage.Write("Username", "DeetonRushy");

// The string 'user' will be set to 'DeetonRushy'.
string user = storage.ReadString("Username");

```

*Save & Load*: You can save all the current data you have, this isn't just the data in our storage file. SStorage saves the variable name and other data needed in order to retrieve it in a json file with the name & path of your choice.
```cs
private void OnExit()
{
    // Saves all current session data to 'save-file.json'
    Globals.storage.Save("save-file.json");

}

// alternative

AppDomain.CurrentDomain.ProcessExit += new EventHandler (OnProcessExit);

private void OnProcessExit()
{
    Globals.storage.Save("save-file.json");
}

private void OnLoad()
{
    // This global instance of SStorage will now have all previous data loaded & ready.
    
    if ( System.IO.File.Exists("save-file.json") )
    {
        Globals.storage.Load("save-file.json");
    }
    
    // ...

}
```
## How is the data 'loaded'?
I may butcher this, so bear with me.

The files are written to via  [BinaryReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.binaryreader?view=net-5.0) & [BinaryWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.binaryreader?view=net-5.0). These two classes allow you to access the underlying stream they are using. Therefore, we can access the Position we are at in the stream. The way this works is, on write we add the size, in bytes, to our class' private variable 'Position'. This way we can access the very end position in the stream and keep track of it.

The way we link the data's name with the data is by storing the current Position along side it inside of a dictionary. This data is discovered before we increment SStorage's private member Position, the end position before we add the data will be the data's start position. We can then use that data to link the two and make the data accessible with one of the Read functions. 

We can then save the dictionary into Json format using [Newtonsoft.Json](https://www.newtonsoft.com/json) and easily 'Load' it back in using the saved json file.

## Full Usage

:zzz:
#### synchronous
```cs
// Fully initialized object, no need for constructors etc.
// You can currently access every constructor with the HelperFactory.

IStorage storage = HelperFactory.SStorageWithPathDbg("storage.dat");

// All native C# types are supported with Write
storage.Write("MyInt", (int)1);
storage.Write("MyByte", (byte)1);

// Likewise, all native C# types are support to read.

var a = storage.ReadInt("MyInt");
var b = storage.ReadByte("MyByte");

// You can save your data.
storage.Save("saved.json");

// That can now be re-read by any other instance of storage.
IStorage storage_two = HelperFactory.SStorageWithPathDbg("storage.dat");
storage_two.Load("saved.json");
```
:stopwatch:
#### asynchronous
```cs
// Fully initialized object, no need for constructors etc.
// You can currently access every constructor with the HelperFactory.

IStorage storage = HelperFactory.SStorageWithPathDbg("storage.dat");

// All native C# types are supported with Write
storage.WriteAsync("MyInt", (int)1);
storage.WriteAsync("MyByte", (byte)1);

// Likewise, all native C# types are support to read.

var a = storage.ReadIntAsync("MyInt");
var b = storage.ReadByteAsync("MyByte");

// You can save your data.
storage.SaveAsync("saved.json");

// That can now be re-read by any other instance of storage.
IStorage storage_two = HelperFactory.SStorageWithPathDbg("storage.dat");
storage_two.LoadAsync("saved.json");
```


## Upcoming features

- [x] Encoding: SStorage will soon support storing the data with a specific encoding.
- [x] Interfaces: SStorage now uses a factory to pass back IStorage types. This makes using this library have much less burden on your code.
- [x] Speed: Saving, writing and loading need to be optimized further to reach better speeds.
- [x] Async: SStorage support asynchronous execution.
- [ ] Editable Values: Add support for constant values, values that can be over-written etc. 
