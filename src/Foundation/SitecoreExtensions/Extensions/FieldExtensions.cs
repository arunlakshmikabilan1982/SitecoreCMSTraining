namespace Sitecore.Demo.Foundation.SitecoreExtensions.Extensions
{
    using System;
    using System.Web;
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Links;
    using Sitecore.Links.UrlBuilders;
    using Sitecore.Mvc.Helpers;
    using Sitecore.Resources.Media;
    using Sitecore.StringExtensions;

    public static class FieldExtensions
    {
        public static string ImageUrl(this ImageField imageField)
        {
            if (imageField?.MediaItem == null)
            {
                return string.Empty;
            }

            var options = MediaUrlBuilderOptions.Empty;
            int width, height;

            if (int.TryParse(imageField.Width, out width))
            {
                options.Width = width;
            }

            if (int.TryParse(imageField.Height, out height))
            {
                options.Height = height;
            }
            return imageField.ImageUrl(options);
        }

        public static string ImageUrl(this ImageField imageField, MediaUrlBuilderOptions options)
        {
            if (imageField?.MediaItem == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            return options == null ? imageField.ImageUrl() : HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageField.MediaItem, options));
        }

        public static bool IsChecked(this Field checkboxField)
        {
            if (checkboxField == null)
            {
                throw new ArgumentNullException(nameof(checkboxField));
            }
            return MainUtil.GetBool(checkboxField.Value, false);
        }
        public static bool GetFieldAsBool(this Item item, ID fieldId)
        {
            CheckboxField field = item.Fields[fieldId];

            return field != null ? field.Checked : false;
        }

        public static HtmlString FieldLinkUrl(this SitecoreHelper sitecoreHelper, ID fieldId)
        {
            return sitecoreHelper.FieldLinkUrl(fieldId, sitecoreHelper.CurrentItem);
        }

        public static HtmlString FieldLinkUrl(this SitecoreHelper sitecoreHelper, ID fieldId, Item item)
        {
            var linkUrl = item.GetFieldLinkUrl(fieldId);

            return new HtmlString(linkUrl);
        }

        public static string GetFieldLinkUrl(this Item item, ID field)
        {
            string linkTarget;

            return item.GetFieldLinkUrl(field, out linkTarget);
        }

        public static string GetFieldLinkUrl(this Item item, ID field, out string linkTarget)
        {
            var result = string.Empty;

            LinkField linkField = item.Fields[field];

            if (item[field].Length == 0)
            {
                result = string.Empty;
            }
            else if (linkField == null)
            {
                result = string.Empty;
            }
            else if (linkField.IsMediaLink && linkField.TargetItem != null)
            {
                result = HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(linkField.TargetItem));
            }
            else if (linkField.IsInternal && linkField.TargetItem != null)
            {
                result = LinkManager.GetItemUrl(linkField.TargetItem);
            }
            else if (!linkField.Url.IsNullOrEmpty())
            {
                result = linkField.Url;
            }
            linkTarget = (linkField == null) ? string.Empty : linkField.Target;

            return result;
        }
        public static string InternalLinkFieldUrl(this Item item, ID fieldID)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (ID.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException(nameof(fieldID));
            }
            var field = item.Fields[fieldID];
            if (field == null || !(FieldTypeManager.GetField(field) is InternalLinkField))
            {
                return string.Empty;
            }
            InternalLinkField linkField = field;
            if (linkField != null && linkField.TargetItem != null)
            {
                var url = linkField.TargetItem.Url(new ItemUrlBuilderOptions { AlwaysIncludeServerUrl = false });
                return url;
            }
            return string.Empty;
        }
        public static string GetTargetFieldStringValue(this Item item, ID field, ID referencedField)
        {
            ReferenceField referenceField = Context.Item.Fields[field];
            var referenceitem = referenceField?.TargetItem;
            return referenceitem != null ? referenceitem.GetString(referencedField) : string.Empty;

        }

        public static string GetDropTreeLinkUrl(this Item item, ID field)
        {
            var result = string.Empty;
            ReferenceField referenceField = item.Fields[field];
            if (item[field].Length == 0)
            {
                result = string.Empty;
            }
            else if (referenceField == null)
            {
                result = string.Empty;
            }
            else if (referenceField.TargetItem == null)
            {
                result = string.Empty;
            }
            else
            {
                result = LinkManager.GetItemUrl(referenceField.TargetItem);
            }

            return result;
        }
        public static string GetDropLinkFieldValue(this Item item, ID field, ID targetField)
        {
            if (item[field].Length == 0) return string.Empty;

            ReferenceField referenceField = item.Fields[field];

            if (referenceField == null) return string.Empty;

            if (referenceField.TargetItem == null) return string.Empty;

            return referenceField.TargetItem.Fields[targetField].Value;
        }

        public static DateTime GetFieldAsDateTime(this Item item, ID fieldId)
        {
            DateField dateField = item.Fields[fieldId];

            return dateField != null ? DateUtil.ToServerTime(DateUtil.IsoDateToDateTime(dateField.Value, DateTime.MinValue)) : DateTime.MinValue;
        }
    }
}