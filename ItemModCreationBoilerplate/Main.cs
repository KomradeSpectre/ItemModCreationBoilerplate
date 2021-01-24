using BepInEx;
using ItemModCreationBoilerplate.Equipment;
using ItemModCreationBoilerplate.Items;
using R2API;
using R2API.Networking;
using R2API.Utils;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ItemModCreationBoilerplate
{
    [BepInPlugin(ModGuid, ModName, ModVer)]
    [BepInDependency(R2API.R2API.PluginGUID, R2API.R2API.PluginVersion)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [R2APISubmoduleDependency(nameof(ItemAPI), nameof(LanguageAPI), nameof(ResourcesAPI))]
    public class Main : BaseUnityPlugin
    {
        public const string ModGuid = "com.MyUsername.MyModName";
        public const string ModName = "My Mod's Title and if we see this exact name on Thunderstore we will deprecate your mod";
        public const string ModVer = "0.0.1";

        public static AssetBundle MainAssets;

        public List<ItemBase> Items = new List<ItemBase>();
        public List<EquipmentBase> Equipments = new List<EquipmentBase>();

        private void Awake()
        {
            // Don't know how to create/use an asset bundle, or don't have a unity project set up?
            // Look here for info on how to set these up: https://github.com/KomradeSpectre/AetheriumMod/blob/rewrite-master/Tutorials/Item%20Mod%20Creation.md#unity-project

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ItemModCreationBoilerplate.my_assetbundlefile"))
            {
                MainAssets = AssetBundle.LoadFromStream(stream);
                var provider = new AssetBundleResourcesProvider($"@{ModName}", MainAssets);
                ResourcesAPI.AddProvider(provider);
            }

            //Item Initialization
            ValidateItem(new ExampleItem(), Items);

            foreach (ItemBase item in Items)
            {
                item.Init(base.Config);
            }

            //Equipment Initialization
            ValidateEquipment(new ExampleEquipment(), Equipments);

            foreach (EquipmentBase equipments in Equipments)
            {
                equipments.Init(base.Config);
            }
        }

        /// <summary>
        /// A helper to easily set up and initialize an item from your item classes if the user has it enabled in their configuration files.
        /// <para>Additionally, it generates a configuration for each item to allow blacklisting it from AI.</para>
        /// </summary>
        /// <param name="item">A new instance of an ItemBase class. e.g. "new ExampleItem()"</param>
        /// <param name="itemList">The list you would like to add this to if it passes the config check.</param>
        public void ValidateItem(ItemBase item, List<ItemBase> itemList)
        {
            var enabled = Config.Bind<bool>("Item: " + item.ItemName, "Enable Item?", true, "Should this item appear in runs?").Value;
            var aiBlacklist = Config.Bind<bool>("Item: " + item.ItemName, "Blacklist Item from AI Use?", false, "Should the AI not be able to obtain this item?").Value;
            if (enabled)
            {
                itemList.Add(item);
                if (aiBlacklist)
                {
                    item.AIBlacklisted = true;
                }
            }
        }

        /// <summary>
        /// A helper to easily set up and initialize an equipment from your equipment classes if the user has it enabled in their configuration files.
        /// </summary>
        /// <param name="equipment">A new instance of an EquipmentBase class. E.g. "new ExampleEquipment()"</param>
        /// <param name="equipmentList">The list you would like to add this to if it passes the config check.</param>
        public void ValidateEquipment(EquipmentBase equipment, List<EquipmentBase> equipmentList)
        {
            if (Config.Bind<bool>("Equipment: " + equipment.EquipmentName, "Enable Equipment?", true, "Should this equipment appear in runs?").Value) { equipmentList.Add(equipment); }
        }

    }
}
