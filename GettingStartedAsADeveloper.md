_This page is part of the ApiReferenceGuide._

# Introduction #

Whether your planning on contributing to the aspNETserve project or embedding aspNETserve into your own application there are a few core concepts that are generally helpful when getting started. For the remainder of this document the assumption is made that you are proficient in either C# or Visual Basic.NET including an understanding of concepts such as [AppDomains](http://msdn.microsoft.com/en-us/library/cxk374d9.aspx), [threads](http://en.wikipedia.org/wiki/Thread_(computer_science)), [asynchrony](http://msdn.microsoft.com/en-us/library/2e08f6yc(VS.71).aspx), [assemblies](http://msdn.microsoft.com/en-us/library/ms173099(VS.80).aspx), and other cornerstone .NET concepts.

## Downloads ##
aspNETserve is available in two download formats, source and binary. You can make do with just the binary installer and reference the DLLs from your own project. However, it is recommended that you download the source code to at least use it as a reference. Despite being a relatively small API it can get confusing sometimes, and online documentation such as this can only cover a fraction of question you may have.

## Getting Assistance ##
If you should come to any road blocks during your explorations with aspNETserve feel free to stop by the [discussion group](http://groups.google.com/group/aspnetserve) as ask questions. For those of you who may dislike asking questions in such an open forum, you may also [email me](mailto:jason.whitehorn@gmail.com) (Jason Whitehorn) directly and I will do my best to answer your questions.

## Assemblies ##
aspNETserve is composed of primarily 2 assemblies aspNETserve and aspNETserve.Core. The functionality of aspNETserve as a whole product is split between these two assemblies based on the sole factor of whether code needs to be executed within the hosted AppDomain or within the hosting AppDomain.

#### aspNETserve.dll ####
The aspNETserve assembly (sometimes called aspNETserve.dll to avoid confusion) contains the functionality that executes in the hosting AppDomain.

#### aspNETserve.Core ####
the aspNETserve.Core assembly contains the components of aspNETserve that need to be executed from within the hosted AppDomain. It should be noted that as of version 1.3 of aspNETserve the aspNETserve.Core assembly will either need to be placed in the GAC or within your web application's bin directory. For more information on this please see read [aspNETserve Without GAC Install](http://jason.whitehorn.ws/2008/08/24/aspNETserve-Without-GAC-Install.aspx).

Determining which of the two assemblies to reference for your project is a matter of what your project is attempting to accomplish. For _most_ applications you will want to reference the aspNETserve.dll as it is the one that contains the ServerObject which represents the "web server" and handles all incoming TCP/IP requests.