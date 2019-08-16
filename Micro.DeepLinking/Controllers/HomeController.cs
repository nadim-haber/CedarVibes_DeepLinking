using System.Web.Mvc;
using Micro.DeepLinking.Helpers;
using Micro.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Micro.DeepLinking.GalleryService;
using Micro.DeepLinking.ClassifiedAdsService;
using Micro.DeepLinking.Models;

namespace Micro.DeepLinking.Controllers
{
    public class HomeController : BaseController
    {
        private ClassifiedAdsServiceClient _classifiedAdsService = new ClassifiedAdsServiceClient();
        private GalleryServiceClient _galleryService = new GalleryServiceClient();
        private DataHelper _dataHelper = new DataHelper();
        private LogHelper _logHelper = new LogHelper();

        private const string defaultThumbSize = "100";

        private string defaultItemUniversalLinkIndex = "ITEM";

        private string defaultShopUniversalLinkIndex = "SHOP";

        public string MediaURL
        {
            get
            {
                string mediaURL = null;

                if (ConfigurationManager.AppSettings.AllKeys.Where(x => x.Equals("MediaContent_Url")).Count() > 0)
                    mediaURL = ConfigurationManager.AppSettings["MediaContent_Url"];

                return mediaURL;
            }
        }

        public string ThumbSize
        {
            get
            {
                string thumbSize = defaultThumbSize;

                if (ConfigurationManager.AppSettings.AllKeys.Where(x => x.Equals("ThumbSize")).Count() > 0)
                    thumbSize = ConfigurationManager.AppSettings["ThumbSize"];

                return thumbSize;
            }
        }

        public string ItemUniversalLinkIndex
        {
            get
            {
                string itemUniversalLinkIndex = defaultItemUniversalLinkIndex;

                if (ConfigurationManager.AppSettings.AllKeys.Where(x => x.Equals("ItemUniversalLinkIndex")).Count() > 0)
                {
                    itemUniversalLinkIndex = ConfigurationManager.AppSettings["ItemUniversalLinkIndex"];
                }

                return itemUniversalLinkIndex;
            }
        }

        public string ShopUniversalLinkIndex
        {
            get
            {
                string shopUniversalLinkIndex = defaultShopUniversalLinkIndex;

                if (ConfigurationManager.AppSettings.AllKeys.Where(x => x.Equals("ShopUniversalLinkIndex")).Count() > 0)
                {
                    shopUniversalLinkIndex = ConfigurationManager.AppSettings["ShopUniversalLinkIndex"];
                }

                return shopUniversalLinkIndex;
            }
        }

        public ActionResult Index(Guid? c, string v)
        {
            ShareModel shareModel = new ShareModel();
            if (!string.IsNullOrWhiteSpace(v) && c.HasValue)
            {
                if (v == ItemUniversalLinkIndex)
                {
                    var _request = Base.FillBaseModel<ItemInfoRequest>();
                    _request.Guid = c.Value;

                    var itemResponse = _classifiedAdsService.GetItemInfo(_request);
                    if (itemResponse.Status == (int)Status.Success && itemResponse.Data != null)
                    {
                        shareModel.Title = itemResponse.Data.Title;
                        shareModel.Description = itemResponse.Data.Description;
                        shareModel.ShareLink = string.Empty;
                        if (itemResponse.Data.Gallery != null && itemResponse.Data.Gallery.Media != null && itemResponse.Data.Gallery.MediaCount > 0)
                        {
                            var media = itemResponse.Data.Gallery.Media.FirstOrDefault();
                            if (media != null)
                                shareModel.Image = MediaURL + media.Guid + "/" + ThumbSize;
                        }

                        if (string.IsNullOrWhiteSpace(shareModel.Description))
                            shareModel.Description = string.Empty;
                    }
                }
                else if (v == ShopUniversalLinkIndex)
                {
                    var _request = Base.FillBaseModel<VendorInfoRequest>();
                    _request.Guid = c.Value;

                    var vendorResponse = _classifiedAdsService.GetVendorInfo(_request);
                    if (vendorResponse.Status == (int)Status.Success && vendorResponse.Data != null)
                    {
                        shareModel.Title = vendorResponse.Data.Name;
                        shareModel.Description = vendorResponse.Data.Description;
                        shareModel.ShareLink = string.Empty;
                        if (vendorResponse.Data.Media != null)
                        {
                            shareModel.Image = MediaURL + vendorResponse.Data.Media.Guid + "/" + ThumbSize;
                        }

                        if (string.IsNullOrWhiteSpace(shareModel.Description))
                            shareModel.Description = string.Empty;
                    }
                }
            }

            return View(shareModel);
        }
    }
}