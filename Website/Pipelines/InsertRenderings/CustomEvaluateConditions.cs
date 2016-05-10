using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Pipelines.InsertRenderings;
using Sitecore.Pipelines.InsertRenderings.Processors;
using Sitecore.Publishing.Pipelines.PublishItem;
using Sitecore.Rules;
using Sitecore.Rules.ConditionalRenderings;
using Sitecore.SecurityModel;
using Website.Constants;

namespace Website.Pipelines.InsertRenderings
{
    public class CustomEvaluateConditions : InsertRenderingsProcessor
    {
        //ToDo: this shoudld be optimized in order to use some caching etc.
        //Property can be cached on site-base
        public IEnumerable<Item> RenderingConfigs
        {
            get
            {
                var result = new List<Item>();
                var configPath = Sitecore.Context.Site.Properties["gcpPath"];
                if (!string.IsNullOrEmpty(configPath))
                {
                    var parent = Sitecore.Context.Database.GetItem(configPath);
                    if (parent != null)
                    {
                        result = parent.Children.Where(c => c.TemplateID.Equals(GcpTemplateIds.ComponentSetting)).ToList();
                    }
                }

                return result;
            }
        }

        protected void Evaluate(InsertRenderingsArgs args, Item item)
        {
            List<RenderingReference> list2 = new List<RenderingReference>(args.Renderings);
            foreach (RenderingReference reference in list2)
            {
                if (RenderingConfigs.Any(c => ((ReferenceField)c.Fields["Component"]).TargetID.Equals(reference.RenderingID)))
                {
                    var rulesParent = RenderingConfigs.First(c => ((ReferenceField)c.Fields["Component"]).TargetID.Equals(reference.RenderingID));
                    rulesParent = rulesParent.Children.First(x => x.TemplateID.Equals(GcpTemplateIds.SystemRulesFolder));
                    RuleList<ConditionalRenderingsRuleContext> rules = RuleFactory.GetRules<ConditionalRenderingsRuleContext>(rulesParent, "Rule");
                    ConditionalRenderingsRuleContext ruleContext = new ConditionalRenderingsRuleContext(args.Renderings, reference)
                    {
                        Item = item
                    };

                    rules.Run(ruleContext);
                }
            }
        }

        public override void Process(InsertRenderingsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (args.HasRenderings)
            {
                Item contextItem = args.ContextItem;
                if (contextItem != null)
                {
                    this.Evaluate(args, contextItem);
                }
            }
        }
    }
}