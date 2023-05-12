<template lang="">
  <div class="footer">
    <div class="container">
      <div class="text_policy mb-5 text-white">
        <p>
          Mọi nội dung tại đây © 2005 – 2023 Công ty TNHH Tư nhân Agoda. Bảo Lưu
          Mọi Quyền.
        </p>
        <p>
          Agoda.com là thành viên của Tập đoàn Booking Holdings, nhà cung cấp
          dịch vụ du lịch trực tuyến & các dịch vụ có liên quan hàng đầu thế
          giới.
        </p>
      </div>
      <div class="logo row">
        <div class="col-sm-2"><div class="logo1"></div></div>
        <div class="col-sm-2"><div class="logo2"></div></div>
        <div class="col-sm-2"><div class="logo3"></div></div>
        <div class="col-sm-2"><div class="logo4"></div></div>
        <div class="col-sm-2"><div class="logo5"></div></div>
        <div class="col-sm-2"><div class="logo6"></div></div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "FooterComponent",
};
</script>
<style>
:root {
  --bgFooter: #2e2e2e;
}

.footer {
  width: 100%;
  padding: 50px;
  background: var(--bgFooter);
}

.logo {
  text-align: center;
}

.logo1 {
  background-repeat: no-repeat;
  display: inline-block;
  background-image: url(../../public/images/logo_colab_footer.png);
  width: 144px;
  height: 48px;
  background-position: 0px -90px;
}

.logo2 {
  background-repeat: no-repeat;
  display: inline-block;
  background-image: url(../../public/images/logo_colab_footer.png);
  width: 144px;
  height: 48px;
  background-position: -144px -148px;
}

.logo3 {
  background-repeat: no-repeat;
  display: inline-block;
  background-image: url(../../public/images/logo_colab_footer.png);
  width: 144px;
  height: 48px;
  background-position: 0px -148px;
}

.logo4 {
  background-repeat: no-repeat;
  display: inline-block;
  background-image: url(../../public/images/logo_colab_footer.png);
  width: 144px;
  height: 48px;
  background-position: -288px -148px;
}

.logo5 {
  background-repeat: no-repeat;
  display: inline-block;
  background-image: url(../../public/images/logo_colab_footer.png);
  width: 144px;
  height: 48px;
  background-position: -288px -90px;
}

.logo6 {
  background-repeat: no-repeat;
  display: inline-block;
  background-image: url(../../public/images/logo_colab_footer.png);
  width: 144px;
  height: 48px;
  background-position: 0px -90px;
}

.text_policy p {
  text-align: center;
  margin-bottom: 5px;
}
</style>
