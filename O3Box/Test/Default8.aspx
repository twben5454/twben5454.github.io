<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default8.aspx.cs" Inherits="Test_Default8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet"  href="https://unpkg.com/swiper/swiper-bundle.min.css"  />
    <style>
        


        .swiper {
        width: 100%;
        height: 500px;
      }

      .swiper-slide {
        text-align: center;
        font-size: 18px;
        background: #fff;

        /* Center slide text vertically */
        display: -webkit-box;
        display: -ms-flexbox;
        display: -webkit-flex;
        display: flex;
        -webkit-box-pack: center;
        -ms-flex-pack: center;
        -webkit-justify-content: center;
        justify-content: center;
        -webkit-box-align: center;
        -ms-flex-align: center;
        -webkit-align-items: center;
        align-items: center;
      }

      .swiper-slide img {
        display: block;
        width: 200px;
        height: 400px;
        object-fit: cover;
      }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="swiper mySwiper">
      <div class="swiper-wrapper">
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022134920.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022134929.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022134937.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022134946.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022134955.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022135004.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022135012.jpg" /></div>
        <div class="swiper-slide">
            <img src="../images/Product/微信图片_20211022135029.jpg" /></div>
      </div>
      <div class="swiper-pagination"></div>
    </div>

    <!-- Swiper JS -->
    <script src="https://unpkg.com/swiper/swiper-bundle.min.js"></script>

    <!-- Initialize Swiper -->
    <script>
      var swiper = new Swiper(".mySwiper", {
        slidesPerView: 3,
        spaceBetween: 30,
        pagination: {
          el: ".swiper-pagination",
          clickable: true,
        },
      });
    </script>
</asp:Content>

