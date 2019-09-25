---
marp: true
footer: 'Embeddinator - Primavera Xamarin - Johann Pérez'
---

# Embeddinator 
## From Xamarin libraries to Java & Objective-C libraries

---

# About me 
# 💻 📱 💼 📈 👫 😼 ⚽ 🤓 ![imago w:40](./imago.png)️

---

# From Xamarin libraries to Java & Objective-C libraries 
# 🤓

---

# Why on earth...?
# 🤯😱

---

# Embeddinator 4000

>.NET Embedding allows your existing .NET Code (C#, F#, and others) to be consumed from other programming languages and in various different environments.

## Suported language consumers

 - Objective-C
 - Java
 - C


---

# Contributors

 1. tritao
 1. jonathanpeppers
 1. spouliot
 1. chamons
 1. rolfbjarne
 1. realvictorprm
 1. dalexsoto
 1. migueldeicaza


---

# Sample: MonkeysSDK 🛠🐒

---

# Setup

✅ CrossPlatform library
✅ Add Embeddinator NuGet Package
✅ Download ndk r15c

---

# Android

## After build command

```
mono ../packages/Embeddinator-4000.0.4.0/tools/Embeddinator-4000.exe  
    '${TargetPath}' '${TargetDir}/MonkeysSDK.dll' --gen=Java 
    --platform=Android --outdir='${SolutionDir}/androidoutput' -c 
```
---

## Android Studio

✅ Import .JAR/.AAR Package 
✅ Add module as dependency
✅ Enable D8
✅ minSDKVersion 24
✅ `multiDexEnabled true`
✅ `aaptOptions { noCompress 'dll' }`
✅ Inherit from Java.Lang.Obj -> [Register] / [Export]

---

# iOS

## After build command

```
../packages/Embeddinator-4000.0.4.0/tools/objcgen ${TargetPath} 
    --target=framework --platform=iOS 
    --outdir=${SolutionDir}/iosoutput/ -c --nativeexception
```

## XCode

✅Disable BITCODE 
✅Add Framework
✅Add Framework path to *Library Search Paths*

---

# Collections 

## Android

Neither `Monkey[]` nor `List<Monkey>` will work. Workaround: iterator

## iOS

`Monkey[]` is converted to `NSArray<MonkeysSDK_Monkey *> *)`

--- 

# Exceptions 💥

## Android

Any unhandled exception on .NET code **will crash the app**

## iOS 

You **can catch the exceptions** if you use `--nativeexception` option on the after build command

--- 

# Async 🧵

 Tasks are not recognized by Embeddinator so any async method will be ignored. Instead you could give a synchronous alternative.


 ℹ️ to avoid locking the UI thread on Android consider using `AsyncTask`
  ⚠️ you need to inherit your objects from Java.Lang.Obj, otherwise your app will crash!
 ℹ️ to avoid locking the UI thread on iOS consider using `dispatch_async`

---

```
class Something extends AsyncTask<Void, Void, String>{

        @Override
        protected void onPreExecute() {
            ...
        }

        @Override
        protected Void doInBackground(Void... voids) {
            return new MonkeysSDK().getRandomMonkey();
        }

        @Override
        protected void onPostExecute(String randomMonkey) {
            ... 
        }
    }

```

---

```objective-c
dispatch_queue_t queue = dispatch_get_global_queueDISPATCH_QUEUE_PRIORITY_DEFAULT, 0);
    dispatch_async(queue, ^{

        MonkeysSDK* sdk = [[MonkeysSDK alloc] init];
        NSString* monkey = [sdk getRandomMonkey]

        dispatch_async(dispatch_get_main_queue(), ^{
            ... 
        });
    });

```

---

# Callbacks

## Android

You can have callbacks. but it is tricky

> Calling to Java from C# is somewhat a risky business

## iOS

**NOT** possible


---

# iOS - Awful useful hack

## CFBundleSupportedPlatforms

```
sed -i '.bak' 's/&lt;string&gt;iPhoneSimulator&lt;\\/string&gt;//g' 
    ${SolutionDir}/iosoutput/FastAuthSDK.iOS.Library.framework/Info.plist
```

---

# Be aware (part 1) ⚠️

 - Slow build times 🐢
 - 1st step: Unit test everything on .NET
 - Big binaries, mostly on iOS  🏋🏻‍♂️
 - Any complex type might be a problem to migrate 😩
 - Noy every dependency is easily migrated 😓
 - Although the forum is very active, you won't always find a solution 😵
 - No bitcode support 
 - ctor: `public MonkeyIterator(Monkey[] monkeys)` fails on iOS 😔

---

# Be aware (part 2) ⚠️

## We are problem solvers!

---

# The end! 🎬 

---

# Aknowledgements

 - Majo Rabaza
 - Alex Llanes

---

## Contact info

 - ✉️ johann@nareia.com.uy
 - 🦜 @ermitani0

## References

 - https://docs.microsoft.com/en-us/xamarin/tools/dotnet-embedding/
 - https://github.com/mono/Embeddinator-4000
 - https://github.com/jsuarezruiz/Embeddinator-4000-Sample
 - https://github.com/java-decompiler/jd-gui