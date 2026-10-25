using OX.Bapps;
using OX.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet
{
    public interface ITabletPlugin
    {
    }
    public abstract class TabletPlugin : ITabletPlugin
    {
        public static Dictionary<string, TabletPlugin> Plugins = new Dictionary<string, TabletPlugin>();
        public abstract ITabletPluginUI Build();
    }
    public interface ITabletModule
    {
    }
    public abstract class TabletModule : ITabletModule
    {
        public static Dictionary<string, TabletModule> Modules = new Dictionary<string, TabletModule>();
        public abstract string ModuleName { get; }
        public abstract PageTreeNode Build();
    }
    public static class TabletPluginHelper
    {
        static readonly string PluginRootPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "plugins");
        static readonly string ModuleRootPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "modules");
        public static void LoadPlugins()
        {
            if (!Directory.Exists(PluginRootPath)) return;
            foreach (string filename in Directory.EnumerateFiles(PluginRootPath, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var file = File.ReadAllBytes(filename);
                Assembly assembly = Assembly.Load(file);
                //assemblies[assembly.FullName] = assembly;
                foreach (Type type in assembly.ExportedTypes)
                {
                    if (!type.IsSubclassOf(typeof(TabletPlugin))) continue;
                    if (type.IsAbstract) continue;

                    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                    try
                    {
                        var obj = constructor?.Invoke(null);
                        if (obj is TabletPlugin tp)
                        {
                            TabletPlugin.Plugins[type.FullName] = tp;
                        }
                    }
                    catch (Exception ex)
                    {
                        Plugin.Log(nameof(TabletPlugin), LogLevel.Error, $"Failed to initialize TabletPlugin: {ex.Message}");
                    }
                }
            }
        }
        public static void LoadModules()
        {
            if (!Directory.Exists(ModuleRootPath)) return;
            foreach (string filename in Directory.EnumerateFiles(ModuleRootPath, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var file = File.ReadAllBytes(filename);
                Assembly assembly = Assembly.Load(file);
                //assemblies[assembly.FullName] = assembly;
                foreach (Type type in assembly.ExportedTypes)
                {
                    if (!type.IsSubclassOf(typeof(TabletModule))) continue;
                    if (type.IsAbstract) continue;

                    ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                    try
                    {
                        var obj = constructor?.Invoke(null);
                        if (obj is TabletModule tp)
                        {
                            TabletModule.Modules[type.FullName] = tp;
                        }
                    }
                    catch (Exception ex)
                    {
                        Plugin.Log(nameof(TabletPlugin), LogLevel.Error, $"Failed to initialize TabletPlugin: {ex.Message}");
                    }
                }
            }
        }
    }
}
