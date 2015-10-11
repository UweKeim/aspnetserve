# Overview #

Web Application Packages, WAPs, are archives which contain ASP.NET web applications. WAPs can be used to simply the deployment of web applications in an aspNETserve hosted solution. Essentially WAPs are little more than ZIP compressed archives with minimal structure.

# File Structure #

A WAP file is, at its simplest, a ZIP archive renamed to have a ".wap" extension. The archive should contain on root directory title "site" under which the entire contents of the website should be located.

# WAP Creation #

Currently no automated tools exist to create WAPs, fortunately they are easily created by hand. This can be accomplished by simply renaming the folder containing the web site to "site", and creating a ZIP archive from that directory. Once the ZIP file has been created, the ".zip" extension should be replaced with a ".wap" extension.