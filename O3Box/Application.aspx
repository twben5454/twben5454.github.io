<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="py-5" id="application">
        <div class="container px-5 my-5">
            <div class="row gx-5 justify-content-center">
                <div class="col-lg-8 col-xl-6">
                    <div class="text-center">
                        <h2 class="fw-bolder">活氧瓶行業別應用</h2>
                        <p class="lead fw-normal text-muted mb-5">大岞活氧瓶,不只能消毒,還具有除臭,清潔功能!!</p>
                    </div>
                </div>
            </div>
            <div class="text-center">
                <div class="btn-group " role="group" aria-label="Basic example">
                    <button type="button" id="btn1" class="btn btn-primary" style="margin-left:5px;">公共場所</button>
                    <button type="button" id="btn2" class="btn btn-primary" style="margin-left:5px;">餐廳小吃店</button>
                    <button type="button" id="btn3" class="btn btn-primary" style="margin-left:5px;">包廂 KTV,MTV</button>
                    <button type="button" id="btn1" class="btn btn-primary" style="margin-left:5px;">水果攤店肉鋪</button>
                    <button type="button" id="btn1" class="btn btn-primary" style="margin-left:5px;">刺青店</button>
                    <button type="button" id="btn1" class="btn btn-primary" style="margin-left:5px;">足浴店</button>
                    <button type="button" id="btn1" class="btn btn-primary" style="margin-left:5px;">戶外運動</button>
                </div>
            </div>

             <div class="row gx-5">
                <div class="col-md-12 col-lg-2 mb-5">
                    <button type="button" id="btn10" class="btn btn-primary btn-block" style="margin-left:5px;">全部</button>
                </div>
                <div class="col-lg-2 col-md-12 mb-5">
                    <button type="button" id="btn20" class="btn btn-primary" style="margin-left:5px;">全部</button>
                </div>
                <div class="col-lg-2 col-md-12 mb-5">
                    <button type="button" id="btn30" class="btn btn-primary" style="margin-left:5px;">全部</button>
                </div>
                <div class="col-lg-2 col-md-12 mb-5">
                    <button type="button" id="btn40" class="btn btn-primary" style="margin-left:5px;">全部</button>
                </div>
                <div class="col-lg-2 col-md-12 mb-5">
                    <button type="button" id="btn40" class="btn btn-primary" style="margin-left:5px;">全部</button>
                </div>
                <div class="col-lg-2 col-md-12 mb-5">
                    <button type="button" id="btn40" class="btn btn-primary" style="margin-left:5px;">全部</button>
                </div>
                <div class="col-lg-2 col-md-12 mb-5">
                    <button type="button" id="btn40" class="btn btn-primary" style="margin-left:5px;">全部</button>
                </div>
            </div>
            <div class="row gx-5">
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/廚房清洗.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">廚房清潔</h5>
                            </a>
                            <p class="card-text mb-0">分解臥室、客廳、冰箱、衣物間、浴廁等空間之臭味、煙味、霉味、瓦斯味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/寵物消毒除臭.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">寵物消毒除臭</h5>
                            </a>
                            <p class="card-text mb-0">臭氧可有效分解寵物排泄物之臭味；讓家中保持空氣清新,創造優質生活空間。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/假牙消毒.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">假牙消毒</h5>
                            </a>
                            <p class="card-text mb-0">有助於減少細菌滋生,讓假牙更清潔.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/傷口清創.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">傷口清創消毒</h5>
                            </a>
                            <p class="card-text mb-0">無刺激性, 利用臭氧消毒功效, 達到清創傷口上細菌.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/冰箱.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">冰箱除臭</h5>
                            </a>
                            <p class="card-text mb-0">分解臥室、客廳、冰箱、衣物間、浴廁等空間之臭味、煙味、霉味、瓦斯味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/嗽口水.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">口腔消毒除臭</h5>
                            </a>
                            <p class="card-text mb-0">維持口腔衛生,擁有清新口氣,氧分子轉換為臭氧並充分溶於水.製作無化學添加的臭氧嗽口水,具有抑菌效果,口感舒適,安全可靠.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/婦女.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">婦女私處消毒除臭</h5>
                            </a>
                            <p class="card-text mb-0">臭氧是氧的同素異形體，有很強的氧化能力，在一定濃度下能與細菌、病毒、病原體等微生物產生生化反應，短時間內破壞病毒生物結構，刺破細胞壁，使之失去活力﹔對陰道滴蟲微生物有殺滅作用。.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/新生嬰兒.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">奶瓶,奶嘴,玩具消毒</h5>
                            </a>
                            <p class="card-text mb-0">嬰兒手部與嘴部接觸物體的表面奶嘴,奶瓶,餐具,玩具,有效消毒.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/環境消毒.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">環境消毒除臭</h5>
                            </a>
                            <p class="card-text mb-0">分解臥室、客廳、冰箱、衣物間、浴廁等空間之臭味、煙味、霉味、瓦斯味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/皮件發霉.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">皮件去霉</h5>
                            </a>
                            <p class="card-text mb-0">皮件或皮鞋發霉,噴灑活氧水, 並用乾淨布擦拭過,即可除霉.讓霉菌不易繁殖</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/碗具清潔.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">碗盤清潔消毒</h5>
                            </a>
                            <p class="card-text mb-0">利用臭氧解油膩及消毒功效,輕鬆清潔碗盤用具.使用時噴灑,效果更佳.洗碗盤時,手會油膩感,噴臭氧水,可解油膩.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/蔬果.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">蔬果消毒保鮮</h5>
                            </a>
                            <p class="card-text mb-0">分解蔬果殘存農藥、去除細菌、蟲卵、即使有機蔬果，因其凹凸不平的表面，亦容易附著細菌、蟲卵而不易清洗；去除魚肉中細菌、黴菌，降低魚肉腥味，保持魚肉之新鮮度。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/衣物.jpeg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">衣物消毒除臭</h5>
                            </a>
                            <p class="card-text mb-0">疫情時代下,曬衣物時, 噴臭氧水於衣物上, 達到消毒作用.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/車內除臭.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">車內消毒除臭</h5>
                            </a>
                            <p class="card-text mb-0">車內設備方向盤, 排檔桿,痤椅,手把門.分解空間之臭味、煙味、霉味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/香港腳.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">香港腳,癬消毒</h5>
                            </a>
                            <p class="card-text mb-0">臭氧是氧的同素異形體，有很強的氧化能力，在一定濃度下能與細菌、病毒、病原體等微生物產生生化反應，短時間內破壞病毒生物結構，刺破細胞壁，使之失去活力﹔.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/魚肉.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">魚肉保鮮除臭</h5>
                            </a>
                            <p class="card-text mb-0">分解蔬果殘存農藥、去除細菌、蟲卵、即使有機蔬果，因其凹凸不平的表面，亦容易附著細菌、蟲卵而不易清洗；去除魚肉中細菌、黴菌，降低魚肉腥味，保持魚肉之新鮮度。</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 mb-5">
                    <div class="card h-100 shadow border-0">
                        <img class="card-img-top" src="images/清洗桌面.jpg" alt="..." />
                        <div class="card-body p-4">
                            <a class="text-decoration-none link-dark stretched-link" href="#!">
                                <h5 class="card-title mb-3">清潔並消毒桌面</h5>
                            </a>
                            <p class="card-text mb-0">餐桌油膩, 不易清洗. 不用洗潔劑, 利用臭氧高分解油膩特質, 擦拭時,洗潔兼消毒。</p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Call to action
                    <aside class="bg-primary bg-gradient rounded-3 p-4 p-sm-5 mt-5">
                        <div class="d-flex align-items-center justify-content-between flex-column flex-xl-row text-center text-xl-start">
                            <div class="mb-4 mb-xl-0">
                                <div class="fs-3 fw-bold text-white">New products, delivered to you.</div>
                                <div class="text-white-50">Sign up for our newsletter for the latest updates.</div>
                            </div>
                            <div class="ms-xl-4">
                                <div class="input-group mb-2">
                                    <input class="form-control" type="text" placeholder="Email address..." aria-label="Email address..." aria-describedby="button-newsletter" />
                                    <button class="btn btn-outline-light" id="button-newsletter" type="button">Sign up</button>
                                </div>
                                <div class="small text-white-50">We care about privacy, and will never share your data.</div>
                            </div>
                        </div>
                    </aside>-->
        </div>
    </section>
</asp:Content>

