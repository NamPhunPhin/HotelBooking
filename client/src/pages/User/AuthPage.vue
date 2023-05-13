<template>
  <div class="Auth-Container">
    <form action="">
      <div class="Button-Group">
        <button
          :class="isLogin && 'Btn-Switch-Active'"
          @click="
            (event) => {
              event.preventDefault();
              !isLogin && ButtonSwitchHandleClick(event);
            }
          "
        >
          Đăng nhập
        </button>
        <button
          :class="!isLogin && 'Btn-Switch-Active'"
          @click="
            (event) => {
              event.preventDefault();
              isLogin && ButtonSwitchHandleClick(event);
            }
          "
        >
          Đăng ký
        </button>
      </div>

      <h5 v-if="isLogin">
        Để đảm bảo an toàn, xin vui lòng đăng nhập để truy cập vào thông tin
      </h5>

      <div v-if="!isLogin" class="Input-Group">
        <div class="Input-Field">
          <input type="text" placeholder="Họ" v-model="dataForm.LastName" />
        </div>

        <div class="Input-Field">
          <input type="text" placeholder="Tên" v-model="dataForm.FirstName" />
        </div>
      </div>

      <div class="Input-Field">
        <input type="text" placeholder="Email" v-model="dataForm.Email" />
      </div>

      <div class="Input-Field">
        <input
          type="password"
          placeholder="Mật khẩu"
          v-model="dataForm.Password"
        />
      </div>

      <div v-if="!isLogin" class="Input-Field">
        <input
          type="password"
          placeholder="Nhập lại mật khẩu"
          v-model="dataForm.Repassword"
        />
      </div>

      <div v-if="!isLogin" class="CheckBox-Field">
        <input type="checkbox" @click="AcceptHandleClick()" />&ensp;
        <span>
          Tôi đồng ý với các Điều khoản sử dụng và Chính sách bảo mật của <br />
          Lisa.</span
        >
      </div>

      <div v-if="isLogin" class="Forget-Field">
        <span> Quên mật khẩu ?</span>
      </div>

      <div class="Button-Field">
        <button
          :disabled="isAccept != true && isLogin != true"
          :class="
            !isLogin
              ? isAccept == true
                ? 'Button-Main Btn-Signup'
                : 'Btn-Signup Dissable-Button'
              : 'Button-Main Btn-Signup'
          "
        >
          Tiếp tục
        </button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "AuthPage",
  data() {
    return {
      isLogin: true,
      isAccept: false,
      dataForm: {
        FirstName: "",
        LastName: "",
        Email: "",
        Password: "",
        Repassword: "",
      },
    };
  },

  methods: {
    // Phương thức thay đổi từ đăng nhập sang đăng ký và ngược lại.
    ButtonSwitchHandleClick(event) {
      event.preventDefault();
      this.isLogin = !this.isLogin;
      this.isAccept = false;
      this.dataForm.FirstName = "";
      this.dataForm.LastName = "";
      this.dataForm.Email = "";
      this.dataForm.Password = "";
      this.dataForm.Repassword = "";
    },

    //Phương thức xác nhận đồng ý với điều khoản.
    AcceptHandleClick() {
      this.isAccept = !this.isAccept;
    },
  },
};
</script>

<style>
.Auth-Container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  margin: 100px 0;
}

.Auth-Container > form > h5 {
  width: 500px;
  word-wrap: break-word;
  margin-bottom: 40px;
}

.Auth-Container > form {
  width: 500px;
}

.Auth-Container > form > .Input-Group {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
}

.Input-Group > .Input-Field:nth-of-type(1) {
  margin-right: 10px;
}

.Input-Group > .Input-Field:nth-of-type(2) {
  margin-left: 10px;
}

.Input-Field {
  margin-bottom: 25px;
  background: rgba(0, 0, 0, 0.05);
  border-radius: 10px;
}

.Input-Field > input {
  width: 100%;
  padding: 10px;
  background: none;
  border: none;
  font-size: 20px;
  font-weight: bold;
}

.Input-Field > input:focus {
  outline: none;
}

.Btn-Signup {
  border: none;
  width: 100%;
  padding: 10px;
  font-size: 18px;
  font-weight: 500;
  color: white;
}

.Button-Group {
  display: flex;
  border: 1px solid rgba(0, 0, 0, 0.1);
  margin-bottom: 40px;
  border-radius: 10px;
}

.Button-Group > button {
  width: 100%;
  padding: 10px;
  border-radius: 10px;
  font-weight: 500;
  background: none;
  border: none;
}

.Btn-Switch-Active {
  background: var(--main-Color) !important;
  color: white;
}

.CheckBox-Field {
  margin-bottom: 25px;
  word-break: break-all;
  display: flex;
  justify-content: center;
  align-items: center;
}

.CheckBox-Field > input {
  width: 20px;
  height: 20px;
  accent-color: var(--main-Color);
}

.Forget-Field > span {
  display: flex;
  justify-content: flex-end;
  margin-bottom: 25px;
}

.Dissable-Button {
  background: rgba(220, 53, 69, 0.8);
  border-radius: 10px;
}
</style>
