﻿namespace Sitecore.Demo.Foundation.SitecoreExtensions.Extensions
{
  using System;
    using Sitecore.Demo.Foundation.SitecoreExtensions;
    using Sitecore.Mvc.Presentation;

  public static class RenderingExtensions
  {
    public static int GetIntegerParameter(this Rendering rendering, string parameterName, int defaultValue = 0)
    {
      if (rendering == null)
      {
        throw new ArgumentNullException(nameof(rendering));
      }

      var parameter = rendering.Parameters[parameterName];
      if (string.IsNullOrEmpty(parameter))
      {
        return defaultValue;
      }

      int returnValue;
      return !int.TryParse(parameter, out returnValue) ? defaultValue : returnValue;
    }

    public static bool GetUseStaticPlaceholderNames(this Rendering rendering)
    {
      return Sitecore.MainUtil.GetBool(rendering.Parameters[Constants.DynamicPlaceholdersLayoutParameters.UseStaticPlaceholderNames], false);
    }
  }
}