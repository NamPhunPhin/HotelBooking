<template lang="">
  <div class="InfoUser">
    <div class="Process-Partner">
      <div class="Partner-Info-Register">
        <i class="fa-solid fa-user-tie"></i>
      </div>

      <div
        :class="
          isProcessNumber == 1 ? 'Process-Line Process-None' : 'Process-Line'
        "
      ></div>

      <div
        :class="
          isProcessNumber == 1
            ? 'Partner-Info-Hotel Process-None'
            : 'Partner-Info-Hotel'
        "
      >
        <i class="fa-solid fa-credit-card"></i>
      </div>

      <div
        :class="
          isProcessNumber != 3 ? 'Process-Line Process-None' : 'Process-Line'
        "
      ></div>

      <div
        :class="
          isProcessNumber != 3
            ? 'Partner-Success Process-None'
            : 'Partner-Success'
        "
      >
        <i class="fa-solid fa-circle-check"></i>
      </div>
    </div>

    <div class="user" v-if="isProcessNumber == 1">
      <div class="card shadow border-0 m-2" v-show="getUser != null">
        <div class="row g-0">
          <div class="col-md-1 text-center pt-3 bg-primary">
            <i
              class="fa-regular fa-circle-user fa-xl text-center text-white"
            ></i>
          </div>
          <div class="col-md-11">
            <div class="card-body p-3">
              <p class="card-title text-primary m-0">
                Xin chào {{ getUser != null ? getUser.last_name + " " + getUser.first_name : '' }}!
                (không phải là
                {{ getUser != null ? getUser.last_name + " " + getUser.first_name : '' }}? Thoát)
              </p>
            </div>
          </div>
        </div>
      </div>
      <div class="card shadow border-0 m-2">
        <div class="card-body">
          <h5 class="card-title mb-3">Thông tin liên lạc</h5>
          <div class="mb-3">
            <label for="name" class="form-label"
              >Họ và tên như trong hộ chiếu <span>*</span></label
            >
            <input
              type="text"
              class="form-control"
              id="name"
              :value="
                getUser != null
                  ? getUser.last_name + ' ' + getUser.first_name
                  : ''
              "
              :disabled="getUser != null"
            />
          </div>
          <div class="mb-3">
            <label for="email" class="form-label">Email <span>*</span></label>
            <input
              type="text"
              class="form-control"
              id="email"
              :value="getUser != null ? getUser.email : ''"
              :disabled="getUser != null"
            />
          </div>
          <div class="row">
            <div class="mb-3 col-6">
              <label for="phone" class="form-label"
                >Số điện thoại (không bắt buộc)</label
              >
              <input type="text" class="form-control" id="phone" />
            </div>
            <div class="mb-3 col-6">
              <label for="address" class="form-label"
                >Địa chỉ <span>*</span></label
              >
              <input
                type="text"
                class="form-control"
                id="address"
                :value="getUser != null ? getUser.address : ''"
                :disabled="getUser != null"
              />
            </div>
          </div>
          <div class="form-check mb-3">
            <input
              class="form-check-input"
              type="checkbox"
              value=""
              id="placeforother"
              v-model="placeforother"
            />
            <label class="form-check-label" for="placeforother">
              Đặt phòng này cho người khác
            </label>
          </div>
          <div class="card border-0 m-2 gray" v-show="placeforother == true">
            <div class="card-body">
              <h5 class="card-title mb-3">Thông tin khách hàng</h5>
              <div class="mb-3">
                <label for="name" class="form-label"
                  >Họ và tên như trong hộ chiếu</label
                >
                <input type="text" class="form-control" id="name" />
              </div>
              <div class="mb-3">
                <label for="address" class="form-label">Địa chỉ</label>
                <input type="text" class="form-control" id="address" />
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="card shadow border-0 m-2">
        <div class="card-body">
          <h5 class="card-title">Ưu đãi nâng cấp phòng</h5>
          <p>Tiện ích giảm giá cho chuyến đi của bạn</p>
          <div class="row gray p-3">
            <div class="col-1">
              <img src="../../public/images/breakfast.svg" class="w-100" />
            </div>
            <div class="col-7">
              <p class="m-0">
                <b>Bữa sáng </b>
                <span class="badge bg-success text-light">Đã bao gồm</span>
              </p>
              <p class="m-0">
                Ưu đãi phòng của quý khách gồm cả ăn sáng, không phụ thu.
              </p>
            </div>
            <div class="col-2 text-center p-2">
              <h5 class="text-success">MIỄN PHÍ</h5>
            </div>
            <div class="col-2">
              <button class="btn text-black-50" disabled="disabled">
                Đã thêm
              </button>
            </div>
          </div>
        </div>
      </div>
      <div class="card shadow border-0 m-2">
        <div class="card-body">
          <h5 class="card-title">Hãy cho chúng tôi biết quý khách cần gì</h5>
          <p>
            Các yêu cầu còn lệ thuộc vào khả năng cung cấp. Chúng tôi sẽ gửi các
            yêu cầu của quý khách ngay sau khi quý khách đặt phòng.
          </p>
          <div class="card border-0 m-2 gray">
            <div class="card-body">
              <p>Quy định hút thuốc (nếu có phòng):</p>
              <div class="form-check form-check-inline me-5">
                <input
                  class="form-check-input"
                  type="radio"
                  name="smoke"
                  id="Banned"
                  value="False"
                />
                <label class="form-check-label" for="Banned">
                  <i class="fa-solid fa-ban-smoking"></i> Phòng không hút thuốc
                </label>
              </div>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="radio"
                  name="smoke"
                  id="Allow"
                  value="True"
                />
                <label class="form-check-label" for="Allow">
                  <i class="fa-solid fa-smoking"></i> Phòng hút thuốc
                </label>
              </div>
              <p class="mt-3">Chọn loại giường (nếu có phòng):</p>
              <div class="form-check form-check-inline me-5">
                <input
                  class="form-check-input"
                  type="radio"
                  name="bed"
                  id="Couple"
                  value="Couple"
                />
                <label class="form-check-label" for="Couple">
                  <i class="fa-solid fa-bed"></i> Tôi muốn lấy giường lớn
                </label>
              </div>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="radio"
                  name="bed"
                  id="Single"
                  value="Single"
                />
                <label class="form-check-label" for="Single">
                  <i class="fa-solid fa-bed"></i>
                  <i class="fa-solid fa-bed"></i> Tôi muốn lấy phòng 2 giường
                </label>
              </div>
            </div>
          </div>
          <p
            class="btn text-primary"
            v-on:click="AddRemov()"
            v-show="Addoption == false"
          >
            <i class="fa-solid fa-plus"></i> <u>Thêm yêu cầu đặc biệt</u>
          </p>
          <p
            class="btn text-primary"
            v-on:click="AddRemov()"
            v-show="Addoption == true"
          >
            <i class="fa-solid fa-minus"></i> <u>Thêm yêu cầu đặc biệt</u>
          </p>
          <div class="card border-1 m-2" v-show="Addoption == true">
            <div class="card-body">
              <p>
                Vui lòng lưu ý tất cả các yêu cầu chỉ được đáp ứng tùy theo
                khách sạn.
              </p>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="highroom"
                />
                <label class="form-check-label" for="highroom">
                  Tôi muốn lấy phòng tầng cao
                </label>
              </div>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="forchild"
                />
                <label class="form-check-label" for="forchild">
                  Tôi muốn lấy phòng có nôi trẻ em
                </label>
              </div>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="quiteroom"
                />
                <label class="form-check-label" for="quiteroom">
                  Tôi muốn lấy phòng yên tĩnh
                </label>
              </div>
              <hr class="m-1" />
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="forchild"
                />
                <label class="form-check-label" for="forchild">
                  Tôi muốn đăng ký đưa đón sân bay
                </label>
              </div>
              <hr class="m-1" />
              <p>
                Vui lòng nhập lời nhắn bằng <b>Tiếng Anh</b> hoặc
                <b>Tiếng Việt</b>
              </p>
              <div class="">
                <textarea class="form-control" id="message" rows="3"></textarea>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="card shadow border-0 m-2">
        <div class="card-body">
          <h5 class="card-title text-capitalize">
            <i class="fa-solid fa-gift text-primary"></i> Phần thưởng
          </h5>
          <div class="card border-0 m-2 gray rounded">
            <div class="card-body">
              <div class="row">
                <div class="col-1">
                  <h4><i class="fa-solid fa-hand-holding-dollar"></i></h4>
                </div>
                <div class="col-9">
                  <p class="m-0">
                    <b>Được Cashback </b>
                    <span class="badge bg-success text-light">Đã bao gồm</span>
                  </p>
                  <p class="m-0">
                    Phần thưởng Hoàn tiền mặt của quý khách sẽ được đủ tiêu
                    chuẩn 60 ngày sau ngày trả phòng, và quý khách có tối đa 120
                    ngày để yêu cầu. Một thư điện tử sẽ được gửi cho quý khách
                    để điền thẻ tín dụng/ghi nợ mà quý khách muốn nhận được phần
                    thưởng.
                  </p>
                  <p class="m-0">
                    Xin lưu ý rằng bên xử lý thanh toán sẽ tính phí 1.05 USD với
                    những yêu cầu ít hơn 10 USD.
                  </p>
                  <p class="m-0">
                    Xem <b class="text-primary">Điều khoản và điều kiện</b>
                  </p>
                </div>
                <div class="col-2 text-center pt-5">
                  <p><b>78.738 ₫</b> Cashback</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="card shadow border-0 m-2">
        <div class="card-body">
          <p class="h6">
            Thực hiện bước tiếp theo đồng nghĩa với việc bạn chấp nhận tuân theo
            <span class="text-primary">Điều khoản sử dụng</span> và
            <span class="text-primary">Chính sách bảo mật</span> của Agoda.
          </p>
          <p class="text-end text-danger">
            Nhanh lên! Phòng cuối cùng của chúng tôi ở mức giá này cho ngày bạn
            chọn
          </p>
          <button
            class="btn shadow checknext"
            type="button"
            v-on:click="NextHandleClick()"
          >
            KẾ TIẾP : BƯỚC CUỐI CÙNG
          </button>
          <br />
          <p class="text-end text-success">
            <b>Có liền xác nhận đặt phòng!</b>
          </p>
        </div>
      </div>
    </div>

    <div class="payment" v-if="isProcessNumber == 2">
      <div class="card">
        <div class="card-header shadow">
          <p class="m-0">
            <span class="text-primary"
              ><i class="fa-solid fa-shield"></i>
              <b>Thanh toán an toàn</b></span
            >
            | Tất cả thông tin thẻ đều được mã hóa hoàn toàn, an toàn và được
            bảo vệ.
          </p>
        </div>
        <div class="card-body shadow">
          <div :class="credit == 1 ? 'card border-primary' : 'card'">
            <div
              :class="
                credit == 1
                  ? 'card-header bg-primary text-white'
                  : 'card-header unactive text-primary'
              "
            >
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="radio"
                  name="payment"
                  id="Credit"
                  v-model="credit"
                  value="1"
                />
                <label class="form-check-label" for="Credit">
                  THẺ TÍN DỤNG/GHI NỢ
                </label>
                <div class="d-inline ms-5">
                  <img
                    class="img-payment p-1"
                    src="../../public/images/visa.png"
                    alt=""
                  />
                  <img
                    class="img-payment p-1"
                    src="../../public/images/master.png"
                    alt=""
                  />
                  <img
                    class="img-payment p-1"
                    src="../../public/images/americanexpress.png"
                    alt=""
                  />
                  <img
                    class="img-payment p-1"
                    src="../../public/images/jcb.png"
                    alt=""
                  />
                  <img
                    class="img-payment p-1"
                    src="../../public/images/unionpay.png"
                    alt=""
                  />
                </div>
              </div>
            </div>
            <div class="card-body" v-show="credit == 1">
              <label class="form-label" for="creditcard"
                >Hình thức thanh toán *</label
              >
              <select class="form-select" id="creditcard">
                <option selected>Visa / MasterCard / Amex / JCB</option>
                <option value="1">UnionPay - CreditCard</option>
              </select>
              <div class="row">
                <div class="col-6">
                  <div class="mb-3">
                    <label for="namecard" class="form-label"
                      >Tên trên thẻ *</label
                    >
                    <input type="text" class="form-control" id="namecard" />
                  </div>
                  <div class="mb-3">
                    <label for="numbercard" class="form-label"
                      >Số thẻ tín dụng/thẻ ghi nợ *</label
                    >
                    <input type="text" class="form-control" id="numbercard" />
                  </div>
                  <div class="row">
                    <div class="col-6">
                      <div class="mb-3">
                        <label for="datecard" class="form-label"
                          >Ngày hết hạn *</label
                        >
                        <input
                          type="text"
                          class="form-control"
                          id="datecard"
                          maxlength="5"
                        />
                      </div>
                    </div>
                    <div class="col-6">
                      <div class="mb-3">
                        <label for="passcard" class="form-label"
                          >Mã bảo mật CVC *</label
                        >
                        <input
                          type="password"
                          class="form-control"
                          id="passcard"
                          maxlength="3"
                        />
                      </div>
                    </div>
                  </div>
                </div>
                <div class="col-6 SimuCard p-0">
                  <p class="numbercard">**** **** **** ****</p>
                </div>
              </div>
            </div>
          </div>
          <div :class="credit == 2 ? 'card border-primary' : 'card'">
            <div
              :class="
                credit == 2
                  ? 'card-header bg-primary text-white'
                  : 'card-header unactive text-primary'
              "
            >
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="radio"
                  name="payment"
                  id="Credit"
                  v-model="credit"
                  value="2"
                />
                <label class="form-check-label" for="Credit">
                  THANH TOÁN ĐIỆN TỬ
                </label>
                <div class="d-inline ms-5">
                  <img
                    class="img-payment p-1"
                    src="../../public/images/momo.png"
                    alt=""
                  />
                  <img
                    class="img-payment p-1"
                    src="../../public/images/paypal.png"
                    alt=""
                  />
                </div>
              </div>
            </div>
            <div class="card-body" v-show="credit == 2">
              <label class="form-label" for="creditcard"
                >Hình thức thanh toán *</label
              >
              <select class="form-select" id="creditcard">
                <option selected value="0">Momo</option>
                <option value="1">Paypal</option>
              </select>
              <ul class="mt-2">
                <li>
                  Quý khách đã chọn thanh toán bằng MoMo. Quý khách sẽ được
                  chuyển đến website MoMo để tiến hành giao dịch này.
                </li>
                <li>Tổng số tiền bạn phải trả là: 936.198 ₫</li>
              </ul>
            </div>
          </div>
          <div :class="credit == 3 ? 'card border-primary' : 'card'">
            <div
              :class="
                credit == 3
                  ? 'card-header bg-primary text-white'
                  : 'card-header unactive text-primary'
              "
            >
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="radio"
                  name="payment"
                  id="Credit"
                  v-model="credit"
                  value="3"
                />
                <label class="form-check-label" for="Credit">
                  THANH TOÁN HÀNG THÁNG
                </label>
                <div class="d-inline ms-5">
                  <img
                    class="img-payment p-1"
                    src="../../public/images/affirm.png"
                    alt=""
                  />
                </div>
              </div>
            </div>
            <div class="card-body" v-show="credit == 3">
              <label class="form-label" for="creditcard"
                >Hình thức thanh toán *</label
              >
              <select class="form-select" id="creditcard">
                <option selected>Affirm</option>
              </select>
              <ul class="mt-2">
                <li>
                  Affirm giúp quý khách dễ dàng Đặt Ngay và Thanh Toán Theo Thời
                  Gian
                </li>
                <li>
                  Quý khách sẽ được chuyển hướng sang Affirm để hoàn tất thanh
                  toán
                </li>
              </ul>
            </div>
          </div>
          <div :class="credit == 4 ? 'card border-primary' : 'card'">
            <div
              :class="
                credit == 4
                  ? 'card-header bg-primary text-white'
                  : 'card-header unactive text-primary'
              "
            >
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="radio"
                  name="payment"
                  id="Credit"
                  v-model="credit"
                  value="4"
                />
                <label class="form-check-label" for="Credit">
                  Thẻ ATM nội địa
                </label>
                <div class="d-inline ms-5">
                  <img
                    class="img-payment p-1"
                    src="../../public/images/atmcard.png"
                    alt=""
                  />
                </div>
              </div>
            </div>
            <div class="card-body" v-show="credit == 4">
              <label class="form-label" for="creditcard"
                >Hình thức thanh toán *</label
              >
              <select class="form-select" id="creditcard">
                <option selected>Domestic ATM Card</option>
              </select>
              <ul class="mt-2">
                <li>
                  Thẻ của quý khách phải do một ngân hàng ở Việt Nam phát hành
                </li>
                <li>
                  Hướng dẫn thanh toán sẽ được cung cấp trong trang tiếp theo.
                </li>
                <li>
                  Quý khách đã chọn thanh toán bằng Domestic ATM Card. Quý khách
                  sẽ được chuyển đến website Domestic ATM Card để tiến hành giao
                  dịch này.
                </li>
                <li>Tổng số tiền bạn phải trả là: 39,59 $</li>
              </ul>
            </div>
          </div>
          <div class="form-check mb-5">
            <input
              class="form-check-input"
              type="checkbox"
              value=""
              id="flexCheckDefault"
              checked
            />
            <label class="form-check-label" for="flexCheckDefault">
              Nhận email khuyến mãi độc quyền từ Agoda. Tôi có thể bỏ đăng ký
              này về sau như đã nêu trong Chính Sách Bảo Mật.
            </label>
          </div>
          <p class="h6 m-0">
            Thực hiện bước tiếp theo đồng nghĩa với việc bạn chấp nhận tuân theo
            <span class="text-primary">Điều khoản sử dụng</span> và
            <span class="text-primary">Chính sách bảo mật</span> của Agoda.
          </p>
          <button
            class="btn shadow checknext mt-1"
            type="button"
            v-on:click="NextHandleClick()"
          >
            <i class="fa-solid fa-lock"></i> ĐẶT PHÒNG
          </button>
        </div>
        <div class="card-footer shadow" v-show="getUser != null">
          <p class="m-0 p-2">
            <i class="fa-solid fa-envelope-circle-check"></i> Chúng tôi sẽ gởi
            xác nhận đặt phòng của bạn đến <b>{{getUser!=null ? getUser.email : ''}}</b>
          </p>
        </div>
      </div>

      <button
        class="btn checknext mt-4"
        type="button"
        v-on:click="PreviousHandleClick()"
      >
        Quay lại trang thông tin người dùng
      </button>
    </div>
  </div>
</template>
<script>
import { mapGetters } from "vuex";

export default {
  name: "InfoUserComponent",
  data() {
    return {
      credit: "1",
      isProcessNumber: 1,
      Addoption: false,
      placeforother: false,
    };
  },

  methods: {
    AddRemov() {
      this.Addoption = !this.Addoption;
    },
    NextHandleClick() {
      this.isProcessNumber = this.isProcessNumber + 1;
    },
    PreviousHandleClick() {
      this.isProcessNumber = this.isProcessNumber - 1;
    },
    SendHandleClick() {
      console.log(this.MerchantData);
    },
  },

  computed: {
    ...mapGetters("Auth", ["getUser", "getAuthStatus"]),
  },
};
</script>
<style scoped>
.InfoUser {
  width: 100%;
}

.card {
  border-radius: 0px;
}

.h6 {
  font-size: 13px;
}

.checknext {
  background: var(--main-Color);
  font-weight: 500;
  font-size: 16px;
  color: white;
  padding: 10px 75px;
  transition: 0.2s;
}

.checknext:hover {
  opacity: 80%;
}

textarea {
  border-radius: 0px;
}

.gray {
  background: rgba(204, 203, 203, 0.13);
}

.Process-Partner {
  display: flex;
  justify-content: space-between;
  align-items: center;
  text-align: center;
  margin-bottom: 20px;
}

.Partner-Info-Register {
  width: 5%;
  background: #3493ece3;
  padding: 10px;
  border-radius: 50%;
  position: relative;
}

.Partner-Info-Register > div {
  position: absolute;
}

.Partner-Success {
  width: 5%;
  background: #3493ece3;
  padding: 10px;
  border-radius: 50%;
}

.Partner-Info-Hotel {
  width: 5%;
  background: #3493ece3;
  padding: 10px;
  border-radius: 50%;
}

.Partner-Success > i {
  font-size: 20px;
  color: white;
}

.Partner-Info-Hotel > i {
  font-size: 20px;
  color: white;
}

.Partner-Info-Register > i {
  font-size: 20px;
  color: white;
}

.Process-Line {
  width: 45%;
  height: 5px;
  background: #3493ece3;
}

.Process-None {
  background: lightgrey !important;
}

.card-header {
  border-radius: 0%;
}

.unactive {
  background: #6dacff75;
}

.img-payment {
  height: 32px;
}

.SimuCard {
  margin-top: 15px;
  height: 250px;
  border-radius: 15px;
  background: #8d8d8d86;
}

.numbercard {
  font-size: 30px;
  margin-top: 25px;
  margin-bottom: 0px;
  text-align: center;
  background: #fff7f7d3;
  color: #fff7f700;
}
</style>
