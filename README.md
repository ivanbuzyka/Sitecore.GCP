#GlobalComponentPersonalization (GCP)

##Description
GCP is a proof-of-concept for doing site-independent global personalization of the components.
You can configure set of rules to be always evaluated for particular component within a site context. You can store all these rule settings in any location, so you can have flexible configuration for different security scenarios.  

##Get started
###Deployment
There is no Sitecore package yet, so in order to install the module you need to deploy that from Visual Studio.
In order to deploy that, you should go through following steps:

1. Deploy clean Sitecore website (or use one from your project: in this case you should reorganize sample settings data afterwards)
2. Add reference to Sitecore.Kernel.dll (don't forget to set "Copy local" to "false" in Visual Studio)
3. File "GCP.Unicorn.CustomSerializationFolder.config" update "physicalRootPath" attribute with absolute path to Unicorn serialization folder on your local drive (so, after deployment to Sitecore instance, you will be able to restore all the items using Unicorn)
4. Publish project in Visual Studio to the Sitecore instance
5. Open your Sitecore instance and sync the items using Unicorn: open http://<your-instance>/unicorn.aspx and then click "Sync" button

###Simple content and module configuration
This readme describes configuration of simple demo on clean Sitecore instance. In case you deploy module to the instance with an existing project within Sitecore, please take into account, that you should add attribute "gcpPath" to your site definitions which should point to appropriate setting roots (see an example in "GCP.Sites.config"). The settings roots, component references and rules should be added in context of your project.

So, configuration on clean Sitecore instance:

1. File "GCP.Sites.config" have 2 sample sites configured. Please add hostnames "site1.local" and "site2.local" to your hosts file and as bindings to your website in IIS Manager
2. Go to Content Editor and take a look at items under "/sitecore/content/Site1" and "/sitecore/content/Site1". There are sample Home items for each site with 2 additional components assigned: "BannerWidget" and "TeaserText". Both components accepts data sources and uses "Banner1" and "Teaser source 1" appropriately 
3. Under "/sitecore/content/Site1/Home/Settings/GCP" you see component personalization items for each of the components. They have rules configured (rules items as well as "Rules" folders are standard Sitecore items from rules engine. So, nothing custom there)
4. There is a rule for "BannerWidget" that changes data source to "Banner 2" as soon as standard goal "Register" is triggered in current session
5. There is a rule for "TeaserText" that changes data source to "Teaser source 2" in both cases: as soon as standard goal "Register" is triggered in current session or as soon as page http://<your-sitename>/trigger is visited in current session
6. You can add more rules, components and play with that a bit. Insert options are assigned on those custom items, so it should be pretty straightforward.

##Supported versions
GCP has been briefly tested on Sitecore 7.2 Update-5
It will work most likely also on later versions, however it hasn't been tried yet






