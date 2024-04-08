using Sitecore.Data;


namespace Sitecore.Demo.Feature.Navigation
{
    public struct Templates
    {
        public struct Header
        {
            public static readonly ID ID = new ID("{A72DAC86-2201-4B89-803D-2A0015278393}");
            public static readonly ID BaseTemplateID = new ID("{6EBE5296-C059-486D-A821-84B04BD06E97}");

            public struct Fields
            {
                public static readonly ID Logo = new ID("{8FBDF6E6-1AF9-4A23-AE1E-002524E56FFA}");
                public static readonly ID NavItems = new ID("{4DB45E5C-7F0D-4B0E-A837-DB9377574F72}");
                public static readonly ID Login_label = new ID("{F851B77F-E04D-4CA3-BD78-6E241575D0BC}");
                public static readonly ID Login_Url = new ID("{589D0019-163D-46E6-96D8-811C15603C2A}");
                public static readonly ID Post_Job_label = new ID("{621A19DF-57BF-42AF-93EA-ECEFECEC6BB4}");
                public static readonly ID Post_Job_Url = new ID("{A65AE09F-43CE-4BC8-B4F9-CEBFAA1F0A7D}");
            }
        }
        public struct NavItems
        {
            public struct Fields
            {
                public static readonly ID Nav_Item_label = new ID("{598320F2-A0B7-4811-8C01-303B58ECE549}");
                public static readonly ID Nav_Item_Url = new ID("{64D47C9D-80C7-4369-87DD-A98F02BFD017}");
                public static readonly ID Childrens = new ID("{121AB60B-7BE3-4953-ADE4-D6C6B72464EC}");
            } 
        }
        public struct Footer
        {
            public static readonly ID ID = new ID("{B6B30967-BFAE-4B77-BA85-1F82BF71ABD9}");
            public static readonly ID BaseTemplateID = new ID("{49970AD0-57C1-44E7-B44B-9373F3D5998A}");

            public struct Fields
            {
                public static readonly ID Logo = new ID("{0554BD5F-519F-4625-A6DE-380818CEAFB3}");
                public static readonly ID Gmail = new ID("{008F1350-AAB6-483F-8EF9-310D9C6091EC}");
                public static readonly ID Phone = new ID("{5561C3BA-9C12-40EB-84F0-AA759C4DDA46}");
                public static readonly ID Address = new ID("{C2327885-1DAF-4456-ABCC-1D81AA4A1BA2}");
                public static readonly ID Company_label = new ID("{E4B03229-B976-4FA8-A851-8A714CA18401}");
                public static readonly ID Companies = new ID("{32BB419B-4F25-48E8-A895-AA6BB536232E}");
                public static readonly ID Category_label = new ID("{4F32B8FC-E7BB-431A-9FC1-B4E4B1BF570C}");
                public static readonly ID Categories = new ID("{4D0F5C82-FF5E-4D7D-BEBA-6565DE3F7577}");
                public static readonly ID Subscribe_label = new ID("{C2DD1BC3-54DF-4902-AEFB-5CF5503B955A}");
                public static readonly ID Subscribe_Url = new ID("{50786E9E-D0AE-48E9-BED5-994BD859BBAE}");
                public static readonly ID Subscribe_Description = new ID("{53BE8187-F6EC-47AC-90B0-A51E0C0D5E4F}");
                public static readonly ID Copyrights_label = new ID("{302EE542-5469-4E69-A9CB-BAF152AAE00D}");

            }
        }
        public struct FooterList
        {
            public struct Fields
            {
                public static readonly ID Footer_label = new ID("{80FB789D-4C8B-4589-B084-FEE591E78459}");
                public static readonly ID Footer_Link = new ID("{6FEABF7A-3311-4DC4-932F-07BAB9FF5D57}");
            }
        }
    }
}