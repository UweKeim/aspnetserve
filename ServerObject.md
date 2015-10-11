_This page is part of the ApiReferenceGuide._


# Introduction #

The Server object represents an instance of aspNETserve.


# Details #

The Server object represents the default implementation of [IServer](http://code.google.com/p/aspnetserve/source/browse/trunk/aspNETserve/IServer.cs), an interface which specifies the following actions:
```
        void Start();
        void Stop();
        ServerStatus Status { get; }

```

All implementations of [IServer](http://code.google.com/p/aspnetserve/source/browse/trunk/aspNETserve/IServer.cs) are responsible for opening and listening on their preconfigured ports on the Start command, and disposing those resources upon the Stop command.

## Disposal ##
All IServers implement the IDispoable interface, and therefore should be properly disposed of. Failure to dispose of an IServer could result in non-managed resources being left in a improper state, which could result in previously used sockets being temporarily unavailable. C#'s "using" statement ensures safe dispose of IServer, as do try/catch/finally blocks.