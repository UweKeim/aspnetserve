# Introduction #

A patch is a file that describes changes made to a piece of software. Patches are used by software developers to easily allows others to reproduce their changes. More specifically without write access to the Subversion repository, any contributors to aspNETserve are forced to create patches and submit them to those who do have write access.


### Patch Creation ###

First acquire a working copy of the subversion repository, and make your desired changes locally. Next, to create a patch simply run the following command from a command prompt:
```
svn diff > patch.diff
```

The patch will be created as a file called _patch.diff_, and you are free to replace that file name with something more meaningful.


### Patch Submission ###

To submit a patch please attach it to an outstanding issue under the [Issues List](http://code.google.com/p/aspnetserve/issues/list). If no outstanding issue exists for the feature you've implemented or the bug you've fixed then first create an issue to describe what problem you were trying to solve. All submissions must strictly adhere to the Submission Guidelines.

### Submission Guidelines ###

All submissions must meet the following requirements:
  * The submitter must be the copyright holder for submissions.
  * The submitted work must be released under the same license as aspNETserve.
  * The submission must not have been the product of reverse engineering, or information protected by non-disclosure agreements.

In addition, submissions are subject to approval and refactoring. Not all submissions will be approved.