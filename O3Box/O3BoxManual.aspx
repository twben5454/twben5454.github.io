<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="O3BoxManual.aspx.cs" Inherits="O3BoxManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .image-wrapper img {
            width: 100%;
            object-fit: cover;
        }
        .card-wrapper {
        background-color: #ffffff;
        border-radius: 4px;
        }
        .card:not(:nth-last-child(1)) {
        margin-bottom: 2rem;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="team2 cid-sNzaMUHriQ" xmlns="http://www.w3.org/1999/html" id="team2-v">
    
    
    <div class="container">
        <div class="card">
            <div class="card-wrapper">
                <div class="row align-items-center">
                    <div class="col-12 col-md-4">
                        <div class="image-wrapper">
                            <img src="images/Manual/初始啟動.jpg" alt="Mobirise">
                        </div>
                    </div>
                    <div class="col-12 col-md align-self-start">
                        <div class=" align-top" >
                            <h5 class="display-5 mt-1">
                                <strong>活氧瓶啟動</strong>
                            </h5>
                            <p class="mbr-text mbr-fonts-style display-7">
                                用手指輕觸開關,約五秒後,活氧瓶會變成啟動模式.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="card-wrapper">
                <div class="row align-items-center">
                    <div class="col-12 col-md-4">
                        <div class="image-wrapper">
                            <img src="images/Manual/啟動.jpg" alt="Mobirise">
                        </div>
                    </div>
                    <div class="col-12 col-md align-self-start">
                        <div class="card-box">
                            <h5 class="card-title  m-0 display-5">
                                <strong>開始生成活氧水</strong>
                            </h5>
                            <p class="mbr-text mbr-fonts-style display-7">
                                亮紅燈後, 再輕按一次開關,瓶身變成藍燈,活氧瓶開始生成活氧水,時間約一分鐘,生成完畢後,燈會自動熄滅, 即可開始使用.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="card">
            <div class="card-wrapper">
                <div class="row align-items-center">
                    <div class="col-12 col-md-4">
                        <div class="image-wrapper">
                            <img src="images/Manual/活氧生成.jpg" alt="Mobirise">
                        </div>
                    </div>
                    <div class="col-12 col-md align-self-start">
                        <div class="card-box">
                            <h5 class="card-title  m-0 display-5">
                                <strong>生成活氧水狀態</strong>
                            </h5>
                            <p class="mbr-text mbr-fonts-style display-7">
                                亮藍燈後,活氧瓶會慢慢產生類似氣泡,代表活氧瓶進行生成活氧水狀態.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>

