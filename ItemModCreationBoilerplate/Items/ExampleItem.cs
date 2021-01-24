using BepInEx.Configuration;
using R2API;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemModCreationBoilerplate.Items
{
    public class ExampleItem : ItemBase
    {
        public override string ItemName => "Deprecate Me Item";

        public override string ItemLangTokenName => "DEPRECATE_ME_ITEM";

        public override string ItemPickupDesc => "";

        public override string ItemFullDescription => "";

        public override string ItemLore => "";

        public override ItemTier Tier => ItemTier.Tier1;

        public override string ItemModelPath => "";

        public override string ItemIconPath => "";

        internal override void Init(ConfigFile config)
        {
            base.Init(config);
        }

        public override void CreateConfig(ConfigFile config)
        {

        }

        public override ItemDisplayRuleDict CreateItemDisplayRules()
        {
            return new ItemDisplayRuleDict();
        }

        public override void Hooks()
        {

        }
    }
}
