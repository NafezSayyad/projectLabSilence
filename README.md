# projectLabSilence

Project idea:
The main concept of the project is for it to work both on ios and Android 
using the Microsoft MAUI (multiple application user interface) framework
the front end is programmed in XAML and the backend in C#
The design pattern is MVVM (mode view view-model)



KALLEL:
Things i am currently working on:
- The model should contain everything about the user, location etc...
- The feature I am trying to implement is when a user searches for an area, the user can see the common locations other people have picked out (ex: Nafez first time using the app, searches Budapest. Nafez sees the Budapest Mosque is a common area other users choose to have their phone silent in).
- The user can also select a place of his own, once he does this place gets added to the list of the other common locations
- The user can add or delete places that he chooses to
- The user can (ANDRIOD) can choose which type of action should the app use (silent mode, DND, work mode, etc)
- IOS users gets a notification of what action to do, bcs unlike android apps in ios cannot change phone settings.
- FOR NOW THERE IS NO NEED FOR A MAP
- we can just use a simple UI, the most important things are the key features of the app


.NET PACKAGES:
   [net8.0-android34.0]:
   Top-level Package                               Requested   Resolved
   > CommunityToolkit.Mvvm                         8.2.2       8.2.2
   > Microsoft.Extensions.Logging.Debug            8.0.0       8.0.0
   > Microsoft.Maui.Controls                       8.0.14      8.0.14
   > Microsoft.Maui.Controls.Compatibility         8.0.14      8.0.14
   > Microsoft.Maui.Controls.Maps                  8.0.14      8.0.14
   > Microsoft.Maui.Essentials                     8.0.21      8.0.21
   > Microsoft.NET.ILLink.Tasks              (A)   [8.0.3, )   8.0.3

   [net8.0-ios17.2]:
   Top-level Package                               Requested   Resolved
   > CommunityToolkit.Mvvm                         8.2.2       8.2.2
   > Microsoft.Extensions.Logging.Debug            8.0.0       8.0.0
   > Microsoft.Maui.Controls                       8.0.14      8.0.14
   > Microsoft.Maui.Controls.Compatibility         8.0.14      8.0.14
   > Microsoft.Maui.Controls.Maps                  8.0.14      8.0.14
   > Microsoft.Maui.Essentials                     8.0.21      8.0.21
   > Microsoft.NET.ILLink.Tasks              (A)   [8.0.3, )   8.0.3

   [net8.0-maccatalyst17.2]:
   Top-level Package                               Requested   Resolved
   > CommunityToolkit.Mvvm                         8.2.2       8.2.2
   > Microsoft.Extensions.Logging.Debug            8.0.0       8.0.0
   > Microsoft.Maui.Controls                       8.0.14      8.0.14
   > Microsoft.Maui.Controls.Compatibility         8.0.14      8.0.14
   > Microsoft.Maui.Controls.Maps                  8.0.14      8.0.14
   > Microsoft.Maui.Essentials                     8.0.21      8.0.21
   > Microsoft.NET.ILLink.Tasks              (A)   [8.0.3, )   8.0.3

   [net8.0-windows10.0.19041]:
   Top-level Package                            Requested   Resolved
   > CommunityToolkit.Mvvm                      8.2.2       8.2.2
   > Microsoft.Extensions.Logging.Debug         8.0.0       8.0.0
   > Microsoft.Maui.Controls                    8.0.14      8.0.14
   > Microsoft.Maui.Controls.Compatibility      8.0.14      8.0.14
   > Microsoft.Maui.Controls.Maps               8.0.14      8.0.14
   > Microsoft.Maui.Essentials                  8.0.21      8.0.21

Running on an andriod emulator : pixel 7 pro
![image](https://github.com/NafezSayyad/projectLabSilence/assets/62516699/29d75bf6-10dc-4dbe-8f78-0fef9b208e3e)

