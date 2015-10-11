# Introduction #

aspNETserve starting with version 1.3 will ship with a windows service called aspNETserve.Ice. For now the binary will be installed, but the service will not be registered with the Windows Service Control Manager. Future releases will provide a proper installation, but for now this is left as a manual task.


## Installation ##

The installer for version 1.3 will install the aspNETserve.Ice binary into the Program Files directory, but will not register the service. To properly register the service a system administrator will need to run the [sc command](http://support.microsoft.com/kb/251192) in a similar fashion as:
```
sc \\. create aspNETserve.Ice binPath= "c:\Program Files\aspNETserve\aspNETserve.Ice.exe"
```

Assuming aspNETserve.Ice resides in the "c:\Program Files\aspNETserve\" directory, the above command will create a service entry called aspNETserve.Ice.

## Removal ##
To uninstall the windows service you will need to issue the following command:
```
sc \\. delete aspNETserve.Ice
```

## Configuration ##
The service expects a file called "aspNETserve.config.xml" residing in the same directory as the service executable. So, for example, if aspNETserve was installed to "c:\Program File\aspNETserve\" then the aspNETserve.config.xml file would have to be located in the same directory.

For information on the structure of the xml file, please reference the ConfigSchemaOverview.