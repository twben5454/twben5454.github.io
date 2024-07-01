<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
            <!-- Header-->
            <header class="bg-dark py-5">
                <div class="container px-5">
                    <div class="row gx-5 align-items-center justify-content-center">
                        <div class="col-lg-8 col-xl-7 col-xxl-6">
                            <div class="my-5 text-center text-xl-start">
                                <h1 class="display-5 fw-bolder text-white mb-2">疫情時代改變了我們生活</h1>
                                <p class="lead fw-normal text-white-50 mb-4" ><span style="color:orange;">告別酒精的乾燥敏感,向次氯酸水說,不</span></p>
                                <p class="lead fw-normal text-white-50 mb-4">可噴灑<span style="color:red;">人體, 食品, 食器餐具</span>的天然消毒水, 隨身攜帶, 隨時製造!</p>
                                <div class="d-grid gap-3 d-sm-flex justify-content-sm-center justify-content-xl-start">
                                    <a class="btn btn-primary btn-lg px-4 me-sm-3" href="#application">了解活氧瓶</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-5 col-xxl-6 d-none d-xl-block text-center"><img class="img-fluid rounded-3 my-5" src="images/微信图片_20220508071147.jpg" alt="..." /></div>
                    </div>
                </div>
            </header>
            <!-- Features section-->
            <section class="py-5" id="features">
                <div class="container px-5 my-5">
                    <div class="row gx-5">
                        <div class="col-lg-4 mb-5 mb-lg-0"><h2 class="fw-bolder mb-0">環保,科技使用活氧瓶</h2>
                            <img src="images/二代活氧瓶.jpg" style="max-width:100%;max-height:100%;" />
                        </div>
                        <div class="col-lg-8">
                            <div class="row gx-5 row-cols-1 row-cols-md-2">
                                <div class="col mb-5 h-100">
                                    <div class="feature bg-primary bg-gradient text-white rounded-3 mb-3"><i class="bi bi-collection"></i></div>
                                    <h2 class="h5">廣用性</h2>
                                    <p class="mb-0">臭氧對各種病菌如細菌、真菌、病毒、黴菌、支原體、衣原體、陰道滴蟲等致病微生物都有殺滅作用。</p>
                                </div>
                                <div class="col mb-5 h-100">
                                    <div class="feature bg-primary bg-gradient text-white rounded-3 mb-3"><i class="bi bi-building"></i></div>
                                    <h2 class="h5">快速性</h2>
                                    <p class="mb-0">臭氧達一定程度後， 可在數秒至數分鐘之間殺滅病原微生物，是已知消毒劑中速度最快的一種。</p>
                                </div>
                                <div class="col mb-5 mb-md-0 h-100">
                                    <div class="feature bg-primary bg-gradient text-white rounded-3 mb-3"><i class="bi bi-toggles2"></i></div>
                                    <h2 class="h5">安全性</h2>
                                    <p class="mb-0">臭氧相對於其他化學消毒劑如甲醛、過氧乙酸、二氧化硫等來的較無殘留性。臭氧急性毒性實驗顯示濃度0.1ppm以下屬於無毒，且對喉嚨、黏膜、眼均無刺激性， 因為人類體內健康的細胞具有強大的氧化平衡酶(酵素)系統，規範內含量的臭氧對健康的細胞是無毒無害的，包括臭氧殺死病菌或汙染物後所產生的副產物氧氣分子O2與水分子H2O也是。</p>
                                </div>
                                <div class="col h-100">
                                    <div class="feature bg-primary bg-gradient text-white rounded-3 mb-3"><i class="bi bi-toggles2"></i></div>
                                    <h2 class="h5">無耐藥性</h2>
                                    <p class="mb-0">臭氧破壞的是病菌的遺傳物質，不會使病菌再度復活，是不可逆的死亡，不同於抗生素及抗菌藥膏可能會產生抗藥性。</p>
                                </div>
                                <div class="col h-100">
                                    <div class="feature bg-primary bg-gradient text-white rounded-3 mb-3"><i class="bi bi-toggles2"></i></div>
                                    <h2 class="h5">雙重性</h2>
                                    <p class="mb-0">殺死病菌後的副產物氧分子與水分子可供細胞的組織吸收，可使血液循環加速，促進患部的肌膚癒合。</p>
                                </div>
                                <div class="col h-100">
                                    <div class="feature bg-primary bg-gradient text-white rounded-3 mb-3"><i class="bi bi-toggles2"></i></div>
                                    <h2 class="h5">多處應用性</h2>
                                    <p class="mb-0">臭氧的殺菌力為氯的3000倍，可以取代氯消毒，臭氧用來處理飲用水已超過90年，廣泛應用於自來水、游泳池、食品的殺菌處理，以及包裝水、醫藥食品製程用水和空氣品質淨化等。</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- Testimonial section
            <div class="py-5 bg-light" >
                <div class="container px-5 my-5" >
                    <div class="row gx-5 justify-content-center">
                        <div class="col-lg-10 col-xl-7">
                            <div class="text-left text-primary h2"><a href="https://www.cna.com.tw/news/ait/202008260365.aspx" target="_new">日實驗首度證實 低濃度臭氧可殺死新型冠狀病毒</a></div>
                            <div class="text-left">
                                <div class="fs-6 mb-4  ">2020/8/26 20:47（8/27 12:30 更新）
                                    <p>（中央社東京26日綜合外電報導）日本藤田醫科大學今天表示，低濃度臭氧可中和新型冠狀病毒微粒，或許是醫院消毒診療室與候診區等的可行方法。這是全世界首度經實驗確認，低濃度臭氧也具有殺死新冠病毒效果。

                                        藤田醫科大學科學家在線上記者會表示，他們首度證實對人體無害的0.05至0.1ppm（百萬分之一）低濃度臭氧，可殺死2019冠狀病毒疾病（COVID-19，武漢肺炎）病毒。
                                        
                                        這項實驗在一個內有新型冠狀病毒樣本的密閉空間使用臭氧生成機，當暴露在低濃度臭氧達10小時，病毒的活性銳減超過90%。</p>
                                </div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>-->
    
            <div class="py-5 bg-light">
                <div class="container px-5 my-5">
                    <div class="row gx-5 justify-content-center">
                        <div class="col-lg-10 col-xl-7">
                            <div class="text-center">
                                <div class="fs-4 mb-4 fst-italic">
                                    <p style="font-size:24px;color:blue;"><span style="font-size:30px;font-weight:bold;">大岞活氧瓶</span> 採用電解式臭氧產生方式</p>
                                    <p>電解式臭氧是透過使<span style="color:red;">電流通過水將氧 (O₂) 分子分解為氧原子 (O) 而產出的。</span> 然後游離氧原子可以與氧分子結合形成 O₃。以這種方式製造的 O₃ 可用於許多不同的應用，臭氧水是一種用於清潔水、水系統和其他機械的強力殺菌劑。</p>
                                    <p style="font-size:20px;color:red;"><span style="font-size:24px;font-weight:bold; color:orange;">目前市售超過 70% 的競爭對手使用電擊放電方式 </span>,基於空氣的臭氧方法對水進行消毒。基於空氣的臭氧水發生器使用電擊放電來產生臭氧，但是由於實現臭氧過程需要高電壓，因此它們非常危險。</p>
                                </div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <div class="py-5 bg-light">
                <div class="container px-5 my-5">
                    <div class="row gx-5 justify-content-center">
                        <img src="images/網頁介紹/大岞_公司介紹.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_介紹一.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_介紹二.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_介紹三.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_介紹四.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_介紹五.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_比較.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_生成.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_分部介紹.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_功能.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_效果.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_特色.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_應用icon.jpg" alt="大岞,活氧,大岞活氧" />
                        <img src="images/網頁介紹/大岞_證書.jpg" alt="大岞,活氧,大岞活氧" />

                        <hr/>
                    </div>
                </div>
            </div>
    <section class="py-5" id="application">
                <div class="container px-5 my-5">
                    <div class="row gx-5 justify-content-center">
                        <div class="col-lg-8 col-xl-6">
                            <div class="text-center">
                                <h2 class="fw-bolder">活氧瓶生活應用</h2>
                                <p class="lead fw-normal text-muted mb-5">大岞活氧瓶,不只能消毒,還具有除臭,清潔功能!!</p>
                            </div>
                        </div>
                    </div>
                    <div class="row gx-5">
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/臉部.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>皮膚保養</strong></h5>
                                    <p class="card-text mb-0">使用活氧零刺激,零殘留,安心無憂. 疫情期間, 外出回來, 使用活氧水不慬可以洗手,更可以用於清潔臉部等肌膚,全方位滅殺各類細菌和病毒.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/擦拭玻璃.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>擦拭玻璃</strong></h5>
                                    <p class="card-text mb-0">使用活氧擦拭玻璃, 不留痕跡, 水漬, 清潔後乾淨溜溜. 另外用來擦拭手機螢幕, 眼鏡也有同樣良好效果.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/曬衣.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>內衣無菌,身體舒爽</strong></h5>
                                    <p class="card-text mb-0">內衣內褲,毛巾清洗後,用活氧水浸泡,可快速滅殺各類病菌,防止細菌滋生,貼肌不易引起細菌性皮膚過敏或交叉感染.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/廚房清洗.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>廚房清潔</strong></h5>
                                    <p class="card-text mb-0">分解臥室、客廳、冰箱、衣物間、浴廁等空間之臭味、煙味、霉味、瓦斯味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/寵物消毒除臭.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>寵物消毒除臭</strong></h5>
                                    <p class="card-text mb-0">臭氧可有效分解寵物排泄物之臭味；讓家中保持空氣清新,創造優質生活空間。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/假牙消毒.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>假牙消毒</strong></h5>
                                    <p class="card-text mb-0">有助於減少細菌滋生,讓假牙更清潔.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/傷口清創.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>傷口清創消毒</strong></h5>
                                    <p class="card-text mb-0">無刺激性, 利用臭氧消毒功效, 達到清創傷口上細菌.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/冰箱.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>冰箱除臭</strong></h5>
                                    <p class="card-text mb-0">分解臥室、客廳、冰箱、衣物間、浴廁等空間之臭味、煙味、霉味、瓦斯味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/嗽口水.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>口腔消毒除臭</strong></h5>
                                    <p class="card-text mb-0">維持口腔衛生,擁有清新口氣,氧分子轉換為臭氧並充分溶於水.製作無化學添加的臭氧嗽口水,具有抑菌效果,口感舒適,安全可靠.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/婦女.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>婦女私處消毒除臭</strong></h5>
                                    <p class="card-text mb-0">臭氧是氧的同素異形體，有很強的氧化能力，在一定濃度下能與細菌、病毒、病原體等微生物產生生化反應，短時間內破壞病毒生物結構，刺破細胞壁，使之失去活力﹔對陰道滴蟲微生物有殺滅作用。.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/新生嬰兒.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>奶瓶,奶嘴,玩具消毒</strong></h5>
                                    <p class="card-text mb-0">嬰兒手部與嘴部接觸物體的表面奶嘴,奶瓶,餐具,玩具,有效消毒.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/環境消毒.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>環境消毒除臭</strong></h5>
                                    <p class="card-text mb-0">分解臥室、客廳、冰箱、衣物間、浴廁等空間之臭味、煙味、霉味、瓦斯味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/皮件發霉.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>皮件去霉</strong></h5>
                                    <p class="card-text mb-0">皮件或皮鞋發霉,噴灑活氧水, 並用乾淨布擦拭過,即可除霉.讓霉菌不易繁殖</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/碗具清潔.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>碗盤清潔消毒</strong></h5>
                                    <p class="card-text mb-0">利用臭氧解油膩及消毒功效,輕鬆清潔碗盤用具.使用時噴灑,效果更佳.洗碗盤時,手會油膩感,噴臭氧水,可解油膩.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/蔬果.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>蔬果消毒保鮮</strong></h5>
                                    <p class="card-text mb-0">分解蔬果殘存農藥、去除細菌、蟲卵、即使有機蔬果，因其凹凸不平的表面，亦容易附著細菌、蟲卵而不易清洗；去除魚肉中細菌、黴菌，降低魚肉腥味，保持魚肉之新鮮度。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/衣物.jpeg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>衣物消毒除臭</strong></h5>
                                    <p class="card-text mb-0">疫情時代下,曬衣物時, 噴臭氧水於衣物上, 達到消毒作用.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/車內除臭.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>車內消毒除臭</strong></h5>
                                    <p class="card-text mb-0">車內設備方向盤, 排檔桿,痤椅,手把門.分解空間之臭味、煙味、霉味；空間殺菌，讓家中塵蹣、霉菌、細菌不易繁殖，創造優質生活空間。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/香港腳.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>香港腳,癬消毒</strong></h5>
                                    <p class="card-text mb-0">臭氧是氧的同素異形體，有很強的氧化能力，在一定濃度下能與細菌、病毒、病原體等微生物產生生化反應，短時間內破壞病毒生物結構，刺破細胞壁，使之失去活力﹔.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/魚肉.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong>魚肉保鮮</strong></h5>
                                    <p class="card-text mb-0">分解蔬果殘存農藥、去除細菌、蟲卵、即使有機蔬果，因其凹凸不平的表面，亦容易附著細菌、蟲卵而不易清洗；去除魚肉中細菌、黴菌，降低魚肉腥味，保持魚肉之新鮮度。</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 mb-5">
                            <div class="card h-100 shadow border-0">
                                <img class="card-img-top" src="images/清洗桌面.jpg" alt="..." />
                                <div class="card-body p-4">
                                    <h5 class="card-title mb-3 text-secondary"><strong> 清潔並消毒桌面</strong></h5>
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
            <div class="section">
                <div class="container">
                    <div class="row">
                        <!-- Image Column -->
                        <div class="col-sm-6">
                            <div class="portfolio-item">
                                <div class="portfolio-image">
                                    <a href="#"><img src="images/18753.jpg" alt="Project Name"></a>
                                </div>
                            </div>
                        </div>
                        <!-- End Image Column -->
                        <!-- Project Info Column -->
                        <div class="portfolio-item-description col-sm-6">
                            <h3 class="mt-5"><a href="https://www.cna.com.tw/news/ait/202008260365.aspx" target="_new">日實驗首度證實 低濃度臭氧可殺死新型冠狀病毒</a></h3>
                            <p class="mt-5">（中央社東京26日綜合外電報導）日本藤田醫科大學今天表示，低濃度臭氧可中和新型冠狀病毒微粒，或許是醫院消毒診療室與候診區等的可行方法。這是全世界首度經實驗確認，低濃度臭氧也具有殺死新冠病毒效果。

                                藤田醫科大學科學家在線上記者會表示，他們首度證實對人體無害的0.05至0.1ppm（百萬分之一）低濃度臭氧，可殺死2019冠狀病毒疾病（COVID-19，武漢肺炎）病毒。
                                
                                這項實驗在一個內有新型冠狀病毒樣本的密閉空間使用臭氧生成機，當暴露在低濃度臭氧達10小時，病毒的活性銳減超過90%。</p>
                        </div>
                        <!-- End Project Info Column -->
                    </div>
                    <!-- End Related Projects -->
                </div>
            </div>
            <!--<section class="py-5 bg-light" id="scroll-target">
                <div class="container px-5 my-5">
                    <div class="row gx-5 align-items-center">
                        <div class="col-lg-6"><img class="img-fluid rounded mb-5 mb-lg-0" src="images/covid-19-updates-banner-a.png" alt="..."  /></div>
                        <div class="col-lg-6">
                            <h2 class="fw-bolder"><a href="https://www.cna.com.tw/news/ait/202008260365.aspx" target="_new">日實驗首度證實 低濃度臭氧可殺死新型冠狀病毒</a></h2>
                            <p class="mt-5">（中央社東京26日綜合外電報導）日本藤田醫科大學今天表示，低濃度臭氧可中和新型冠狀病毒微粒，或許是醫院消毒診療室與候診區等的可行方法。這是全世界首度經實驗確認，低濃度臭氧也具有殺死新冠病毒效果。

                                藤田醫科大學科學家在線上記者會表示，他們首度證實對人體無害的0.05至0.1ppm（百萬分之一）低濃度臭氧，可殺死2019冠狀病毒疾病（COVID-19，武漢肺炎）病毒。
                                
                                這項實驗在一個內有新型冠狀病毒樣本的密閉空間使用臭氧生成機，當暴露在低濃度臭氧達10小時，病毒的活性銳減超過90%。</p>
                        </div>
                    </div>
                </div>
            </section>-->
    <div class="py-5 bg-light">
                <div class="container px-5 my-5">
                    <div class="row gx-5 justify-content-center">
                        <div class="col-lg-10 col-xl-7">
                            <div class="text-center">
                                <div class="fs-4 mb-4 fst-italic">臭氧水可以取代市售常見的消毒劑喔，而且抗菌範圍更廣，成分更天然，零殘留，刺激性極低 (幾乎無刺激性)，也不會累積瓶瓶罐罐的塑膠容器，天然又環保。<br>

<span style="color:blue;">「酒精」</span>：無法消滅病毒類，有刺激性，有可能破壞家具表面。<br>
<span style="color:blue;">「次氯酸水」</span>：滅菌速度比臭氧水慢 600倍，此外如果是品質不良的次氯酸水產品，濃度、安定性不夠，會影響抗菌效果。<br>
<span style="color:blue;">「漂白水」</span>：刺激性高，使用不當可能會傷害黏膜、皮膚及呼吸道。</div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <h2 class="fw-bolder text-center py-5 text-primary">酒精/次氯酸水/臭氧水的差異</h2>
            <hr>
            <table class="table container table-striped table-borderless table table-sm">
                <thead>
                  <tr>
                    <th scope="col"></th>
                    <th scope="col">酒精</th>
                    <th scope="col">次氯酸水</th>
                    <th scope="col">臭氧水</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <th scope="row">滅菌效率</th>
                    <td>高</td>
                    <td>中等</td>
                    <td>高</td>
                  </tr>
                  <tr>
                    <th scope="row">殺菌種類</th>
                    <td>酒精濃度在60-80%能有效殺死絕大多數細菌和包膜病毒。</td>
                    <td>可除去大部分病毒、黴菌、真菌和芽孢菌。</td>
                    <td>所有微生物種類皆有效，包含芽孢菌。</td>
                  </tr>
                  <tr>
                    <th scope="row">接觸時間</th>
                    <td>數秒</td>
                    <td>依滅殺菌種而異，數分鐘到數小時。</td>
                    <td>數秒</td>
                  </tr>
                  <tr>
                    <th scope="row">生物分解性</th>
                    <td>高</td>
                    <td>差</td>
                    <td>高</td>
                  </tr>
                  <tr>
                    <th scope="row">是否可保存</th>
                    <td>可保存</td>
                    <td>次氯酸水不安定，怕光、怕熱，殺菌效果會因時間而遞減還原。</td>
                    <td>靜止20分鐘後會氧化還原成普通水。</td>
                  </tr>
                  <tr>
                    <th scope="row">腐蝕性</th>
                    <td>酒精是個腐蝕性極強的消毒液體，長時間使用，有些金屬物品都會被酒精侵蝕。</td>
                    <td>對組織細胞有侵蝕性，形成三氯甲烷致癌嚴重問題。</td>
                    <td>高濃度臭氧(數百ppm)對鐵、不鏽鋼有腐蝕性。臭氧經過檢測水中濃度約為0.2ppm，有效除菌且不傷肌膚。</td>
                  </tr>
                  <tr>
                    <th scope="row">毒性</th>
                    <td>工業酒精含有甲醇，可透過皮膚進入人體而引致中毒。醫療用酒精為乙醇，可消毒殺菌。</td>
                    <td>對於鐵和鋁材質具有腐蝕性。</td>
                    <td>臭氧融合於水中，一般濃度下，毒性可忽略。</td>
                  </tr>
                  <tr>
                    <th scope="row">是否會殘留於食物</th>
                    <td>不可用於清洗食物。長期使用易造成皮膚發炎反應。</td>
                    <td>食品容器以及食材洗滌之用，在食材殘留不得超過1ppm。長期使用易造成皮膚發炎。</td>
                    <td>臭氧不會殘留於食物，適合清洗食材殺菌、除去農藥殘留。天然不傷肌膚。</td>
                  </tr>
                  <tr>
                    <th scope="row">對皮膚的影響</th>
                    <td>對醇類成分過敏的膚質與角質層偏薄的敏感肌膚較脆弱者較不適合。</td>
                    <td>次氯酸水是一種強氧化劑，對皮膚有刺激性。</td>
                    <td>臭氧水清潔肌膚，有效除菌且較不刺激肌膚。</td>
                  </tr>
                  <tr>
                    <th scope="row">特性</th>
                    <td>酒精會破壞生物磷脂雙分子構成的生物膜，造成生物膜結構和功能障礙造成死亡。</td>
                    <td>儲存期間短、穩定性差。有氯的味道及具漂白性質。</td>
                    <td>強氧化劑和殺菌劑，活性固然最好，但穩定差。臭氧不耐存放。打成微氣泡可增加水溶性。可除菌、除臭、保鮮、除農藥。</td>
                  </tr>
                  <tr>
                    <th scope="row">優缺點</th>
                    <td>醫療用酒精為乙醇，可有效消毒殺菌。</td>
                    <td>使用氯與漂白水等消毒，除具有氯氣之臭味外，更具有腐植酸等產生三氯甲烷致癌物質。</td>
                    <td>臭氧氧化後會分解成氧氣，沒什麼殘留物，是很大的優點。</td>
                  </tr>
                </tbody>
              </table>
            <section>
                
            <h2 class="fw-bolder text-center py-5 text-primary">臭氧電解水與空氣高壓放電分別</h2>
            <hr>
            <table class="table container table-striped table-borderless table table-sm">
                <thead>
                  <tr>
                    <th scope="col"></th>
                    <th scope="col">電解臭氧</th>
                    <th scope="col">高壓放電生成</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <th scope="row">原料</th>
                    <td>自來水</td>
                    <td>一般空氣</td>
                  </tr>
                  <tr>
                    <th scope="row">臭氧溶解濃度</th>
                    <td>較高</td>
                    <td>較低</td>
                  </tr>
                  <tr>
                    <th scope="row">溶水能力</th>
                    <td>高</td>
                    <td>極低(<5%)，形成高曝氣</td>
                  </tr>
                  <tr>
                    <th scope="row">副產物</th>
                    <td>氧氣,氫氣</td>
                    <td>NOx 硝酸氮致癌物質</td>
                  </tr>
                  <tr>
                    <th scope="row">優點</th>
                    <td>濃度較高,用途廣泛</td>
                    <td>生成容易,造價低</td>
                  </tr>
                </tbody>
              </table>
            </section>
            <!-- Blog preview section-->
            
            <div class="py-5 bg-light">
                <div class="container px-5 my-5">
                    <div class="row gx-5 justify-content-center">
                        <div class="col-lg-10 col-xl-7">
                            <div class="text-center">
                                <div class="fs-4 mb-4 fst-italic">臭氧直接與細菌、病毒作用，破壞它們的胞器和DNA、RNA，使細菌的新陳代謝受到破壞，導致細菌死亡。</div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>

