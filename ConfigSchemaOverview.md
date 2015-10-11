# XML Schema Definition #
The XML Schema Definition (XSD) file can be located at http://aspnetserve.googlecode.com/svn/tags/Release%201.3/aspNETserve/Configuration/Xml/aspNETserve.config.xsd

# Sample Configuration #
```
<?xml version="1.0" encoding="utf-8"?>
<server xmlns="http://aspnetserve.googlecode.com/svn/tags/Release%201.3/aspNETserve/Configuration/Xml/aspNETserve.config.xsd">
        <application physicalPath="c:\temp">
                <domain name="www.example.com" virtualPath="/" />
                <endpoint ip="127.0.0.1" port="80" />
                <endpoint ip="127.0.0.1" port="443" secure="true" />
        </application>
</server>

```

# Elements #

[Application](Application.md)
[Domain](Domain.md)
[Endpoint](Endpoint.md)
[Server](Server.md)