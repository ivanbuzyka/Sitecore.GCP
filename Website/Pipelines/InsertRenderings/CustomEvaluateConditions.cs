using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Pipelines.InsertRenderings;
using Sitecore.Pipelines.InsertRenderings.Processors;
using Sitecore.Publishing.Pipelines.PublishItem;
using Sitecore.Rules;
using Sitecore.Rules.ConditionalRenderings;
using Sitecore.SecurityModel;

namespace Website.Pipelines.InsertRenderings
{
    public class CustomEvaluateConditions : InsertRenderingsProcessor
    {
        protected void Evaluate(InsertRenderingsArgs args, Item item)
        {
            List<RenderingReference> list2 = new List<RenderingReference>(args.Renderings);
            foreach (RenderingReference reference in list2)
            {
                if (reference.RenderingID.Equals(new ID("{FC2A5A10-6121-4626-86C8-863C66DE6482}")))
                {
                    var rulesParent = item.Database.GetItem("{0E30E9F9-3457-4402-A3C5-74BCEE31283A}");
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