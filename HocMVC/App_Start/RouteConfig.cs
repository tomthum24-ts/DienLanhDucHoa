using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HocMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Danh mục sản phẩm
            routes.MapRoute(
                name: "Product category",
                url: "san-pham/{MetaTitle}-{cateId}",
                defaults: new { controller = "product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "HocMVC.Controllers" }
            );
            //Chi tiết sản phẩm
            routes.MapRoute(
              name: "Product Detail",
              url: "chi-tiet/{metatitle}-{id}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            //Giới thiệu
            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HocMVC.Controllers" }
            );
            //Bài viết
            routes.MapRoute(
               name: "Content",
               url: "tin-tuc",
               defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            routes.MapRoute(
              name: "Content Detail",
              url: "bai-viet/{metatitle}-{id}",
              defaults: new { controller = "Content", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            routes.MapRoute(
             name: "Content Category",
             url: "loai-bai-viet/{metatitle}-{id}",
             defaults: new { controller = "Content", action = "Category", id = UrlParameter.Optional },
             namespaces: new[] { "HocMVC.Controllers" }
         );
            //tất cả sản phẩm
            routes.MapRoute(
               name: "Product",
               url: "san-pham",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Tìm kiếm
            routes.MapRoute(
               name: "Search product",
               url: "tim-kiem",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Mở giỏ hàng
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Thanh toán
            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Hoàn thành thanh toán
            routes.MapRoute(
               name: "Payment Success",
               url: "hoan-thanh",
               defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Liên hệ
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Thêm giỏ hàng
            routes.MapRoute(
               name: "add to cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            //Project
            routes.MapRoute(
              name: "project",
              url: "dich-vu",
              defaults: new { controller = "Project", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            routes.MapRoute(
               name: "project category",
               url: "loai-dich-vu/{metatitle}-{id}",
               defaults: new { controller = "Project", action = "Category", id = UrlParameter.Optional },
               namespaces: new[] { "HocMVC.Controllers" }
           );
            routes.MapRoute(
            name: "project Detail",
            url: "dich-vu/{metatitle}-{id}",
            defaults: new { controller = "Project", action = "Detail", id = UrlParameter.Optional },
            namespaces: new[] { "HocMVC.Controllers" }

          );
            //Xay dung
            
            routes.MapRoute(
              name: "Xay Dung",
              url: "xay-dung",
              defaults: new { controller = "XayDung", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
              routes.MapRoute(
              name: "Xay Dung Category",
              url: "xay-dung/{metatitle}-{id}",
              defaults: new { controller = "XayDung", action = "Category", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            routes.MapRoute(
          name: "xay dung Detail",
          url: "cong-trinh/{metatitle}-{id}",
          defaults: new { controller = "XayDung", action = "Detail", id = UrlParameter.Optional },
          namespaces: new[] { "HocMVC.Controllers" }

          );
            routes.MapRoute(
         name: "Loai xay dung ",
         url: "loai-xay-dung/{metatitle}-{id}",
         defaults: new { controller = "LoaiXayDung", action = "Category", id = UrlParameter.Optional },
         namespaces: new[] { "HocMVC.Controllers" }

         );
            routes.MapRoute(
         name: "Am Thuc Detail",
         url: "am-thuc/{metatitle}-{id}",
         defaults: new { controller = "AmThuc", action = "Index", id = UrlParameter.Optional },
         namespaces: new[] { "HocMVC.Controllers" }

     );
            routes.MapRoute(
      name: "project search",
      url: "du-an/timkiem",
      defaults: new { controller = "Project", action = "TimKiem", id = UrlParameter.Optional },
      namespaces: new[] { "HocMVC.Controllers" }

  );

            // Giới thiệu
            routes.MapRoute(
           name: "about us",
           url: "gioi-thieu",
           defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "HocMVC.Controllers" }
       );
            // Tuyển dụng

            routes.MapRoute(
              name: "Tuyen Dung",
              url: "tuyen-dung",
              defaults: new { controller = "TuyenDung", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            routes.MapRoute(
            name: "Add ho so tuyen dung",
            url: "tuyen-dung/addhoso",
            defaults: new { controller = "TuyenDung", action = "AddHoSo", id = UrlParameter.Optional },
            namespaces: new[] { "HocMVC.Controllers" }
        );
            //Ban điều hành
            routes.MapRoute(
              name: "Ban dieu hanh",
              url: "ban-dieu-hanh",
              defaults: new { controller = "Manager", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            //Ban điều hành
            routes.MapRoute(
              name: "san pham",
              url: "san-pham",
              defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "HocMVC.Controllers" }
          );
            //Default 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
