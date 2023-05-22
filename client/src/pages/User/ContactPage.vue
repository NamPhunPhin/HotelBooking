<template lang="">
  <div class="Contact">
    <div class="m-0">
      <!-- Map -->
      <div class="p-0 m-0">
        <iframe
          src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.7347384755294!2d106.6847209239447!3d10.754915259592359!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f0570be0adb%3A0x4415c64da6a9bd39!2zNjEwIFbDtSBWxINuIEtp4buHdCwgQ-G6p3UgS2hvLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaWV0bmFt!5e0!3m2!1sen!2s!4v1684158384855!5m2!1sen!2s"
          width="800"
          height="600"
          style="border: 0; width: 100%; padding: 0"
          allowfullscreen=""
          loading="lazy"
          referrerpolicy="no-referrer-when-downgrade"
        ></iframe>
      </div>
<<<<<<< HEAD
      <div class="form-bg">
        <h5><b>Lisa Co.,Ltd</b></h5>
        <p class="mb-1 p-0">
          Tầng 5, 610 Võ Văn Kiệt, Phường Cầu Kho, Quận 1, Tp.HCM
        </p>
        <p class="mb-1 p-0">[P]: (08) 2244 7799</p>
        <p class="p-0">[E]: info@lisa.com.vn</p>
        <form class="form mt-1">
          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="Name"
              placeholder="Name"
              required
            />
            <label for="Name" class="form-label">Name</label>
=======
      <!-- Message Us -->
      <div class="row mt-5 p-5 w-100">
        <div class="col-md text-center" style="font-family: var(--font-Anton)">
          <h1 class="mb-5 mt-5">FAQ</h1>
          <div class="text-start FAQ">
            <p class="mb-3">
              <a href="">Trong trường hợp cần phòng gấp, tôi phải làm gì ?</a>
            </p>
            <p class="mb-3">
              <a href=""
                >Đặt phòng đặt trực tiếp khách sạn và thông qua các trang đặt
                phòng thì khác nhau thế nào?</a
              >
            </p>
            <p class="mb-3">
              <a href=""
                >Khách sạn có áp dụng các mức giảm giá cho khách đoàn hay không
                ?</a
              >
            </p>
            <p class="mb-3">
              <a href=""
                >Khách sạn có cho phép mang thú nuôi vào phòng hay không ?</a
              >
            </p>
            <p class="mb-3">
              <a href="">Thông tin cá nhân của tôi có được giữ kín không?</a>
            </p>
            <p class="mb-3">
              <a href="">Khách sạn có cho trả phòng trễ hay không ?</a>
            </p>
>>>>>>> f103b8e9e3779e811acc7874fb056115c15cef68
          </div>
        </div>
        <div class="col-md">
          <div class="form-bg">
            <h1 class="mb-5">Message Us</h1>
            <form class="form align-items-center">
              <div class="row w-100">
                <div class="col-md-6">
                  <div class="form-floating mb-3">
                    <input
                      type="text"
                      class="form-control w-100"
                      id="FName"
                      v-model="FName"
                      placeholder="First Name"
                      required
                    />
                    <label for="Name" class="form-label">First Name</label>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-floating mb-3">
                    <input
                      type="text"
                      class="form-control w-100"
                      id="LName"
                      v-model="LName"
                      placeholder="Last Name"
                      required
                    />
                    <label for="Name" class="form-label">Last Name</label>
                  </div>
                </div>
              </div>
              <div class="form-floating mb-3">
                <input
                  type="email"
                  class="form-control"
                  id="Email"
                  placeholder="Email"
                  v-model="Email"
                  required
                />
                <label for="Email" class="form-label">Email</label>
              </div>
              <div class="form-floating mb-3">
                <input
                  type="text"
                  class="form-control"
                  id="Subject"
                  placeholder="Subject"
                  v-model="Subject"
                  required
                />
                <label for="Subject" class="form-label">Subject</label>
              </div>
              <div class="form-floating mb-3">
                <textarea
                  class="form-control"
                  placeholder="Massage"
                  v-model="Message"
                  id="Message"
                  style="height: 100px"
                  required
                ></textarea>
                <label for="Message">Message</label>
              </div>
              <div class="mb-3 d-inline-block">
                <input
                  type="submit"
                  class="btn btn-primary"
                  value="Send message"
                />
              </div>
            </form>
          </div>
        </div>
      </div>
      <!-- Info Contact -->
      <div class="info-contact">
        <div class="bg_info text-center">
          <h1 class="mb-5 pb-5">CONTACT US</h1>
          <div class="row justify-content-between w-100 m-0">
            <div class="col-md-2 p-0 info text-center Phone">
              <div class="icon"><i class="fa-solid fa-phone fa-2xl"></i></div>
              <h5>Phone</h5>
              <p>(08) 2244 7799</p>
            </div>
            <div class="col-md-3 p-0 info text-center Address">
              <div class="icon">
                <i class="fa-solid fa-location-dot fa-2xl"></i>
              </div>
              <h5>Address</h5>
              <p>
                Tầng 5, 610 Võ Văn Kiệt,<br />
                Phường Cầu Kho, Quận 1, Tp.HCM
              </p>
            </div>
            <div class="col-md-2 p-0 info text-center Email">
              <div class="icon">
                <i class="fa-solid fa-envelope fa-2xl"></i>
              </div>
              <h5>Email</h5>
              <p>info@lisa.com.vn</p>
            </div>
          </div>
<<<<<<< HEAD
          <div class="form-floating mb-3">
            <textarea
              class="form-control text-area"
              placeholder="Massage"
              id="Message"
              style="height: 100px"
              required
            ></textarea>
            <label for="Message">Message</label>
          </div>
          <div class="mb-3">
            <input type="submit" class="btn btn-primary" value="Send message" />
          </div>
        </form>
=======
        </div>
>>>>>>> f103b8e9e3779e811acc7874fb056115c15cef68
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "ContactPage",
  data() {
    return {
      dataForm: {
        FName: "",
        LName: "",
        Email: "",
        Subject: "",
        Message: "",
      },
    };
  },
};
</script>
<style>
.Contact {
  width: 100%;
}

.text-area {
  width: 400px !important;
}

input[type="submit"] {
  width: 150px !important;
  background-color: var(--main-Color);
  border: none;
}

input[type="submit"]:hover {
  background: var(--gray-Color);
}

.form {
  display: inline-block !important;
  text-align: center;
  padding: 10px;
  font-family: var(--font-Anton);
  background: var(--custom-Color);
}

.form-bg {
<<<<<<< HEAD
  position: absolute;
  transform: translate(900px, -600px);
  background: var(--custom-Color);
  padding: 20px;
  font-family: var(--font-Anton);
}

/* Reponsive form */
@media screen and (max-width: 767px) {
  .form-bg {
    position: relative;
    transform: translate(0px, 0px);
  }
=======
  padding: 40px;
  text-align: center;
}

.info-contact {
  padding: 150px;
  background-image: url(../../../public/images/bg_InfoContact.jpg);
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
  color: var(--custom-Color);
}

.info {
  font-family: var(--font-Anton);
}

.icon {
  display: inline-block;
  text-align: center;
  padding: 15px;
  width: 60px;
  height: 60px;
}

.bg_info {
  padding: 20px;
  background-color: rgba(0, 0, 0, 0.692);
}

.FAQ a {
  color: black;
}

.FAQ a:hover {
  color: var(--main-Color);
>>>>>>> f103b8e9e3779e811acc7874fb056115c15cef68
}
</style>
