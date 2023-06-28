<template>
  <div class="Partner-Wrapper">
    <div class="Title">Trở thành đối tác</div>
    <div class="Merchant-Form">
      <div class="Process-Partner" v-if="isProcessNumber != 3">
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
          <i class="fa-solid fa-hotel"></i>
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

      <div class="Input-Merchant" v-if="isProcessNumber == 1">
        <div for="">Tên</div>
        <div class="Input-Field">
          <input
            type="text"
            placeholder="Tên"
            v-model="MerchantData.merchantName"
          />
        </div>
      </div>

      <div class="Input-Merchant" v-if="isProcessNumber == 1">
        <div for="">Email</div>
        <div class="Input-Field">
          <input
            type="text"
            placeholder="Email"
            v-model="MerchantData.merchantEmail"
          />
        </div>
      </div>

      <div class="Input-Merchant" v-if="isProcessNumber == 1">
        <div for="">Số điện thoại</div>
        <div class="Input-Field">
          <input
            type="text"
            placeholder="Số điện thoại"
            v-model="MerchantData.merchantPhone"
          />
        </div>
      </div>

      <div class="Input-Merchant" v-if="isProcessNumber == 1">
        <div for="">Địa chỉ</div>
        <div class="Input-Field">
          <input
            type="text"
            placeholder="Địa chỉ"
            v-model="MerchantData.merchantAddress"
          />
        </div>
      </div>

      <div class="Input-Merchant" v-if="isProcessNumber == 2">
        <div for="">Tên khách sạn</div>
        <div class="Input-Field">
          <input
            type="text"
            placeholder="Tên khách sạn"
            v-model="MerchantData.hotelName"
          />
        </div>
      </div>

      <div class="Input-Merchant" v-if="isProcessNumber == 2">
        <div for="">Địa chỉ khách sạn</div>
        <div class="Input-Field">
          <input
            type="text"
            placeholder="Địa chỉ khách sạn"
            v-model="MerchantData.hotetAddress"
          />
        </div>
      </div>

      <div class="Group-Merchant">
        <div class="Input-Merchant" v-if="isProcessNumber == 2">
          <div for="">Quốc gia</div>
          <div class="Input-Field">
            <select name="" id="" v-model="MerchantData.hotelCountryId">
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
            </select>
          </div>
        </div>

        <div class="Input-Merchant" v-if="isProcessNumber == 2">
          <div for="">Thành phố / Tỉnh thành</div>
          <div class="Input-Field">
            <select name="" id="" v-model="MerchantData.hotelCityId">
              <option value="1">1</option>
              <option value="2">2</option>
              <option value="3">3</option>
            </select>
          </div>
        </div>
      </div>

      <div class="Input-Merchant" v-if="isProcessNumber == 2">
        <div for="">Mô tả khách sạn</div>
        <div class="Input-Field">
          <textarea
            name=""
            id=""
            cols="30"
            rows="10"
            v-model="MerchantData.hotelDesc"
          ></textarea>
        </div>
      </div>

      <div class="Success-Merchant" v-if="isProcessNumber == 3">
        <img src="/images/success.gif" alt="" />
        <div>
          Đã gửi yêu cầu thành công, bạn hãy đợi chúng tôi duyệt yêu cầu cho bạn
          !
        </div>
      </div>

      <div class="Button-Merchant">
        <button
          @click="PreviousHandleClick()"
          class="btn-back"
          v-if="isProcessNumber == 2"
        >
          Trở về
        </button>
        <button
          @click="
            () => (isProcessNumber == 2 ? SendHandleClick() : NextHandleClick())
          "
          v-if="isProcessNumber != 3"
        >
          {{ isProcessNumber != 2 ? "Tiếp theo" : "Gửi yêu cầu" }}
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "PartnerComponent",
  data() {
    return {
      isProcessNumber: 3,
      MerchantData: {
        merchantName: "",
        merchantEmail: "",
        merchantPhone: "",
        merchantAddress: "",
        hotelName: "",
        hotelDesc: "",
        hotetAddress: "",
        hotelCountryId: "",
        hotelCityId: "",
      },
    };
  },
  methods: {
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
};
</script>

<style>
.Partner-Wrapper > .Title {
  font-size: 20px;
  font-weight: 600;
}

.Partner-Wrapper > .Merchant-Form {
  display: flex;
  flex-direction: column;
  background: white;
  padding: 20px;
  border-radius: 10px;
  margin: 20px 0;
}

.Merchant-Form > .Input-Merchant {
  margin: 5px 0;
}

.Merchant-Form > .Input-Merchant > .Input-Field {
  background: rgba(0, 0, 0, 0.05);
  padding: 5px;
  border-radius: 10px;
  margin: 10px 0;
}

.Input-Merchant > div {
  font-size: 16px;
  font-weight: bold;
}

.Input-Merchant > .Input-Field > input {
  background: transparent;
  width: 100%;
  font-size: 15px !important;
  border: none;
}

.Input-Merchant > .Input-Field > textarea {
  padding: 10px;
  font-size: 20px;
  font-weight: bold;
  background: transparent;
  width: 100%;
  font-size: 15px !important;
  border: none;
}

.Input-Merchant > .Input-Field > select {
  padding: 10px;
  font-size: 20px;
  font-weight: bold;
  background: transparent;
  font-size: 15px !important;
  border: none;
}

.Input-Merchant > .Input-Field > textarea:focus {
  outline: none;
}

.Input-Merchant > input:focus {
  outline: none;
}

.Button-Merchant {
  text-align: right;
  margin: 10px 0;
}

.Button-Merchant > .btn-back {
  background: none;
  border: none;
  color: var(--main-Color);
  margin: 0 5px;
}

.Button-Merchant > button {
  background: var(--main-Color);
  border: 2px solid var(--main-Color);
  padding: 5px 10px;
  font-size: 15px;
  font-weight: 600;
  border-radius: 10px;
  color: white;
  margin: 0 5px;
}

.Button-Merchant > button:hover {
  background: transparent;
  color: var(--main-Color);
}

.Process-Partner {
  display: flex;
  justify-content: space-between;
  align-items: center;
  text-align: center;
  margin-bottom: 20px;
}

.Partner-Info-Register {
  width: 10%;
  background: #77b43f;
  padding: 10px;
  border-radius: 5px;
  position: relative;
}

.Partner-Info-Register > div {
  position: absolute;
}

.Partner-Success {
  width: 10%;
  background: #77b43f;
  padding: 10px;
  border-radius: 5px;
}

.Partner-Info-Hotel {
  width: 10%;
  background: #77b43f;
  padding: 10px;
  border-radius: 5px;
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
  width: 35%;
  height: 5px;
  background: #77b43f;
}

.Process-None {
  background: lightgrey !important;
}

.Group-Merchant {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
}

.Group-Merchant > .Input-Merchant {
  width: 100%;
}

.Group-Merchant > .Input-Merchant > .Input-Field {
  margin: 10px 0 !important;
}

.Group-Merchant > .Input-Merchant > .Input-Field > select {
  width: 99%;
  cursor: pointer;
}

.Group-Merchant > .Input-Merchant > .Input-Field > select:focus {
  outline: none;
}

.Success-Merchant {
  align-self: center;
  margin: 30px 0;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 2rem;
}

.Success-Merchant > div {
  font-size: 20px;
  color: #77b43f;
  font-weight: bold;
  text-align: center;
}

.Success-Merchant > img {
  width: 200px;
  height: 200px;
  object-fit: cover;
}
</style>
