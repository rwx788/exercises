## Table of Contents
* [exercises](#exercises)
    * [k3s](#k3s)
    * [Xamarin](#xamarin)
        * [Project description](#project-description)
        * [Issues](#issues)
        * [Further steps](#further-steps)

# exercises
Repo for the coding exercises and trying new technologies

## k3s
### Project description
Simple k3s with kubernetes dashboard.

### Installation and deployment
Installation can be done by issuing `curl -sfL https://get.k3s.io | sh -` command.

In order to deploy/upgrade dashboard, run `deploy.sh` shell script.
To access the dashboard, create a secure channel by running:
```
sudo k3s kubectl proxy
```

Login token can be obtained using following command:
```
sudo k3s kubectl -n kubernetes-dashboard describe secret admin-user-token | grep ^token
```

## Xamarin
### Project description
Project uses Xamarin.Forms framework to develop an app for android and UWP platforms.
Developed application contains 3 fields for the side lengths of the triangle and returns
type of the triangle using simple label.
MVC pattern was used for the application. UI tests use classical PageObject software
design pattern.
NUnit was chosen as a framework for UI and unit tests, as provides rich functionality
for the fixtures and data driven testing.

### Issues
Multiple issues were faced during the project:
* UWP application behavior differs from Android and first control which is focusable gets focused on the app start. In our case, this is text field. It causes the issue that placeholder for the text field is not visible on the app start. Issue doesn't occur on android platform. Solution proposed on stack overflow was to use invisible controls, which will get the focus in this case. Therefore, seems that case of truly cross-platform UI application is not a common use-case and Xamarin is commonly use for Android/iOS applications.
* Newer versions of the Andoid API have issues with `Xamarin.UITest` testing methods, namely `EnterText` and `ClearText`. Only API versions >= 29 are affected. See https://github.com/microsoft/appcenter/issues/1451 . Github issue desribes the workaround for the `EnterText`. `ClearText` though, works only by setting empty string to the text field.
* When executing UITest on android, multiple times HttpRequestException was thrown, and no controls were detected. Root cause of the issue was not identified. I've tried not to restart the application before each test case, but it didn't resolve the issue. After further chanegs to the project, the issue was resolved. Likely this happened due to big numer of the test scenarios, which was reduced after covering more cases as unit tests. See https://github.com/xamarin/xamarin-android/issues/4721 .

### Further steps
* Project is created using Visual Studio Community Edition and misses easy way to build the project and execute tests.
* App is very basic and doesn't use any of the async events handling features.
* Project doesn't use `Model` functionality Xamarin provides for the interaction with the database.
* UI tests are developed for the Android only.
* Testing framework missing wrappers to wait for the conditions to become true.
