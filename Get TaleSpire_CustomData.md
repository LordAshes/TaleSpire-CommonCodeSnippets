# To obtain all Directories of "TaleSpire_CustomData" for plugins.
This script allows core methods to dynamically point towards multiple plugins providing only custom assets e.g. minis or props.
From there you can fetch things as required e.g. assetbundles or images. The assumption is the running dll is within the root of the plugin folder. 

```csharp
    public ParallelQuery<DirectoryInfo> GetAssetPaths()
        {
            // Get Location of Dll
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            // Navigate To Parent Folder
            var pluginsFolder = Directory.GetParent(assemblyFolder).FullName;
            
            // Get All subfolder "TaleSpire_CustomData" foreach folder (in parrallel)
            DirectoryInfo dInfo = new DirectoryInfo(pluginsFolder);
            var subdirs = dInfo.GetDirectories()
                .AsParallel()
                .Where(d => d.GetDirectories()
                    .Any(c => c.Name == "TaleSpire_CustomData"))
                .Select(d => d.GetDirectories()
                    .Single(c => c.Name == "TaleSpire_CustomData")
                );

            /* Just logging all subdirs
            foreach (var dir in subdirs)
            {
                Debug.Log($"Child: {dir.FullName}");
            }*/
            
            return subdirs;
        }
```
